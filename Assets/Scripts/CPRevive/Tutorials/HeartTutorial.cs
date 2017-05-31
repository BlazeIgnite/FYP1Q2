using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
    Script Name: Heart Tutorial
    Author: Nurhidayat

    Description: Handles the scene with warning and caution scene.
                 With a demo on when to compress the mannequin 
*/
public class HeartTutorial : MonoBehaviour {

    // Private Variables
    float f_Timing;

    float f_HeartOriginalPosY;
    float f_HeartStopPosY;
    float f_HeartFallingspeed;

    float f_HandOriginalPosY;
    float f_HandStopPosY;
    float f_HandFallingspeed;

    float f_Scaletimer;
    float f_Scale;
    float f_ScaleSpeed;

    bool b_WarningOn;

    bool b_WarningText;

    bool b_HeartFalling;
    bool b_HandFalling;
    bool b_TextScale;
    
    // Public Variables
    [Tooltip("GameObject for the Heart")]
    public GameObject GO_Heart;
    [Tooltip("GameObject for the Hand")]
    public GameObject GO_Hand;
    [Tooltip("GameObject for the Text, Feedback")]
    public GameObject GO_Text;

    [Tooltip("Image for the Warning Text")]
    public Image Image_Warning;
    [Tooltip("Image for the Caution Text")]
    public Image Image_Caution;

	// Use this for initialization
	void Start () {

        f_Timing = 7;

        f_HeartOriginalPosY = GO_Heart.transform.position.y;
        f_HeartFallingspeed = 1;
        f_HeartStopPosY = -103;

        f_HandOriginalPosY = GO_Hand.transform.position.y;
        f_HandFallingspeed = 1;
        f_HandStopPosY = -101;

        f_Scale = 0;
        f_ScaleSpeed = 5;
        f_Scaletimer = 0;

        b_WarningOn = true;

        b_WarningText = true;
        
        for(int i = 0; i < GameObject.Find("Tutorial").transform.childCount - 1; i++)
        {
            GameObject.Find("Tutorial").transform.GetChild(i).GetComponent<Image>().enabled = false;
        }

        b_HeartFalling = true;
        b_HandFalling = false;
        b_TextScale = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (b_WarningOn)
        {
            // Warning images fade
            f_Timing -= Time.deltaTime;
            
            // fading time is to increase the speed of fading
            float fadingTime = 3;
            float temp = f_Timing / fadingTime;

            // If the time goes below 0
            if (f_Timing < 0)
            {
                if (b_WarningText)
                {
                    // This is to change the warning image to the caution of area image
                    b_WarningText = false;
                    Image_Caution.enabled = true;
                    GameObject.Find("Player").GetComponent<Image>().enabled = true;
                }
                else
                {
                    // Change the caution image to a show players how the game is to be played
                    b_WarningOn = false;
                    GameObject.Find("Warning Image").GetComponent<Image>().enabled = false;
                    for (int i = 0; i < GameObject.Find("Tutorial").transform.childCount - 1; i++)
                    {
                        GameObject.Find("Tutorial").transform.GetChild(i).GetComponent<Image>().enabled = true;
                    }
                }
                f_Timing = 7;
                return;
            }

            // To prevent the alpha going over 1
            if (temp > 1)
            {
                temp = 1;
            }

            // This if and else is for the fading effect
            if (b_WarningText)
            {
                Color color = Image_Warning.color;
                color.a = temp;
                Image_Warning.color = color;
                //Image_Warning.color = new Color(Image_Warning.color.r, Image_Warning.color.g, Image_Warning.color.b, (int)temp);
            }
            else
            {
                Color color = Image_Caution.color;
                color.a = temp;
                Image_Caution.color = color;

                color = GameObject.Find("Player").GetComponent<Image>().color;
                color.a = temp;
                GameObject.Find("Player").GetComponent<Image>().color = color;
            }
        }
        else
        {
            // This entire else is to show the player on how to play
            if (b_HeartFalling)
            {
                GO_Heart.transform.position = new Vector3(GO_Heart.transform.position.x, GO_Heart.transform.position.y - (f_HeartFallingspeed * Time.deltaTime), 0);
                if (GO_Heart.transform.localPosition.y < f_HeartStopPosY)
                {
                    f_HeartFallingspeed = 0;
                    GO_Heart.transform.localPosition = new Vector2(GO_Heart.transform.localPosition.x, f_HeartStopPosY);
                    b_HeartFalling = false;
                    b_HandFalling = true;
                }
            }
            if (b_HandFalling)
            {
                GO_Hand.transform.position = new Vector3(GO_Hand.transform.position.x, GO_Hand.transform.position.y - (f_HandFallingspeed * Time.deltaTime), 0);
                if (GO_Hand.transform.localPosition.y < f_HandStopPosY)
                {
                    f_HandFallingspeed = 0;
                    // Heart
                    GO_Heart.transform.localPosition = new Vector3(GO_Heart.transform.localPosition.x, f_HeartOriginalPosY, 0);
                    GO_Heart.GetComponent<Image>().enabled = false;

                    GO_Hand.transform.localPosition = new Vector3(GO_Hand.transform.localPosition.x, f_HandStopPosY, 0);

                    GameObject.Find("Tutorial Feedback Image").GetComponent<Image>().enabled = true;
                    b_HandFalling = false;
                    b_TextScale = true;
                }
            }
            if (b_TextScale)
            {
                f_Scale += Time.deltaTime * f_ScaleSpeed;
                GO_Text.transform.localScale = new Vector3(f_Scale, f_Scale);
                if (f_Scale >= 1)
                {
                    f_Scale = 1.1f;
                    f_Scaletimer += Time.deltaTime;
                    if (f_Scaletimer > 1)
                    {
                        f_Scale = 0;
                        f_Scaletimer = 0;

                        GameObject.Find("Tutorial Feedback Image").GetComponent<Image>().enabled = false;

                        GO_Heart.GetComponent<Image>().enabled = true;
                        f_HeartFallingspeed = 1;

                        GO_Hand.transform.localPosition = new Vector3(GO_Hand.transform.localPosition.x, f_HandOriginalPosY, 0);
                        f_HandFallingspeed = 1;

                        b_TextScale = false;
                        b_HeartFalling = true;
                    }
                }
            }
        }
    }
}

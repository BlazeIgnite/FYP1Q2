using UnityEngine;
using UnityEngine.UI;
using System.Collections;


/*
    Script Name: How To Play Script 
    Author: Nurhidayat

    Description: This is the script on how to do the hand position for CPR
*/
public class HowToPlayScript : MonoBehaviour {

    // Private Variables
    float f_RHandOri;
    float f_RHandTarget;

    float f_LHandOri;
    float f_LHandTarget;

    float f_Timer;

    bool[] b_Tutorial;

    // Public Variables
    [Tooltip("Put in RHanded first, FH, LH, RH. Then LHanded, FH, RH, LH")]
    public GameObject[] GO_Array;
    
	// Use this for initialization
	void Start () {
        f_RHandOri = GO_Array[2].transform.position.x;
        f_RHandTarget = GO_Array[1].transform.position.x;

        f_LHandOri = GO_Array[5].transform.position.x;
        f_LHandTarget = GO_Array[4].transform.position.x;

        f_Timer = 0;

        b_Tutorial = new bool[3];
        b_Tutorial[0] = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (b_Tutorial[0])
        {
            if (GO_Array[2].transform.position.x < f_RHandTarget)
            {
                // Movement of the hands
                GO_Array[2].transform.position = new Vector3(GO_Array[2].transform.position.x + Time.deltaTime, GO_Array[2].transform.position.y, GO_Array[2].transform.position.z);
                GO_Array[5].transform.position = new Vector3(GO_Array[5].transform.position.x + Time.deltaTime, GO_Array[5].transform.position.y, GO_Array[5].transform.position.z);
            }
            else
            {
                // Transition time
                b_Tutorial[0] = false;
                b_Tutorial[1] = true;
            }
        }
        else if (b_Tutorial[1])
        {
            // The alpha transition from 1 - 0
            Color image1;
            image1 = GO_Array[1].GetComponent<Image>().color;

            image1.a -= Time.deltaTime;

            GO_Array[1].GetComponent<Image>().color = image1;
            GO_Array[2].GetComponent<Image>().color = image1;
            GO_Array[4].GetComponent<Image>().color = image1;
            GO_Array[5].GetComponent<Image>().color = image1;

            // When the alpha reaches below 0, it will change image
            if (image1.a < 0)
            {
                GO_Array[0].GetComponent<Image>().enabled = true;
                GO_Array[3].GetComponent<Image>().enabled = true;
                b_Tutorial[1] = false;
                b_Tutorial[2] = true;
            }
            //GO_Array[0].GetComponent<Image>().color.a -= Time.deltaTime;
        }
        else if (b_Tutorial[2])
        {
            f_Timer += Time.deltaTime;

            if (f_Timer > 2)
            {
                f_Timer = 0;

                Color image1;
                image1 = GO_Array[1].GetComponent<Image>().color;

                image1.a = 1;

                // Resets the Image to be fully visible
                GO_Array[1].GetComponent<Image>().color = image1;
                GO_Array[2].GetComponent<Image>().color = image1;
                GO_Array[4].GetComponent<Image>().color = image1;
                GO_Array[5].GetComponent<Image>().color = image1;

                // Offs the component for Full Hand image
                GO_Array[0].GetComponent<Image>().enabled = false;
                GO_Array[3].GetComponent<Image>().enabled = false;

                // Resets the position
                GO_Array[2].transform.position = new Vector3(f_RHandOri, GO_Array[2].transform.position.y, GO_Array[2].transform.position.z);
                GO_Array[5].transform.position = new Vector3(f_LHandOri, GO_Array[5].transform.position.y, GO_Array[5].transform.position.z);

                b_Tutorial[2] = false;
                b_Tutorial[0] = true;
            }
        }
	}
}

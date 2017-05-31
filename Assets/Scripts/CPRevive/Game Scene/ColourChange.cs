using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
    Script Name: Colour Change
    Author: Nurhidayat

    Description: This script is used for the mannequin's colour change 
                 from blue to actual colour
*/
public class ColourChange : MonoBehaviour {

    // Private Variables
    float f_TimeToChange;
    float f_RRateSpeed;
    float f_GRateSpeed;
    float f_BRateSpeed;

    float f_Timer;

    // Public Variables
    [Tooltip("Target Colour for the end")]
    public Color C_TargetColour;

    // Use this for initialization
    void Start () {
        // Find the game length
        f_TimeToChange = GameObject.Find("Gameplay Logics").GetComponent<GHGameLogic>().GetGameTime();
        
        // Find the difference in value of colour
        Color ColorChange = C_TargetColour - GetComponent<Image>().color;

        // Setting up the rate per second
        f_RRateSpeed = ColorChange.r / f_TimeToChange;
        f_GRateSpeed = ColorChange.g / f_TimeToChange;
        f_BRateSpeed = ColorChange.b / f_TimeToChange;

        f_Timer = 0;
    }
	
	// Update is called once per frame
	void Update () {

        // Update the time
        f_Timer += Time.deltaTime;

        // Per second update
        if (f_Timer > 1)
        {
            // Reset Timer
            f_Timer = 0;

            // A temporary variable is needed to change values in colour
            Color C_Temp = GetComponent<Image>().color;
            C_Temp.r += f_RRateSpeed;
            C_Temp.g += f_GRateSpeed;
            C_Temp.b += f_BRateSpeed;

            // Change the colour to new colour
            GetComponent<Image>().color = C_Temp;
        }

    }
}

using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

/*
    Script Name : End Game Script
    Author : Wayne Lee

    Description : This script handles everything in the GHEndGameScene
 */

public class GHHighScore : MonoBehaviour {

    //Array of Text variables to store text data
    private Text[] arrayText = new Text[4];

    //Array of String variables to store score data
    private string[] a_StringOfScores;

    [Tooltip("Text handles to store and handle public text data")]
    public Text first, second, third, fourth;
    

	// Use this for initialization
	void Start () {
        arrayText[0] = first;
        arrayText[1] = second;
        arrayText[2] = third;
        arrayText[3] = fourth;
	}
	
	// Update is called once per frame
	void Update () {
        ReadScores();
	}

    /*
        Function Name : Read Scores
        params : NIL
        return : void
        Author : Wayne
        Description : Reads High Scores from text file "HighScores.txt"
     */
    void ReadScores()
    {
        //obtain a string array of the four scores
        a_StringOfScores = System.IO.File.ReadAllLines("Save/HighScores.txt");
        //scores should be sorted in text file
        for(int i = 0; i < a_StringOfScores.Length; i++)
        {
            arrayText[i].text = a_StringOfScores[i];
        }
    }
}

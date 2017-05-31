using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/*
    Script Name : End Game Script
    Author : Wayne Lee

    Description : This script handles everything in the GHEndGameScene
 */

public class GHEndGameScript : MonoBehaviour {

    //private Sprite Array
    private Sprite[] p_Array;

    //private GHScoreInfo List
    private List<GHScoreInfo> si_List;

    //variables to contain and handle scores
    private string[] newScores = new string[4];
    private string[] temp = new string[4];
    private int[] i_highscores = new int[8];
    
    
    //public Text variables to display scores for player standings
    [Tooltip("Text Displays for player standings")]
    public Text first, second, third, fourth;

    //public Sprite variables for player icons
    [Tooltip("Player Display Sprites")]
    public Sprite p_1, p_2, p_3, p_4;

    //public Image anchors for player sprite
    [Tooltip("Player Display Sprites")]
    public Image anchor_1, anchor_2, anchor_3, anchor_4;

	// Use this for initialization
	void Start () {

        //Get Player Score Data
        si_List = DataTransfer.Instance.GetPlayerScores();
        
        //Instantiate new Sprite Array
        p_Array = new Sprite[4];

        //Assign shit to shit
        p_Array[0] = p_1;
        p_Array[1] = p_2;
        p_Array[2] = p_3;
        p_Array[3] = p_4;

        //Disable all Anchors
        anchor_1.enabled = false;
        anchor_2.enabled = false;
        anchor_3.enabled = false;
        anchor_4.enabled = false;

        // Something something display stuff
        for (int i = 0; i < si_List.Count; i++)
        {
            string percentage = "0";
            float p = (((float)si_List[i].GetScore() / DataTransfer.Instance.GetMaxScore()) * 100);
            if (p != 0)
            {
                percentage = (p.ToString()).Substring(0, 4);
            }
            // can be further not hard coded
            if (i == 0)
            {
                first.text = si_List[i].GetScore().ToString() + "\n" + percentage + "%";
                anchor_1.enabled = true;
                anchor_1.sprite = p_Array[si_List[i].GetName() - 1];
            }
            else if (i == 1)
            {
                second.text = si_List[i].GetScore().ToString() + "\n" + percentage + "%";
                anchor_2.enabled = true;
                anchor_2.sprite = p_Array[si_List[i].GetName() - 1];
            }
            else if (i == 2)
            {
                third.text = si_List[i].GetScore().ToString() + "\n" + percentage + "%";
                anchor_3.enabled = true;
                anchor_3.sprite = p_Array[si_List[i].GetName() - 1];
            }
            else if (i == 3)
            {
                fourth.text = si_List[i].GetScore().ToString() + "\n" + percentage + "%";
                anchor_4.enabled = true;
                anchor_4.sprite = p_Array[si_List[i].GetName() - 1];
            }
        }
        //switch (si_List.Count)
        //{

        //    //1 Player
        //    case 1:
        //        {
        //            float p = (((float)si_List[0].GetScore() / DataTransfer.Instance.GetMaxScore()) * 100);
        //            first.text = si_List[0].GetScore().ToString() + "\n" +  p.ToString() + "%" ;
        //            anchor_1.enabled = true;
        //            anchor_1.sprite = p_Array[si_List[0].GetName() - 1];

        //            break;
        //        }
        //    //2 Player
        //    case 2:
        //        {
        //            float p = ((float)si_List[0].GetScore() / DataTransfer.Instance.GetMaxScore()) * 100;
        //            first.text = si_List[0].GetScore().ToString() + "\n" + p.ToString() + "%";
        //            anchor_1.enabled = true;
        //            anchor_1.sprite = p_Array[si_List[0].GetName() - 1];

        //            p = ((float)si_List[1].GetScore() / DataTransfer.Instance.GetMaxScore()) *100;
        //            second.text = si_List[1].GetScore().ToString() + "\n" + p.ToString() + "%";
        //            anchor_2.enabled = true;
        //            anchor_2.sprite = p_Array[si_List[1].GetName() - 1];

        //            break;
        //        }
        //    //You see where im going with this?
        //    case 3:
        //        {
        //            float p = ((float)si_List[0].GetScore() / DataTransfer.Instance.GetMaxScore()) * 100;
        //            first.text = si_List[0].GetScore().ToString() + "\n" + p.ToString() + "%";
        //            anchor_1.enabled = true;
        //            anchor_1.sprite = p_Array[si_List[0].GetName() - 1];

        //            p = ((float)si_List[1].GetScore() / DataTransfer.Instance.GetMaxScore()) * 100;
        //            second.text = si_List[1].GetScore().ToString() + "\n" + p.ToString() + "%";
        //            anchor_2.enabled = true;
        //            anchor_2.sprite = p_Array[si_List[1].GetName() - 1];

        //            p = ((float)si_List[2].GetScore() / DataTransfer.Instance.GetMaxScore()) * 100;
        //            third.text = si_List[2].GetScore().ToString() + "\n" + p.ToString() + "%";
        //            anchor_3.enabled = true;
        //            anchor_3.sprite = p_Array[si_List[2].GetName() - 1];

        //            break;
        //        }
        //    //you get the point
        //    case 4:
        //        {
        //            float p = ((float)si_List[0].GetScore() / DataTransfer.Instance.GetMaxScore()) * 100;
        //            string percentage = (p.ToString()).Substring(0, 4);
        //            first.text = si_List[0].GetScore().ToString() + "\n" + percentage + "%";
        //            anchor_1.enabled = true;
        //            anchor_1.sprite = p_Array[si_List[0].GetName() - 1];

        //            p = ((float)si_List[1].GetScore() / DataTransfer.Instance.GetMaxScore()) * 100;
        //            percentage = (p.ToString().Substring(0, 4));
        //            second.text = si_List[1].GetScore().ToString() + "\n" + percentage + "%";
        //            anchor_2.enabled = true;
        //            anchor_2.sprite = p_Array[si_List[1].GetName() - 1];

        //            p = ((float)si_List[2].GetScore() / DataTransfer.Instance.GetMaxScore()) * 100;
        //            percentage = (p.ToString().Substring(0, 4));
        //            third.text = si_List[2].GetScore().ToString() + "\n" + percentage + "%";
        //            anchor_3.enabled = true;
        //            anchor_3.sprite = p_Array[si_List[2].GetName() - 1];

        //            p = ((float)si_List[3].GetScore() / DataTransfer.Instance.GetMaxScore()) * 100;
        //            percentage = (p.ToString().Substring(0, 4));
        //            fourth.text = si_List[3].GetScore().ToString() + "\n" + percentage + "%";
        //            anchor_4.enabled = true;
        //            anchor_4.sprite = p_Array[si_List[3].GetName() - 1];

        //            break;
        //        }
        //}


        //Adjust Hall of Fame Scores from text file :^)^)^)^)^)
        AdjustHallOfFameScores();
    }
    
	
	// Update is called once per frame
	void Update () {
	
	}

    /*
        Function Name : Adjust Hall Of Fame Scores
        params : NIL
        return : null
        Author : Wayne
        Description : Extracts the current high scores from the file "HighScores.txt"
                      It then compares the current scores against the high scores 
                      and it arranges them in order, then writes it to the text file
     */
    void AdjustHallOfFameScores()
    {
        //ᑫᑌᗩᒪITY ᖴᑌᑕKIᑎG ᗩᑌTIᔕᗰ ᗷOYᔕ
        //Get Highest scores from text file
        temp = System.IO.File.ReadAllLines("Save/HighScores.txt");
        for(int i = 0; i < temp.Length; i++)
        {
            i_highscores[i] = Int32.Parse(temp[i]);
        }
        for(int i = 0; i < DataTransfer.Instance.GetActivePlayersinBool() ; i++)
        {
            i_highscores[i + 4] = (int)si_List[i].GetScore();
        }

        //sort array
        i_highscores = i_highscores.OrderByDescending(c => c).ToArray();

        string dataString = "";
        for(int i = 0; i < 4; i++) 
        {
            dataString += i_highscores[i].ToString() + Environment.NewLine;
        }

        File.WriteAllText("Save/Highscores.txt", dataString);
       // File.WriteAllText("Assets/Save/HighScores.txt", dataString);

    }
    /*
     Function Name : Return to Main Menu
        params : NIL
        return : null
        Author : Wayne
        Description : Literally returns to main menu
     */
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

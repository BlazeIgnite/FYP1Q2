using UnityEngine;
using System.Collections;

/*
    Script Name : GH Score Info Class
    Author : Wayne Lee

    Description : This script handles everything in the GHEndGameScene
 */
public class GHScoreInfo : MonoBehaviour {

    //Player Index
    private int i_Name;
    //Player Score
    private int i_Score;

    /*
         Function Name : GHScoreInfo(int name, int score)
         params : int, int
         return : null
         Author : Wayne
         Description : Constructor for GHScoreInfo class
     */
    public GHScoreInfo(int name, int score)
    {
        i_Name = name;
        i_Score = score;
    }

    /*
         Function Name : Set(int name, int score)
         params : int, int
         return : null
         Author : Wayne
         Description : Set GHScoreInfo variable data
     */
    public void Set(int name, int score)
    {
        this.i_Name = name;
        this.i_Score = score;
    }
    /*
         Function Name : GetScore
         params : none
         return : int
         Author : Wayne
         Description : returns i_Score
     */
    public int GetScore()
    {
        return i_Score;
    }

    /*
         Function Name : GetName    
         params : none
         return : int
         Author : Wayne
         Description : returns i_Name;
     */
    public int GetName()
    {
        return i_Name;
    }


    /*
         Function Name : SetScore
         params : int score
         return : void
         Author : Wayne
         Description : Sets Score
     */
    public void SetScore(int score)
    {
        i_Score = score;
    }
    /*
         Function Name : SetName
         params : int name
         return : void
         Author : Wayne
         Description : Sets Name
     */
    public void SetName(int name)
    {
        i_Name = name;
    }
}

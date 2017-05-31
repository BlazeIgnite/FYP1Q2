using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

/*
    ======================== LEGACY SCRIPT============================
    Script Name : GHScoreManager
    Author : Wayne Lee

    Description : This script handles the scoring system 

    UPDATE: Script functionality has been moved to DataTransfer.cs
    check DataTransfer.cs pls ok thanks 
 */

public class GHScoreManager : Singleton<GHScoreManager> {
    //constructor
    protected GHScoreManager() { }

    [Tooltip("list of score info")]
    public List<GHScoreInfo> list;

	// Use this for initialization
	void Start () {
        list = new List<GHScoreInfo>();
	}
	
	// Update is called once per frame
	void Update () {
	//lul smlj update
	}

    /*
       Function Name : Create Player
       Author : Wayne
       params : GHScoreInfo
       Return : null

       Description : Create and add players into the playerInfo array
    */
    public void CreatePlayer(GHScoreInfo playerInfo)
    {
        list.Add(playerInfo);
    }

    /*
       Function Name : Add Score
       Author : Wayne
       params : GHScoreInfo 
       Return : void

       Description: Adds to the player score
   */
    public void AddScore(GHScoreInfo scoreInfo)
    {
        foreach(var s in list)
        {
            int currentScore = s.GetScore();
            if (s.GetName() == scoreInfo.GetName())
            {
                s.SetScore(currentScore += scoreInfo.GetScore());
            }
        }
        Sort();
    }
    /*
       Function Name : Sort
       Author : Wayne
       Return : null

       Description : Sort the playerScores array in Descending Order based on score
   */
    public void Sort()
    {
        list = list.OrderBy(s => s.GetScore()).ToList();
    }
}

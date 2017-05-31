using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/*
    Script Name: Data Transfer (Instance) 
    Author: Nurhidayat, Wayne

    Description: Handles Data regarding active players and score
*/
public class DataTransfer : Singleton<DataTransfer> {
    // Constructor
    protected DataTransfer() {}

    // Private Variables
    List<GHScoreInfo> playerScores;
    int i_maxScore;
    bool[] activeplayerData;

	// Use this for initialization
	void Start () {
        playerScores = new List<GHScoreInfo>();
	}

    // Methods

   /*
       Function Name : Add Player
       Author : Wayne
       params : GHScoreInfo
       Return : null
    
       Description : Add Players to the playerScores array
    */
    public void AddPlayer(GHScoreInfo info)
    {
        playerScores.Add(info);
    }

    /*
       Function Name : Add Score
       Author : Wayne
       params : GHScoreInfo 
       Return : void

       Description: Adds to the player score
   */
    public void AddScore(GHScoreInfo info)
    {
        foreach (var s in playerScores)
        {
            int currentScore = s.GetScore();
            if (s.GetName() == info.GetName())
            {
                s.SetScore(currentScore += info.GetScore());
            }
        }
        //Sort the score array
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
        //Sort List by var "s.GetScore"
        playerScores = playerScores.OrderByDescending(s => s.GetScore()).ToList();
    }

    /*
        Function Name: Player Active Transfer
        Author: Nurhidayat
        Return: 

        Description: This is to set the active players in the game
                     for transferring data to another scene
    */
    public void PlayerActiveTransfer(bool[] playeractive)
    {
        activeplayerData = playeractive;
    }

    // Setters
    /*
        Function Name: Set Max Score
        Author: Nurhidayat
        Return: 

        Description: Sets max score achievable in CPRevive
    */
    public void SetMaxScore(int maxScore)
    {
        i_maxScore = maxScore;
    }

    // Getters
    /*
        Function Name: Get Player Scores
        Author: Wayne
        Return: List<GHScoreInfo>

        Description: Gets the List of player scores
    */
    public List<GHScoreInfo> GetPlayerScores()
    {
        return playerScores;
    }

    /*
        Function Name: Get Max Score
        Author: Nurhidayat
        Return: int

        Description: Gets max score achievable in CPRevive
    */
    public int GetMaxScore()
    {
        return i_maxScore;
    }

    /*
        Function Name: Get Active Players In Bool
        Author: Nurhidayat
        Return: int

        Description: Gets the number of players
    */
    public int GetActivePlayersinBool()
    {
        int i = 0;
        for (int index = 0; index < activeplayerData.Length; index++)
        {
            if (activeplayerData[index])
                i++;
        }
        return i;
    }

    /*
        Function Name: Get Active Players
        Author: Nurhidayat
        Return: bool[]

        Description: Gets the bool array of players
    */
    public bool[] GetActivePlayers()
    {
        return activeplayerData;
    }

    /*
        Function Name: Get Active Players
        Author: Nurhidayat
        Return: bool[]

        Description: Gets the bool array of players
    */
    public void ResetData()
    {
        playerScores.Clear();
        for(int i = 0;  i < activeplayerData.Length; i ++)
        {
            activeplayerData[i] = false;
        }
    }
}

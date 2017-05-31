using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

/*
    Script Name: Game Logic
    Author: Nurhidayat
    
    Description: Handles the users scores and game time  
*/
public class GHGameLogic : MonoBehaviour {
    
    // Private variables
    DataTransfer dt;
    GameObject[] GO_PlayerGO;

    float f_GameTime = 30;
    float f_Offset;

    int i_MaxScore;

    bool[] b_PlayerActiveList;

    // Public variables
    public GameObject MusicSpawnPrefab;

    // Use this for initialization
    void Start() {
        dt = DataTransfer.Instance;

        i_MaxScore = 0;

        // Change the number to set the timing for game
        if (f_GameTime == 0)
            f_GameTime = 30;

        // After game time an offset to change scene, a delay basically
        f_Offset = 5;

        // Setting Up Game
        SetUpGame();
    }

    // Update per frame
    void Update()
    {
        // Gametime timer
        if (f_GameTime > 0)
        {
            f_GameTime -= Time.deltaTime;
        }
        else
        {
            // After game time, there will be an offset before next scene
            if (f_Offset > 0)
            {
                f_Offset -= Time.deltaTime;
            }
            else
            {
                f_Offset = 0;
                f_GameTime = 0;

                // Pass the max score to Data Transfer
                dt.SetMaxScore(i_MaxScore);
                for (int i = 0; i < GO_PlayerGO.Length; i++)
                {
                    if (b_PlayerActiveList[i])
                        // + 1 to i because it was coded to take 1 - 4
                        // Pass the score to data transfer
                        dt.AddScore(new GHScoreInfo(i + 1, GO_PlayerGO[i].transform.GetChild(2).GetComponent<MusicBarLogic>().GetScore()));
                }
                SceneManager.LoadScene(4);
            }
        }
    }

    // Methods

    /*
        Function Name: Set Up Game
        Params: void
        Returns:
        
        Description: This function is to set up the game with the number of
                     active players 
    */
    void SetUpGame()
    {
        // Gets info on who is playing
        GO_PlayerGO = GameObject.FindGameObjectsWithTag("Player").OrderBy(s => s.name).ToArray();
        b_PlayerActiveList = dt.GetActivePlayers();

        // Testing Codes Here
        //b_PlayerActiveList[0] = true;
        //b_PlayerActiveList[1] = true;
        //b_PlayerActiveList[2] = true;
        //b_PlayerActiveList[3] = true;

        for (int i = 0; i < GO_PlayerGO.Length; i++)
        {
            if (b_PlayerActiveList[i])
            {
                // This is to set up the game

                // Spawns the music spawner according to player active
                GameObject go = (GameObject)Instantiate(MusicSpawnPrefab, new Vector3(GO_PlayerGO[i].transform.GetChild(2).transform.position.x, 403, 0), Quaternion.identity);
                go.transform.SetParent(GO_PlayerGO[i].transform);

                // Had to do this as setting parents will cause the numbers to go weird
                // Just safe keeping my things
                go.transform.localScale = new Vector3(1, 1, 1);
                go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, 0);

                go.GetComponent<MusicNoteSpawner>().SetMusicBarLogic(GO_PlayerGO[i].transform.GetChild(2).GetComponent<MusicBarLogic>());

                // Offs the gameobject Player Absence
                GO_PlayerGO[i].transform.GetChild(3).GetComponent<Image>().enabled = false;
            }
        }
    }

    // Setters

    /*
        Function Name: Set Player in Array
        Params: int, bool
        Return:
        
        Description: This setter is to set what number player is playing
    */
    public void SetPlayerInArray(int index, bool boolean)
    {
        b_PlayerActiveList[index] = boolean;
    }

    /*
        Function Name: Set Max Score
        Params: int
        Return:
        
        Description: Setter of max score possible achievable in game
    */
    public void SetMaxScore(int newmaxscore)
    {
        i_MaxScore = newmaxscore;
    }


    // Getters

    /*
        Function Name:Get Game Time
        Params: void
        Return: float
        
        Description: Getter of Game Time
    */
    public float GetGameTime()
    {
        return f_GameTime;
    }
}

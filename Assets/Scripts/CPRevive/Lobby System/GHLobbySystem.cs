using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

/*
    Script Name: Lobby System
    Author: Nurhidayat
    
    Description: Is in charge of handling players playing
                 and sending into the gameplay during the lobby
                 ARCADE STYLE 
*/
public class GHLobbySystem : MonoBehaviour {
    
    // Private variables
    GameObject[] go_ArrayTextReady;
    GameObject[] go_ArrayImageReady;

    DataTransfer dt;

    float f_Timer;
    bool[] b_ArrayPlayerActives;

    // Use this for initialization
    void Start() {

        f_Timer = 5f;

        // Gets the instances passed through Data Transfer
        dt = DataTransfer.Instance;

        // Prepares for input and create 4 empty false bools
        b_ArrayPlayerActives = new bool[4];
        for (int i = 0; i < b_ArrayPlayerActives.Length; i++)
        {
            b_ArrayPlayerActives[i] = false;
        }

        // Finds the scene with the tag snf it will be used for animation and texts image
        go_ArrayTextReady = GameObject.FindGameObjectsWithTag("UI Ready").OrderBy(s => s.name).ToArray();
        go_ArrayImageReady = GameObject.FindGameObjectsWithTag("UI Player").OrderBy(s => s.name).ToArray();

    }

    // Update is called once per frame
    void Update() {

        // Any of these 4 inputs sets the active players
        if (Input.GetKeyDown(KeyCode.Q))
            SetActivePlayer(0, true);
        else if (Input.GetKeyDown(KeyCode.Z))
            SetActivePlayer(1, true);
        else if (Input.GetKeyDown(KeyCode.P))
            SetActivePlayer(2, true);
        else if (Input.GetKeyDown(KeyCode.M))
            SetActivePlayer(3, true);

        // If anyone wants to play, the timer will start
        if (GetNumberActivePlayer() >= 1)
            f_Timer -= Time.deltaTime;

        // Timer reaches 0, change scene and will put the active players into Data Transfer
        if (f_Timer < 0)
        {
            dt.PlayerActiveTransfer(b_ArrayPlayerActives);
            SceneManager.LoadScene(1);
        } 

    }

    // Setters

    /*
        Function Name: Set Active Player
        Params: int, bool
        Return:
        
        Description: Sets the player index to true so the main gameplay
                     knows who is playing 
    */
    public void SetActivePlayer(int index, bool active)
    {
        // If it was already true, this function will return
        if (b_ArrayPlayerActives[index])
            return;

        // Resets the timer
        f_Timer = 5;

        // Changes to active
        b_ArrayPlayerActives[index] = active;

        // This two will make the Text appear and the animation will start
        go_ArrayTextReady[index].GetComponent<Image>().enabled = true;
        go_ArrayImageReady[index].GetComponent<Animator>().enabled = true;

        // Once there are 4 players, the timer will be much shorter
        if (GetNumberActivePlayer() == b_ArrayPlayerActives.Length)
            f_Timer = 4;

        // Create new player and add to the ScoreManager List
        GHScoreInfo info = new GHScoreInfo(index + 1, 0);
        //GHScoreManager.Instance.CreatePlayer(info);

        DataTransfer.Instance.AddPlayer(info);

    }


    // Getters

    /*
        Function Name: Get Number Active Player
        Params: void
        Return: int

        Description: Getters of number of active players for the game
    */
    public int GetNumberActivePlayer()
    {
        int i = 0;
        for (int j = 0; j < b_ArrayPlayerActives.Length; j++)
        {
            if (b_ArrayPlayerActives[j])
                i++;
        }
        return i;
    }

    /*
        Function Name: Get Active Player
        Params: int
        Return: bool

        Description: Gets the bool of that index, to see if that player is active
    */
    public bool GetActivePlayer(int index)
    {
        return b_ArrayPlayerActives[index];
    }

    /*
        Function Name: Get Timer
        Params: void
        Return: float

        Description: Returns the timer left in the lobby
    */
    public float GetTimer()
    {
        return f_Timer;
    }

    // Archives
    //void SortArrayText()
    //{
    //    int[] value;
    //    value = new int[4];

    //    for (int i = 0; i < value.Length; i++)
    //    {
    //        int temp = Convert.ToInt32(go_ArrayTextReady[i].name.Substring(go_ArrayTextReady[i].name.Length - 1));
    //        value[i]= temp;
    //    }
    //}
}

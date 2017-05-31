using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Linq;

/*
    Script Name: Tutorial Script
    Author: Nurhidayat

    Description: It is a scene manager when all the players are ready to move to next scene
*/
public class TutorialScript : MonoBehaviour {

    DataTransfer dt;

    bool[] playersReady;

	// Use this for initialization
	void Start () {

        dt = DataTransfer.Instance;

        playersReady = new bool[4];
        for (int index = 0; index < playersReady.Length; index++)
        {
            playersReady[index] = false;
        }

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            playersReady[0] = true;
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            playersReady[1] = true;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            playersReady[2] = true;
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            playersReady[3] = true;
        }

        string s_SceneName;
        Scene scene = SceneManager.GetActiveScene();

        s_SceneName = scene.name;

        if (ReadyForGame() && SceneManager.GetActiveScene().buildIndex == 2)
            SceneManager.LoadScene(3);
        else if (ReadyForGame() && SceneManager.GetActiveScene().buildIndex == 1)
            SceneManager.LoadScene(2);
    }

    /*
        Function Name: Get Player Ready
        Params: void
        Return: int

        Description: Get Number of Players that are ready to next scene
    */
    int GetPlayerReady()
    {
        int i = 0;
        for (int index = 0; index < playersReady.Length; index++)
        {
            if (playersReady[index])
                i++;
        }
        return i;
    }

    /*
        Function Name: Ready For Game
        Params: void
        Return: bool

        Description: When all players are ready, change scene 
    */
    bool ReadyForGame()
    {
        if (playersReady.SequenceEqual(dt.GetActivePlayers()))
            return true;
        return false;
    }
}

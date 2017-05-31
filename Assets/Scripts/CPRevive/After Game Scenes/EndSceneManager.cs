using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


/*
    Script Name: End Scene Manager
    Author: Nurhidayat

    Description: This Script is used for changing scene among Scoreboard,
                 Highscores and Animation scene
*/
public class EndSceneManager : MonoBehaviour {

    // Private Variables
    float f_Timer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        f_Timer += Time.deltaTime;

        // After 7 seconds it will change scene
        if (f_Timer > 7)
        {
            f_Timer = 0;
            if (SceneManager.GetActiveScene().buildIndex == 3)
                SceneManager.LoadScene(4);
            else if (SceneManager.GetActiveScene().buildIndex == 4)
                SceneManager.LoadScene(5);
        }
	}
}

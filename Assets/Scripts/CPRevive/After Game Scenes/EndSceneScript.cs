using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/*
    Script Name: End Scene Script
    Author: Nurhidayat

    Description: Change from animation scene to the lobby scene 
*/
public class EndSceneScript : MonoBehaviour {

    // Private Variables
    float f_Timer;

	// Use this for initialization
	void Start () {
        f_Timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        f_Timer += Time.deltaTime;

        // Change the scene name if required
        if (f_Timer > 10)
        {
            SceneManager.LoadScene(0);
            DataTransfer.Instance.ResetData();
        }

	}
}

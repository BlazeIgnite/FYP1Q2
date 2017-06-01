using UnityEngine;
using UnityEngine.UI;


/*
    Script Name: Lobby Timer
    Author: Nurhidayat

    Description: Displays Timer in the scene
*/
public class GHLobbyTimer : MonoBehaviour {

    Text timerText;
    GHLobbySystem lobby;
    
	// Use this for initialization
	void Start () {
        timerText = GetComponent<Text>();
        lobby = GameObject.Find("LobbyController").GetComponent<GHLobbySystem>();
    }
	
	// Update is called once per frame
	void Update () {
        timerText.text = ((int)lobby.GetTimer()).ToString();
	}
}

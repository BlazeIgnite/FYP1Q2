using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EndGameScript : MonoBehaviour {

    List<ScoreInfo> playerList;
    public Text first, second, third, fourth;

	// Use this for initialization
	void Start () {
        playerList = ScoreManager.Instance.list;
        first.text = playerList[0].m_namaste + ": " + playerList[0].m_TimeTaken;
        second.text = playerList[1].m_namaste + ": " + playerList[1].m_TimeTaken;
        third.text = playerList[2].m_namaste + ": " + playerList[2].m_TimeTaken;
        fourth.text = playerList[3].m_namaste + ": " + playerList[3].m_TimeTaken;
    }
    void Update()
    {

    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}


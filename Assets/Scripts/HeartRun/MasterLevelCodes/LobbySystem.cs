using UnityEngine;

using System.Collections;

public class LobbySystem : MonoBehaviour {

    // Private Variables

    // Array
    private bool[] m_PlayerActivated;

    // Floats
    private float m_Timer;
    private float m_TimeToStart;

    // Booleans
    private bool m_StartGame;
    private bool m_LoadedGame;


    // Public Variables

    // Use this for initialization
    void Start () {

        m_PlayerActivated = new bool[4] { false, false, false, false };

        m_TimeToStart = 10;
        m_Timer = m_TimeToStart;

        m_StartGame = false;
        m_LoadedGame = false;

    }
	
	// Update is called once per frame
	void Update () {

        if (m_Timer < 0 && !m_StartGame)
        {
            m_Timer = m_TimeToStart;
            m_StartGame = true;
        }
        else if (m_StartGame)
        {
            if (m_LoadedGame)
                return;

            // *********************************** //
            // Doing this so player can be found
            // Finding in the same frame causes the controller not able to detect the players thus, rip
            int tempo = 0;
            string playername = "Player_";

            for (; tempo < m_PlayerActivated.Length; tempo++)
            {
                if (m_PlayerActivated[tempo])
                {
                    playername += ++tempo;
                    break;
                }
            }

            if (GameObject.Find(playername) != null)
            {
                m_LoadedGame = true;
                GameObject.Find("PlayerController").GetComponent<PlayerController>().SortPlayersInArray();
                return;
            }

            // *********************************** //

            ////Load all additive scenes
            //SceneManager.LoadScene("Level_01", LoadSceneMode.Additive);
            //SceneManager.LoadScene("Level_02", LoadSceneMode.Additive);
            //SceneManager.LoadScene("Level_03", LoadSceneMode.Additive);
            //SceneManager.LoadScene("Level_04", LoadSceneMode.Additive);

            // If it works, lel
            for (int i = 0; i < m_PlayerActivated.Length;)
            {
                // TO DO :
                string LevelName = "Level_0";
                if (m_PlayerActivated[i])
                    LevelName += ++i;
                else
                {
                    LevelName = "No_Player_Scene";
                    i++;
                }
                GetComponent<MasterLevelScript>().LoadScene(LevelName);
            }

            GetComponent<LobbyEventManager>().OffLobbyUI();
        }
        else
        {
            if (GetNumberOfPlayers() != 0)
                m_Timer -= Time.deltaTime;
        }
    }


    // Setters
    public void SetTimer(float timer)
    {
        m_Timer = timer;
    }

    public void SetPlayerActive(int position, int numberToSet)
    {
        // First 3 ifs to handle stupid inputs that dont concern the MasterLevel
        if (position < 0 || position >= m_PlayerActivated.Length)
            return;
        if (m_PlayerActivated[position])
            return;
        if (numberToSet < 0 && numberToSet > 1)
            return;
        if (numberToSet == 1)
            m_PlayerActivated[position] = true;
        else
            return;

        if (GetNumberOfPlayers() == m_PlayerActivated.Length)
            m_Timer = 4;
        else
            m_Timer = m_TimeToStart;

        GetComponent<LobbyEventManager>().PlayerJoined(++position);
    }


    // Getters
    public bool[] GetArrayOfPlayerActive()
    {
        return m_PlayerActivated;
    }

    public int GetNumberOfPlayers()
    {
        int ActivePlayer = 0;
        for (int i = 0; i < m_PlayerActivated.Length; i++)
        {
            if (m_PlayerActivated[i])
                ActivePlayer++;
        }
        return ActivePlayer;
    }

    public bool GetStartGame()
    {
        return m_StartGame;
    }

    public bool GetLoadedGame()
    {
        return m_LoadedGame;
    }

    public float GetTimer()
    {
        return m_Timer;
    }

    public float ResetTimer()
    {
        return m_TimeToStart;
    }
}

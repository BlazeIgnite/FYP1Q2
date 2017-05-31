using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;

// Master Level to load the 4 additive scenes
public class MasterLevelScript : MonoBehaviour {
    bool endLoaded;
    private PlayerController pC;
    // Storing Scene Names
    // Use this only on the Heart Run Game
    void Start()
    {
        pC = GameObject.Find("PlayerController").GetComponent<PlayerController>();
    }
    void Update()
    {
        if(pC.allDone && !endLoaded)
        {
            UnLoadAllScenes();
            endLoaded = true;
            SceneManager.LoadScene("EndGame", LoadSceneMode.Additive);
        }
    }
    private string[] m_SceneNamesArray = new string[4] { "", "", "", "" };
    public void LoadScene(string LevelName)
    {
        int index = 0;
        for (; index < m_SceneNamesArray.Length; index++)
        {
            if (m_SceneNamesArray[index] == "")
                break;
        }
        m_SceneNamesArray[index] = LevelName;
        SceneManager.LoadScene(LevelName, LoadSceneMode.Additive);
    }

    // Unloading is required if our scenes are added additively
    public void UnLoadScene(string LevelName)
    {
        int index = 0;
        for (; index < m_SceneNamesArray.Length; index++)
        {
            if (m_SceneNamesArray[index] == LevelName)
                break;
        }
        SceneManager.UnloadScene(m_SceneNamesArray[index]);
        m_SceneNamesArray[index] = "";
    }

    public void UnLoadAllScenes()
    {
        for (int i = 0; i < m_SceneNamesArray.Length; i++)
        {
            SceneManager.UnloadScene(m_SceneNamesArray[i]);
            m_SceneNamesArray[i] = "";
        }
    }

}

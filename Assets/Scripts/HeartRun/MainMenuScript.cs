using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    // Public Functions
    public void LoadGame()
    { 
        SceneManager.LoadScene("MasterLevel", LoadSceneMode.Single);
    }
    public void LoadOptions()
    { 
        SceneManager.LoadScene("Options", LoadSceneMode.Single);
    }
}

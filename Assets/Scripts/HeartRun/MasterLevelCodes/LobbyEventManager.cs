using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LobbyEventManager : MonoBehaviour {

    // Soft Coding is the best Coding
    // This function supplies for all situations
    public void PlayerJoined(int PlayerNumber)
    {
        string PressToJoin = "Text_Player0" + PlayerNumber + "_PressToJoin";
        string ImageName = "Image_Player0" + PlayerNumber;
        string BGName = "Player0" + PlayerNumber + "_BG";

        GameObject.Find(PressToJoin).SetActive(false);
        GameObject.Find(ImageName).GetComponent<Image>().enabled = true;
        Image[] ImageComponents = GameObject.Find(BGName).GetComponentsInChildren<Image>();

        foreach (Image i in ImageComponents)
            i.color = Color.white;
    }

    public void OffLobbyUI()
    {
        GameObject.Find("LobbyCanvas").SetActive(false);
    }

}

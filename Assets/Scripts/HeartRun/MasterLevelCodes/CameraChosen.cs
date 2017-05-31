using UnityEngine;
using System.Collections;

public class CameraChosen : MonoBehaviour {

    LobbySystem ls;

	// Use this for initialization
	void Start () {
        ls = GameObject.Find("MasterLevelController").GetComponent<LobbySystem>();
        bool[] Array = ls.GetArrayOfPlayerActive();
        for (int i = 0; i < Array.Length; i++)
        {
            if (Array[i])
            {
                string CameraName = "Camera_" + (i + 1);
                GameObject.Find(CameraName).SetActive(false);
            }
        }
    }

}

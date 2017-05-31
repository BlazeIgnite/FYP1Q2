using UnityEngine;
using System.Collections;


public class CameraController : MonoBehaviour {

    public GameObject Player; //to change to player position

	// Use this for initialization
	void Start () {
        //Player = GameObject.FindGameObjectWithTag("Player");
	}

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector3(Player.transform.position.x, 0, 0));
        transform.position = new Vector3(Player.transform.position.x + 5f, Player.transform.position.y + 1.2f, transform.position.z);
    }

    // Setters
    public void SetTargetPlayer(GameObject newPlayer)
    {
        Player = newPlayer;
    }
}

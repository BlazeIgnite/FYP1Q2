using UnityEngine;
using System.Collections;

public class DwayneTheRockJohnson : MonoBehaviour {

    private float m_time = 0;
    private float m_timeAlive = 5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        m_time += Time.deltaTime;
        if (m_time > m_timeAlive)
        {
            Destroy(this.gameObject);
            m_time = 0;
        }
	}
}

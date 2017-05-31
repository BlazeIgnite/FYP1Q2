using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class ScoreInfo : MonoBehaviour {

    public string m_namaste;
    public float m_TimeTaken;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Set(string name, float timeTaken)
    {
        this.m_namaste = name;
        this.m_TimeTaken = timeTaken;
    }
    public float GetTime()
    {
        return m_TimeTaken;
    }
}

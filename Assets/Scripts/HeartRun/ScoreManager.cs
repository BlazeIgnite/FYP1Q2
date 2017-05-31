using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;



public class ScoreManager : Singleton<ScoreManager> {
    protected ScoreManager() { }

    public List<ScoreInfo> list;
    // Use this for initialization
    void Awake()
    {
        list = new List<ScoreInfo>();
    }

    // Update is called once per frame
    void Update () {
	
	}
    public void AddToList(ScoreInfo info)
    {
        //Add and sort the liut
        list.Add(info);
        Sort();
    }
    void Sort()
    {
        //Sort List by var "m_TimeTaken"
        list = list.OrderBy(s => s.GetTime()).ToList();
    }
}

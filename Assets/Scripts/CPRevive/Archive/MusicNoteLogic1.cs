using UnityEngine;
using System.Collections;

public class MusicNoteLogic1 : MonoBehaviour {

    public GameObject GO_musicBar;

    Rigidbody2D m_Rb2D;
    Collider2D m_Collider2D;
    RectTransform m_Rt;

    float f_Lifespan;
    bool b_InsideBar;


    public float m_Falling_Speed;

    // Use this for initialization
    void Start()
    {

        m_Rb2D = GetComponent<Rigidbody2D>();
        //m_Rb2D.velocity = new Vector2(0, m_Falling_Speed);
        m_Collider2D = GetComponent<BoxCollider2D>();
        m_Rt = GetComponent<RectTransform>();
        
        GO_musicBar = transform.parent.parent.GetChild(2).gameObject;
        b_InsideBar = false;

        f_Lifespan = 0;

    }
	
	// Update is called once per frame
	void Update () {
        f_Lifespan += Time.deltaTime;
	}

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Music Bar")
        {
            m_Collider2D.isTrigger = true;
            b_InsideBar = true;
        }
        else if (c.gameObject.tag == "Boundary")
        {
            GO_musicBar.GetComponent<MusicBarLogic>().RemoveMusicNote(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.tag == "Music Bar")
        {
            b_InsideBar = false;
            GO_musicBar.GetComponent<MusicBarLogic>().RemoveMusicNote(gameObject);
        }
    }

    public bool GetInsideBar()
    {
        return b_InsideBar;
    }

    public float GetLifespan()
    {
        return f_Lifespan;
    }
}

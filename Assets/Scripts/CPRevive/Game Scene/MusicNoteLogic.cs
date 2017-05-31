using UnityEngine;
using System.Collections;

/*
    Script Name: Music Note Logic 
*/
public class MusicNoteLogic : MonoBehaviour {

    // Private Variables
    GameObject GO_musicBar;

    Rigidbody2D m_Rb2D;
    RectTransform m_Rt;
    Collider2D m_Collider2D;

    bool b_InsideBar;

    // Public Variables
    [Tooltip("Choose the falling speed of the note")]
    public float m_Falling_Speed;

    // Use this for initialization
    void Start()
    {

        m_Rb2D = GetComponent<Rigidbody2D>();
        m_Rb2D.velocity = new Vector2(0, m_Falling_Speed);

        m_Collider2D = GetComponent<BoxCollider2D>();
        m_Rt = GetComponent<RectTransform>();
        
        // The Scene must be in that order for this to work
        GO_musicBar = transform.parent.parent.GetChild(2).gameObject;
        b_InsideBar = false;

    }
	
	// Update is called once per frame
	void Update () {
	}

    // Methods

    /*
        Function Name: On Trigger Enter 2D
        Params: Collider2D
        Return: 

        Description: This function handles the m_Collider to allow the music note to pass through the bar 
    */
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Music Bar")
        {
            m_Collider2D.isTrigger = true;
            b_InsideBar = true;
        }
        else if (c.gameObject.tag == "Boundary")
        {
            Delete();
        }
    }

    // Getters

    /*
        Function Name: Get Inside Bar
        Params: void
        Return: 

        Description: A getter that returns if the note is inside the bar 
    */
    public bool GetInsideBar()
    {
        return b_InsideBar;
    }

    /*
        Function Name: Delete
        Params: void
        Return: 

        Description: Unity's Destroy
    */
    public void Delete()
    {
        Destroy(gameObject);
    }
}

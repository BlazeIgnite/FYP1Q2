using UnityEngine;
using System.Collections;

public class PlayerInformation : MonoBehaviour
{
    // ********************************************** //
    // Member Variables

    // Private
    private Rigidbody2D m_Rb2D;
    private Vector3 m_OriginalPosition;
    private ScoreInfo m_ScoreInfo;
    
    private int m_RacePosition;
    //private int m_InvisFrameTotal = 2;
    //private int m_PlatformNeed = 1;

    private float m_JumpValue = 1200;
    private float m_OriginalVelocityX;
    private float m_FinishingLineX;
    private float m_DistanceFinishingLine;
    private float m_VelocityX;

    private bool m_OnGround = false;
    public bool m_IsFinished = false;

    // Public 
    public GameObject m_fLine;

    // I NEED THIS DONT DELETE
    public float m_TimeTaken;

    //Singletons
    //public static RaceData raceData;
    public static ScoreManager scoreManager;

    // ********************************************** //
    // Functions

    // Use this for initialization
    void Start ()
    {
        m_Rb2D = GetComponent<Rigidbody2D>();
        m_ScoreInfo = new ScoreInfo();
        m_OriginalPosition = transform.position;

        m_VelocityX = 15f;

        m_OriginalVelocityX = m_VelocityX;
        m_FinishingLineX = m_fLine.transform.position.x;

        m_TimeTaken = 0;
    }
	
	// Update is called once per frame
	void Update ()
	{
        transform.Translate(new Vector3(m_VelocityX * Time.deltaTime, 0, 0));
        if(!m_IsFinished)
            m_TimeTaken += Time.deltaTime;

        // For testing without port
        if (m_OnGround)
        {
            if (Input.GetKeyDown(KeyCode.Z) && gameObject.name == "Player_1")
            {
                Jump();
                //Debug.Log(m_Rb2D.velocity);
            }
            else if (Input.GetKeyDown(KeyCode.X) && gameObject.name == "Player_2")
            {
                Jump();
            }
            else if (Input.GetKeyDown(KeyCode.C) && gameObject.name == "Player_3")
            {
                Jump();
            }
            else if (Input.GetKeyDown(KeyCode.V) && gameObject.name == "Player_4")
            {
                Jump();
            }
            
        }
        //Debug.Log(m_VelocityX);
    }

    // Function for Distance from currPosition to endPosition
    float DistanceFromEnd()
    {
        m_DistanceFinishingLine = m_FinishingLineX - transform.position.x;
        return m_DistanceFinishingLine;
    }

    // ********************************************** //
    // Collision Events

    // Collision when first touched
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Speed Boost" || c.gameObject.tag == "Platforms" || c.gameObject.tag == "Collidables")
        {
            m_OnGround = true;

            if (c.gameObject.tag == "Collidables")
            {
                Vector3 Distance = transform.position - c.transform.position;
                if (Distance.y < 0.45f)
                    m_VelocityX = 0;
            }
            if(c.gameObject.tag == "Speed Boost")
            {
                m_Rb2D.AddForce(new Vector3(1000, 0, 0));
            }
        }
        else if (c.gameObject.tag == "Jumping Pad")
        {
            m_OnGround = false;
            m_Rb2D.AddForce(new Vector3(0, 1500, 0));
        }

        //if (c.gameObject.tag == "Downwards")
        //{
        //    m_VelocityX = 0;
        //}
        
        if(c.gameObject.tag == "Finish Line")
        {
            m_VelocityX = 0;
            m_IsFinished = true;
            //pass in player to the standings list
            m_ScoreInfo.Set(this.name, m_TimeTaken);
            ScoreManager.Instance.AddToList(m_ScoreInfo);

            Debug.Log("Time Taken Player " + name + " : " + m_TimeTaken + "s");
            Debug.Log("timeSinceLevelLoad: " + m_TimeTaken);
        }

        if(c.gameObject.tag == "Boundary")
        {
            //m_VelocityX = 0;
            //Get All Platforms in level 
            GameObject spawnObject = FindClosest("Platforms");
            this.transform.position = new Vector3(spawnObject.transform.position.x - 10 , spawnObject.transform.position.y + 5, spawnObject.transform.position.z);
        }
    }

    void OnCollisionStay2D(Collision2D c)
    {
        if (c.gameObject.tag == "Platforms" || c.gameObject.tag == "Downwards" || c.gameObject.tag == "Slow Down")
        {
            m_OnGround = true;
        }
    }

    // Collision when first exit
    void OnCollisionExit2D(Collision2D c)
    {
        if (!m_IsFinished)
            m_VelocityX = m_OriginalVelocityX;
        m_OnGround = false;
    }

    // ********************************************** //

    // ********************************************** //
    // Setter(s)
    public void SetRacePosition(int RacePosition)
    {
        m_RacePosition = RacePosition;
    }

    public void SetPlayerRigidBody(Rigidbody2D newRb2D)
    {
        m_Rb2D = newRb2D;
    }

    public void SetOnGround(bool newOnGround)
    {
        m_OnGround = newOnGround;
    }
    // ********************************************** //


    // ********************************************** //
    // Getter(s)
    public Rigidbody2D GetPlayerRigidBody()
    {
        return m_Rb2D;
    }

    public int GetRacePosition()
    {
        return m_RacePosition;
    }

    public float GetDistanceToEnd()
    {
        return m_DistanceFinishingLine;
    }

    public bool GetOnGround()
    {
        return m_OnGround;
    }


    // ********************************************** //

    // ********************************************** //
    // Functions
    public void Jump()
    {
        m_Rb2D.AddForce(new Vector2(0, m_JumpValue));
    }
    
    GameObject FindClosest(string tag)
    {
        GameObject closest = null;
        GameObject[] platforms;
        platforms = GameObject.FindGameObjectsWithTag(tag);

        float distance = Mathf.Infinity;

        Vector3 position = transform.position;
        position.x -= 2;

        foreach(GameObject go in platforms)
        {
            Vector3 diff = go.transform.position - position;
            float currentDistance = diff.sqrMagnitude;
            if(currentDistance < distance)
            {
                closest = go;
                distance = currentDistance;
            }
        }
        return closest;
    }

    // ********************************************** //
}

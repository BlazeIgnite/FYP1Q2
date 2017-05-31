using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


/*
    Script Name: Music Bar Logic
    Author: Nurhidayat

    Description: This Script handles the input and the score. 
*/
public class MusicBarLogic : MonoBehaviour {
        
    // Private Variables

    // To store the Music Notes when it spawns to know it is meant for this music bar
    List<GameObject> List_MusicNote;
    // Particle to instantiate (Not working for now, previously yes)
    ParticleSystem particle;

    // Privates used for scoring system

    // To get height and width
    RectTransform m_Rt;
    // 
    string[] s_ArrayString;
    float[] f_ArrayDistanceReq;
    float[] f_ArrayPoints;
    int i_Score;
    int[] i_ArrayScore;
    int[] i_ScoreNumbers;

    // This is used for calculations
    float f_TotalHeight;
    float f_CurrentTotalHeight;

    // Public Variables

    [Tooltip("Put Particle prefab here")]
    public ParticleSystem prefab;
    [Tooltip("Put the Feedback Text, Prefect, Great, etc.")]
    public GameObject[] TextPrefab;
    [Tooltip("Keybind, P1 Q, P2 Z, P3 P, P4 M")]
    public KeyCode Key;
    
    //Archived
    //GHScoreManager ghScoreManager;
    //public Text text;


    void Start()
    {
        particle = (ParticleSystem)Instantiate(prefab, transform.position, Quaternion.identity);
        particle.transform.SetParent(transform);
        
        // Archived
        //ghScoreManager = GHScoreManager.Instance;

        // Initialising 
        m_Rt = GetComponent<RectTransform>();
        List_MusicNote = new List<GameObject>();
        s_ArrayString = new string[5];
        f_ArrayPoints = new float[5];
        f_ArrayDistanceReq = new float[4];
        i_ArrayScore = new int[5];
        i_ScoreNumbers = new int[5];

        i_Score = 0;

        int value = 0;
        for (int i = 0; i < f_ArrayPoints.Length; i++)
        {
            f_ArrayPoints[i] = value;
            value += 5;
        }

        // The text used for the Game
        s_ArrayString[0] = "Perfect";
        s_ArrayString[1] = "Great";
        s_ArrayString[2] = "OK";
        s_ArrayString[3] = "Bad";
        s_ArrayString[4] = "Miss";
        
        // Score for each tier
        i_ArrayScore[0] = 20;
        i_ArrayScore[1] = 15;
        i_ArrayScore[2] = 10;
        i_ArrayScore[3] = 5;
        i_ArrayScore[4] = 0;

        // The requirement to achieve the tier and score
        // Missing one cause it will be a miss
        f_ArrayDistanceReq[0] = 0.9f;
        f_ArrayDistanceReq[1] = 0.75f;
        f_ArrayDistanceReq[2] = 0.5f;
        f_ArrayDistanceReq[3] = 0.25f;

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(Key))
        {
            UpdateGame();
        }
	}

    
    // Methods

    /*
        Function Name: On Trigger Exit 2D
        Params: Collider2D
        Return: 

        Description: Unity function for exit event
    */
    void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject == List_MusicNote[0])
        {
            Miss();
        }
    }

    // Archives
    //void OnTriggerStay2D(Collider2D c)
    //{
    //    if (c.gameObject.tag == "Music Note")
    //    {
    //        if (Input.GetKeyDown(Key))
    //        {
    //            f_DistanceY = c.transform.position.y - transform.position.y;
    //            UpdateGame(c.gameObject, f_DistanceY);

    //            if (!b_GameTimerIsStarted)
    //            {
    //                b_GameTimerIsStarted = true;
    //            }

    //            switch (Key)
    //            {
    //                case KeyCode.Q:
    //                    {
    //                        for (int i = 0; i < f_ArrayDistanceReq.Length; i++)
    //                        {   
    //                            if (f_DistanceY < f_ArrayDistanceReq[i] && f_DistanceY > -f_ArrayDistanceReq[i])
    //                            {
    //                                ghScoreManager.AddScore(new GHScoreInfo(1, i_ArrayScore[i]));
    //                                DataTransfer.Instance.AddScore(new GHScoreInfo(1, i_ArrayScore[i]));
    //                            }
    //                        }
    //                        break;
    //                    }
    //                case KeyCode.Z:
    //                    {
    //                        for(int i = 0; i < f_ArrayDistanceReq.Length; i++)
    //                        {
    //                            if(f_DistanceY < f_ArrayDistanceReq[i] && f_DistanceY >  -f_ArrayDistanceReq[i])
    //                            {
    //                                ghScoreManager.AddScore(new GHScoreInfo(2, i_ArrayScore[i]));
    //                                DataTransfer.Instance.AddScore(new GHScoreInfo(2, i_ArrayScore[i]));
    //                            }
    //                        }
    //                        break;
    //                    }
    //                case KeyCode.P:
    //                    {
    //                        for (int i = 0; i < f_ArrayDistanceReq.Length; i++)
    //                        {
    //                            if (f_DistanceY < f_ArrayDistanceReq[i] && f_DistanceY > -f_ArrayDistanceReq[i])
    //                            {
    //                                ghScoreManager.AddScore(new GHScoreInfo(3, i_ArrayScore[i]));
    //                                DataTransfer.Instance.AddScore(new GHScoreInfo(3, i_ArrayScore[i]));
    //                            }
    //                        }
    //                        break;
    //                    }
    //                case KeyCode.M:
    //                    {
    //                        for (int i = 0; i < f_ArrayDistanceReq.Length; i++)
    //                        {
    //                            if (f_DistanceY < f_ArrayDistanceReq[i] && f_DistanceY > -f_ArrayDistanceReq[i])
    //                            {
    //                                ghScoreManager.AddScore(new GHScoreInfo(4, i_ArrayScore[i]));
    //                                DataTransfer.Instance.AddScore(new GHScoreInfo(4, i_ArrayScore[i]));
    //                            }
    //                        }
    //                        break;
    //                    }
    //            }
    //        }
    //    }
    //}


    /*
        Function Name: Update Game
        Params: void
        Return: 

        Description: Calculate the score after press 
    */
    void UpdateGame()
    {
        if (List_MusicNote.Count <= 0)
            return;


        if (f_TotalHeight != m_Rt.rect.height + List_MusicNote[0].GetComponent<RectTransform>().rect.height)
            f_TotalHeight = m_Rt.rect.height + List_MusicNote[0].GetComponent<RectTransform>().rect.height;

        float temp = List_MusicNote[0].transform.position.y;

        // The one with the bigger value should be the one at the front of equation
        if (temp > transform.position.y)
            f_CurrentTotalHeight = (temp - transform.position.y) + m_Rt.rect.height;
        else
            f_CurrentTotalHeight = (transform.position.y - temp) + m_Rt.rect.height;

        
        float overlap = f_TotalHeight - f_CurrentTotalHeight;
        float percentage = overlap / m_Rt.rect.height;

        if (percentage < 0)
            percentage = -percentage;

        if (f_CurrentTotalHeight > f_TotalHeight || percentage > 1 || percentage < -1)
        {
            // Miss the block unlike how the bullet miss Mr Kennedy
            Miss();
            return;
        }

        // Gets the String of how well the play did
        string Score = GetScore(percentage);

        // Adds score and instantiate the text
        SpawnFeedBack(Score);

        // Destroys the Music Note
        DestroyMusicNote();
    }


    // Methods

    /*
        Function Name: Miss
        Params: void
        Return: 

        Description: Use this when player misses
    */
    void Miss()
    {
        SpawnFeedBack("Miss");
        DestroyMusicNote();
    }

    /*
        Function Name: Add Music Note
        Params: GameObject
        Return: 

        Description: Add Music Note to the list
    */
    public void AddMusicNote(GameObject go)
    {
        List_MusicNote.Add(go);
    }

    /*
        Function Name: Remove Music Note
        Params: GameObject
        Return:

        Description: Removes Music Note and is a Miss, Wrong Method
    */
    public void RemoveMusicNote(GameObject go)
    {
        SpawnFeedBack("Miss");
        List_MusicNote.Remove(go);
    }


    /*
        Function Name: Destroy Music Note (Overloaded)
        Params: GameObject
        Return:
         
        Description: Destroys the Music Note along and is for miss
    */
    // this is needed 
    public void DestroyMusicNote(GameObject go)
    {
        SpawnFeedBack("Miss");
        List_MusicNote.Remove(go);
        go.GetComponent<MusicNoteLogic>().Delete();
    }

    /*
        Function Name: Destroy Music Note
        Params:
        Return:
         
        Description: Use this to Destroy the music note
    */
    void DestroyMusicNote()
    {
        GameObject GO = List_MusicNote[0];
        List_MusicNote.Remove(GO);
        GO.GetComponent<MusicNoteLogic>().Delete();
    }

    /*
        Function Name: Spawn Feedback
        Params: string
        Return:

        Description: This Function instantiates the text and also adds score
    */
    void SpawnFeedBack(string text)
    {
        // Instantiate The Texts
        GameObject GO = null;

        if (transform.childCount > 1)
            Destroy(transform.GetChild(1).gameObject);

        // Can do a loop for this honestly
        if (text == s_ArrayString[0])
        {
            // Perfect
            GO = (GameObject)Instantiate(TextPrefab[0], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            i_Score += i_ArrayScore[0];
            i_ScoreNumbers[0]++;
            if (gameObject.GetComponent<AnimatorChanger>() != null)
            {
                gameObject.GetComponent<AnimatorChanger>().ChangeAnimator(2);
                Debug.Log("PERFECT");
            }
        }
        else if (text == s_ArrayString[1])
        {
            // Great
            GO = (GameObject)Instantiate(TextPrefab[1], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            i_Score += i_ArrayScore[1];
            i_ScoreNumbers[1]++;
            if (gameObject.GetComponent<AnimatorChanger>() != null)
            {
                gameObject.GetComponent<AnimatorChanger>().ChangeAnimator(0);
                Debug.Log("GREAT");
            }
        }
        else if (text == s_ArrayString[2])
        {
            // OK
            GO = (GameObject)Instantiate(TextPrefab[2], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            i_Score += i_ArrayScore[2];
            i_ScoreNumbers[2]++;
            if (gameObject.GetComponent<AnimatorChanger>() != null)
            {
                gameObject.GetComponent<AnimatorChanger>().ChangeAnimator(0);
                Debug.Log("OK");
            }
        }
        else if (text == s_ArrayString[3])
        {
            // Bad
            GO = (GameObject)Instantiate(TextPrefab[3], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            i_Score += i_ArrayScore[3];
            i_ScoreNumbers[3]++;
            if (gameObject.GetComponent<AnimatorChanger>() != null)
            {
                gameObject.GetComponent<AnimatorChanger>().ChangeAnimator(1);
                Debug.Log("BAD");
            }
        }
        else
        {
            // Miss
            GO = (GameObject)Instantiate(TextPrefab[4], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            i_Score += i_ArrayScore[4];
            i_ScoreNumbers[4]++;
            if (gameObject.GetComponent<AnimatorChanger>() != null)
            {
                gameObject.GetComponent<AnimatorChanger>().ChangeAnimator(1);
                Debug.Log("MISS");
            }
        }

        // Setting parent to the music bar
        GO.transform.SetParent(transform);
        GO.transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
    }


    // Getters()
    /*
        Function Name: Get Score
        Params: float
        Return: string

        Description: Returns the text score
    */
    string GetScore(float percentage)
    {
        for (int i = 0; i < f_ArrayDistanceReq.Length; i++)
        {
            if (percentage > f_ArrayDistanceReq[i])
            {
                return s_ArrayString[i];
            }
        }
        return null;
    }

    /*
        Function Name: Get Max Score
        Params: void 
        Return: int

        Description: Returns Max score of one note
    */
    public int GetMaxScore()
    {
        return i_ArrayScore[0];
    }

    /*
        Function Name: Get player's scpre
        Params: void
        Return: int

        Description: Returns currect score of player
    */
    public int GetScore()
    {
        return i_Score;
    }
    
    // Archives
    //void UpdateGame(GameObject go)
    //{
    //    text.text = s_ArrayString[4];
    //    DestroyMusicNote(go);
    //}
    //void UpdateGame(GameObject go, float distance)
    //{
    //    text.text = TextSystem(distance);
    //    UpdateBossHealth(text.text);
    //    DestroyMusicNote(go);
    //}
    //void UpdateBossHealth(string text)
    //{
    //    int i = 0;
    //    for (int HP = 20; i < s_ArrayString.Length; i++, HP -= 5)
    //    {
    //        if (text == s_ArrayString[i])
    //        {
    //            Game.UpdateGameInfo(HP);
    //            particle.Emit(HP / 4);
    //            return;
    //        }
    //    }
    //}
    //string TextSystem(float distance)
    //{
    //    int i = 0;
    //    for (; i < f_ArrayDistanceReq.Length; i++)
    //    {
    //        if (distance < f_ArrayDistanceReq[i] && distance > -f_ArrayDistanceReq[i])
    //        {
    //            return s_ArrayString[i];
    //        }
    //    }
    //    return s_ArrayString[i];
    //}
}

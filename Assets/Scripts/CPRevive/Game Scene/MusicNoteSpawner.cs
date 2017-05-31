using UnityEngine;
using System;
using System.Collections;

/*
    Script Name: Music Note Spawner
    Author: Nurhidayat, Wayne

    Description: This script is in charge of spawning the music notes for the player
*/
public class MusicNoteSpawner : MonoBehaviour {

    // Private variables
    System.Random Random;
    GHGameLogic GameLogic;

    float f_Timer;
    float f_SpawnTime = 0.6f;
    float f_SpawnDelay = 2f;
    float f_SpawnDelayTimer;
    int i_numBeatsLeft;
    int i_spawnCount;
    int i_randValue;
    bool b_Spawning;

    enum COMBO_TYPE
    {
        COMBO_PLACEHOLDER,
        COMBO_PLACEHOLDER_2,
        // only add combos after this
        COMBO_DOUBLE,
        COMBO_TRIPLE,
        COMBO_QUAD,
        COMBO_PENTA,
    }

    COMBO_TYPE combo_state;


    // Public variables

    [Tooltip("The Music Bar that this spawner is for")]
    public MusicBarLogic MusicBar;
    [Tooltip("Insert the prefab for music note")]
    public Transform t_MusicNote;

    
	// Use this for initialization
	void Start () {
        Random = new System.Random();
        GameLogic = GameObject.Find("Gameplay Logics").GetComponent<GHGameLogic>();


        f_Timer = 0;
        f_SpawnDelayTimer = 0;
        i_randValue = 0;
        i_spawnCount = 0;
        b_Spawning = false;
        //Set Default Combo State
        combo_state = COMBO_TYPE.COMBO_DOUBLE;

        //Set number of beats left for each player
        if (f_SpawnTime == 0)
        {
            f_SpawnTime = 0.6f;
        }

        // It needs to know how many notes it needs to spawn
        i_numBeatsLeft = (int)(GameLogic.GetGameTime() / f_SpawnTime);

        // Tells the Gameplay how much score a player can get in a game
        GameLogic.SetMaxScore(i_numBeatsLeft * MusicBar.GetMaxScore());
	}

    // Update is called once per frame
    void Update()
    {
        f_Timer += Time.deltaTime;
        SpawnNote();
    }

    // Setters

    /*
        Function Name: Set Music Bar Logic
        Params: MusicBarLogic
        Return: 

        Description: Sets the Music bar script to the member
    */
    public void SetMusicBarLogic(MusicBarLogic Bar)
    {
        MusicBar = Bar;
    }

    /*
        Function Name: Spawn Note
        Params: void
        Return: 

        Description: Spawns note if the conditions are met 
    */
    void SpawnNote()
    {
        if (f_Timer > f_SpawnTime && i_numBeatsLeft > 0)
        {
            f_Timer = 0;
            i_numBeatsLeft--;

            // Spawning
            GameObject go = (GameObject)Instantiate(t_MusicNote.gameObject, transform.position, Quaternion.identity);
            go.transform.SetParent(transform);

            // Has to be done to prevent the number from going weird
            go.transform.localScale = new Vector3(1, 1, 1);
            // For Debugging purposes
            go.name = "Note " + ++i_spawnCount;
            // Assign Music Note to the bar
            MusicBar.AddMusicNote(go);
        }
    }

    /*
       Function Name : SpawnNote(int combo)
       Author : Wayne
       params : int
       Return : void
    
       Description : FAR 𝐅𝐔𝐂𝐊𝐈𝐍 𝐒𝐔𝐏𝐄𝐑𝐈𝐎𝐑 FUNCTION COMPARED TO THE ONE ABOVE
       BASICALLY I DO THE 𝓔𝓧𝓐𝓒𝓣 𝓢𝓐𝓜𝓔 𝓣𝓗𝓘𝓝𝓖 BY SPAWNING FUCKING MUSIC NOTES 
       𝐁𝐔𝐓𝐁𝐔𝐓𝐁𝐔𝐓𝐁𝐔𝐓𝐁𝐔𝐓𝐁𝐔𝐓𝐁𝐔𝐓𝐁𝐔𝐓𝐁𝐔𝐓𝐁𝐔𝐓𝐁𝐔𝐓𝐁𝐔𝐓𝐁𝐔𝐓𝐁𝐔𝐓𝐁𝐔𝐓𝐁𝐔𝐓𝐁𝐔𝐓𝐁𝐔𝐓𝐁𝐔𝐓
       I SPAWN THEM, IN 𝐂𝐎𝐌𝐁𝐎𝐒 of (2-5)

       NOW THE ONLY 𝑓𝑢𝑐𝑘𝑖𝑛𝑔 𝑟𝑒𝑎𝑠𝑜𝑛 IM NOT USING THIS IS BECAUSE THE HEART FOUNDATION 
       DOESNT WANT 𝐂𝐎𝐎𝐋 𝐁𝐎𝐌𝐁 𝐀𝐒𝐒 𝐂𝐎𝐌𝐁𝐎𝐒 
    */
    void SpawnNote(int combo)
    {
        //if(f_SpawnDelayTimer > f_SpawnDelay && !b_Spawning)
        //{
        //    b_Spawning = true;
        //}
        //if(b_Spawning)
        //{
        //    if (f_Timer > f_SpawnTime)
        //    {
        //        Instantiate(t_MusicNote.gameObject, transform.position, Quaternion.identity);
        //        MusicBar.AddMusicNote(t_MusicNote.gameObject);
        //        f_Timer = 0;
        //        spawnCount++;
        //    }
        //    if(spawnCount == combo)
        //    {
        //        f_SpawnDelayTimer = 0;
        //        b_Spawning = false;
        //        spawnCount = 0;
        //    }

        //}

        // Old Code in if condition
        // && spawnCount < 50
        if (f_Timer > f_SpawnTime)
        {
            GameObject go = (GameObject)Instantiate(t_MusicNote.gameObject, transform.position, Quaternion.identity);
            go.transform.SetParent(transform);
            go.transform.localScale = new Vector3(1, 1, 1);
            go.name = "Note " + ++i_spawnCount;
            MusicBar.AddMusicNote(go);
            f_Timer = 0;
        }
    }
    /*
       Function Name : Ser Combo
       Author : Wayne
       params : null
       Return : void
    
       Description : Uses RNG to get a combo for SpawnNote(int combo) to use 
    */
    void SetCombo()
    {
        i_randValue = Random.Next(1, 37);

        if (!b_Spawning)
        {
            if (i_randValue < 2)
            {
                combo_state = COMBO_TYPE.COMBO_PENTA;
            }
            else if (i_randValue > 2 && i_randValue <= 7)
            {
                combo_state = COMBO_TYPE.COMBO_QUAD;
            }
            else if (i_randValue > 7 && i_randValue <= 17)
            {
                combo_state = COMBO_TYPE.COMBO_TRIPLE;
            }
            else if (i_randValue > 17 && i_randValue <= 37)
            {
                combo_state = COMBO_TYPE.COMBO_DOUBLE;
            }
        }
        SpawnNote((int)combo_state);
    }
}



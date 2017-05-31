using UnityEngine;
using System.IO.Ports;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class PlayerController : MonoBehaviour
{
    // Private Variables
    private LobbySystem ls;
    private SerialPortUnity sp;

    private GameObject [] playerList;

    public bool allDone;
    // SerialPort sp;
    // Use this for initialization
    void Start ()
    {

        playerList = GameObject.FindGameObjectsWithTag("Player");
        sp = SerialPortUnity.Instance;

        ls = GameObject.Find("MasterLevelController").GetComponent<LobbySystem>();
        allDone = false;

        //serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
        //serialListener = GameObject.Find("SerialListener").GetComponent<SerialListener>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * Serial Controller Input and Data Parsing should be done here
         * TO DO
         */

        if (Input.GetKeyDown(KeyCode.Z))
            ls.SetPlayerActive(0, 1);
        else if (Input.GetKeyDown(KeyCode.X))
            ls.SetPlayerActive(1, 1);
        else if (Input.GetKeyDown(KeyCode.C))
            ls.SetPlayerActive(2, 1);
        else if (Input.GetKeyDown(KeyCode.V))
            ls.SetPlayerActive(3, 1);

       foreach(GameObject g in playerList)
        {
            if(g.GetComponent<PlayerInformation>().m_IsFinished)
            {
                allDone = true;
            }
            else
            {
                allDone = false;
                break;
            }
        }

        string serialData = sp.SerialData();
        // if there is no data 
        if (serialData == null)
            return;
        //There is data
        else
        {
            if (serialData.Length <= 0)
                return;

            //ST4 xxxx
            string inputData = serialData.Substring(4);
            //iterate through data to get the place of "1"
            for (int i = 0; i < inputData.Length; i++)
            {
                if (inputData[i] == '1')
                {
                    if (ls.GetLoadedGame())
                    {
                        if (playerList[i] == null)
                            continue;

                        if (playerList[i].GetComponent<PlayerInformation>().GetOnGround())
                        {
                            playerList[i].GetComponent<PlayerInformation>().Jump();
                        }
                    }
                    else
                    {
                        ls.SetPlayerActive(i, 1);
                    }
                }
            }
        }

        
        


        // Old codes
        //this.transform.Translate(new Vector3(0.1f, 0, 0));
        //if (m_OnGround)
        //{
        //    if (Input.GetKeyDown(KeyCode.Keypad1) && name == "Player_1")
        //    {
        //        m_Rb2D.AddForce(new Vector3(0, 300, 0)); 
        //    }
        //    else if(Input.GetKeyDown(KeyCode.Keypad2) && name == "Player_2")
        //    {
        //        m_Rb2D.AddForce(new Vector3(0, 300, 0));
        //    }
        //    else if (Input.GetKeyDown(KeyCode.Keypad3) && name == "Player_3")
        //    {
        //        m_Rb2D.AddForce(new Vector3(0, 300, 0));
        //    }
        //    else if (Input.GetKeyDown(KeyCode.Keypad4) && name == "Player_4")
        //    {
        //        m_Rb2D.AddForce(new Vector3(0, 300, 0));
        //    }
        //}
    }

    public void SortPlayersInArray()
    {
        bool[] temparray = ls.GetArrayOfPlayerActive();
        GameObject tempo = GameObject.Find("Player_1");

        playerList = new GameObject[4];

        GameObject[] tempGOarray = GameObject.FindGameObjectsWithTag("Player");
        playerList = tempGOarray;

        // Has to do this or the playerlist array might change in size
        for (int i = 0; i < tempGOarray.Length; i++)
        {
            playerList[i] = tempGOarray[i];
        }

        // if both same length
        if (playerList.Length == tempGOarray.Length)
            return;

        // Sorting
        for (int i = 0; i < temparray.Length; i++)
        {
            if (temparray[i])
            {
                // Finding thru name
                string playernametofind = "Player_" + (i + 1);
                for (int j = 0; j < playerList.Length; j++)
                {
                    if (playerList[j].name == playernametofind)
                    {
                        GameObject temp = playerList[j];
                        playerList[j] = playerList[i];
                        playerList[i] = temp;
                        break;
                    }
                }
            }
        }

    }
}

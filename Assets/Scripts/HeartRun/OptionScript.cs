using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;



public class OptionScript : MonoBehaviour {

    public InputField baudInput, comInput;
	// Use this for initialization
	void Start () {
        var baud_Event = new InputField.SubmitEvent();
        var com_Event = new InputField.SubmitEvent();
        //baud_Event.AddListener(SetBaudRate);
        //com_Event.AddListener(SetCOMPort);
        baudInput.onEndEdit = baud_Event;
        comInput.onEndEdit = com_Event;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //private void SetBaudRate(string _baudRate)
    //{
    //    SerialPortUnity.SetBaudRate(Int32.Parse(_baudRate));
    //}
    //private void SetCOMPort(string _port)
    //{
    //    SerialPortUnity.SetPortName(_port);
    //}
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
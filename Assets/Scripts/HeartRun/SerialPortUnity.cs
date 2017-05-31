using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System;
/*
using System.At.Max
 */

public class SerialPortUnity : Singleton<SerialPortUnity> {
    protected SerialPortUnity() { }
    public static SerialPort sp;


    //set default values
    private string portName = "COM4";
    private int baudRate = 115200;
    string prevMessage = "";

    // Use this for initialization
    void Start() {
        
        sp = new SerialPort(portName, baudRate);
        Main();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Port Name: " + portName);
        Debug.Log("Baud Rate: " + baudRate);
        //Read();
    }

    public static void Read()
    {
        try
        {
            string message = sp.ReadLine();
            //Debug.Log(message);
        }
        catch (TimeoutException) { }
    }
    public string SerialData()
    {
        try
        {
            string message = sp.ReadLine();
            if(message == prevMessage)
            {
                return null;
            }
            else
            {
                Debug.Log(message);
                prevMessage = message;
                return message;
            }
            
        }
        catch (TimeoutException) { }
        return null;
    }
    public void Main()
    {
        if (sp != null)
        {
            //Thread readThread = new Thread(Read);
            //set shit
            sp.DtrEnable = true;
            sp.RtsEnable = true;

            //sp.PortName = "COM4";
            //sp.BaudRate = 115200;

            sp.ReadTimeout = 3;

            sp.Open();
            //readThread.Start();
            Debug.Log("SerialPort Init");
        }
        else
        {
            Debug.Log("Serial Port Controller doesnt exist");
        }
    }

    public void SetPortName(string _port)
    {
        portName = _port;
    }
    public void SetBaudRate(int _baudrate)
    {
        baudRate = _baudrate;
    }

}

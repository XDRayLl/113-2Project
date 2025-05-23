using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Android;
using System.IO.Ports;
using System;

public class WaveSpeed_Arduino : MonoBehaviour
{
    public SerialPort sp = new SerialPort("com5", 38400);//Mega com5
    //public SerialPort sp4 = new SerialPort("com4", 38400);
    private Thread serialThread;
    public float WaveVector;
    public string wavespeed;
    public float basic =0;
    public float gap=0;


    // Start is called before the first frame update


    // Update is called once per frame


    // Start is called before the first frame update
    void Start()
    {

        try
        {
            sp.Open();
            //sp4.Open();
            serialThread = new Thread(ReadSerialData);
            serialThread.Start();
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to open Serial Port: " + e.Message);
        }

    }

    void Update()
    {

    }

    private void ReadSerialData()
    {
        while (true)
        {
            if (sp.IsOpen)
            {
                wavespeed = sp.ReadLine();
                WaveVector = float.Parse(wavespeed);
                Debug.Log("wavespeed:" + WaveVector);
                gap = WaveVector - basic;
                Debug.Log("Gap:" + gap);
                basic = WaveVector;
            }
            Thread.Sleep(10); // 控制讀取頻率，避免過度占用CPU
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.IO.Ports;

public class Hitten_Arduino : MonoBehaviour
{
    //public SerialPort sp = new SerialPort("com5", 38400);//Mega com5
    public SerialPort sp = new SerialPort("com3", 38400);//
    private Thread serialThread;

    public string hit;

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
                hit = sp.ReadLine();
                Debug.Log("Hitten:" + hit);
            }
            Thread.Sleep(10); // 控制讀取頻率，避免過度占用CPU
        }
    }
}

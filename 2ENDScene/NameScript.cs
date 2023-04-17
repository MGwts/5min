using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Fungus;

public class NameScript : MonoBehaviour
{
    string machine = Environment.MachineName;
    string user = Environment.UserName;
    [SerializeField] Flowchart flowchart = null;

    // Start is called before the first frame update
    void Start()
    {
        Main();
        flowchart.SetStringVariable("name", user);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Main()
    {
        string machine = Environment.MachineName;
        string user = Environment.UserName;

        Debug.Log(machine);
        Debug.Log(user);
    }
}

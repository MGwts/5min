using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class room1notesButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void notesButtonDown()
    {
        room1notes.button = true;
    }

    public void notesButtonUp()
    {
        room1notes.button = false;
    }
}

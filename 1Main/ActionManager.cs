using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class ActionManager : MonoBehaviour
{
    [SerializeField] Fungus.Flowchart flowchart;
    [SerializeField] GameObject player;
    //[SerializeField] GameObject button;
    public static bool Action;
    bool text;

    // Start is called before the first frame update
    void Start()
    {
        //flowchart.GetBooleanVariable("Text");

    }

    // Update is called once per frame
    void Update()
    {
        text = flowchart.GetBooleanVariable("Text");

        //if (Input.GetKeyDown("z") == true){
        //     ActionButtonDown();
        // }

        if (text == false)
        {
            GetComponent<Button>().interactable = true;

            if (Input.GetKeyDown(KeyCode.Return) == true) ActionButtonDown();
            if (Input.GetKeyUp(KeyCode.Return) == true) ActionButtonUp();
        }

        if (text == true) GetComponent<Button>().interactable = false;
  
    }

    public void ActionButtonDown()
    {
        Action = true;
        player.GetComponent<Rigidbody2D>().WakeUp();
        Debug.Log("actionButton");
    }

    public void ActionButtonUp()
    {
        Action = false;
    }
}

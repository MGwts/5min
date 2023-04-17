using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class room1 : MonoBehaviour
{
    [SerializeField] Flowchart ResultLog = null;
    public  GameObject[] events = new GameObject[i];
    static public int i;

    //public GameObject player;
    //Rigidbody2D playerRb;

    // Start is called before the first frame update
    void Start()
    {
        //playerRb = this.gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log("colcol");

        for (int i = 0; i < events.Length; i++) {
            if (col.gameObject == events[i] && ActionManager.Action == true){

                ResultLog.SendFungusMessage($"E{i}");
                Debug.Log("event");
            }
        }

    }
}

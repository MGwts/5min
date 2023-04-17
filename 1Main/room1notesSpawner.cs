using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class room1notesSpawner : MonoBehaviour
{
    [SerializeField] GameObject skillpanel;
    [SerializeField] Flowchart ResultLog = null;
    public GameObject notes;
    GameObject notesClone;
    int a = 0;
    static public int notescount;
    //static public int stage = 1;

    // Start is called before the first frame update
    void Start()
    {
        notescount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (a == 0)  spawn();
        if (notescount == 5) notesDestro();
    }

    void spawn()
    {
        var parent = skillpanel.transform;
        float spx = notes.transform.position.x - this.transform.position.x;
        float spy = notes.transform.position.y - this.transform.position.y;

        for (int i=0; i < 7; i++){

            float rotz = Random.Range(-180.0f, 180.0f);
            Quaternion rot = Quaternion.Euler(0, 0, rotz);
            Quaternion q = this.transform.rotation;
            this.transform.rotation = q * rot;
            Debug.Log($"roty = {rotz}");

            notesClone = Instantiate(notes, this.transform.position + this.transform.right*spx + this.transform.up*spy, this.transform.rotation, parent) as GameObject;
            //notesClone = Instantiate(notes, this.transform.position + new Vector3(spx, spy, 0), this.transform.rotation, parent) as GameObject;
        Debug.Log("spawn!");
            i++;
        }
        a = 1;
    }

    public void notesDestro()
    {
        ResultLog.SendFungusMessage("sss");
        skillpanel.gameObject.SetActive(false);
    }

}

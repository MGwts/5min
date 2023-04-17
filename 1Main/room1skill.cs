using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class room1skill : MonoBehaviour
{
    [SerializeField] GameObject play;   //play‚Ì‰~‰^“®
    [SerializeField] GameObject Ymove;   //play‚Ì‰~‰^“®
    public float angle; //play‚Ì‰~‰^“®

    [SerializeField] GameObject Skillpanel;
    bool panelAct;
    [SerializeField] Flowchart ResultLog = null;

    [SerializeField] GameObject amipanel;


    // Start is called before the first frame update
    void Start()
    {
        Skillpanel.gameObject.SetActive(false);
        amipanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        play.transform.RotateAround(Ymove.transform.position, Vector3.forward, -angle * Time.deltaTime); //play‚Ì‰~‰^“®

        panelAct = Skillpanel.activeSelf;
        //if (panelAct == true) PCskill();
    }

    void SkillKey()
    {
        Skillpanel.gameObject.SetActive(true);
    }

    void PCskill()
    {
            ResultLog.SendFungusMessage("sss");
            Skillpanel.gameObject.SetActive(false);
    }

    public void skillcancel()
    {
        ResultLog.SetBooleanVariable("Text", false);
        Skillpanel.gameObject.SetActive(false);
    }

    public void amidaON()
    {
        amipanel.gameObject.SetActive(true);
    }

    public void amidaOFF()
    {
        amipanel.gameObject.SetActive(false);
    }


}

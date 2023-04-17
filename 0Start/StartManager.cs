using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;
using Unity.UI;

public class StartManager : MonoBehaviour
{
    [SerializeField] Flowchart ResultLog = null;
    // public SaveManager cs;
    //public Fungus.Flowchart flowchart;
    public Scene MainScene;
    public GameObject CtrlPanel;
    bool CtrlAct;

    // Start is called before the first frame update
    void Start()
    {
        CtrlPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CtrlAct = CtrlPanel.activeSelf;
    }

    public void StratButton()
    {
        if (CtrlAct == false) {
            ResultLog.SendFungusMessage("Start");
        }
    }

    public void EXButton()
    {
        if(CtrlAct == false){
            CtrlPanel.SetActive(true);
        }
    }

    public void ReturnButton()
    {
        CtrlPanel.SetActive(false);
    }
}

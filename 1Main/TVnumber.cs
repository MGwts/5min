using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
using System;


public class TVnumber : MonoBehaviour
{
    [SerializeField] Flowchart ResultLog = null;
    [SerializeField] GameObject[] TVnum = new GameObject[3];
    [SerializeField] GameObject[] TVnumTri = new GameObject[3];
    [SerializeField] int[] Answer730 = new int[3];
    [SerializeField] int[] Answer815 = new int[3];
    [SerializeField] int[] Answer412 = new int[3];
    int[] AnswerTime = new int[3];

    public GameObject TVpanel;
    private int[] number = {0, 0, 0};
    bool core = false;
    int i = 0;
    bool TVpanelAct;

    // Start is called before the first frame update
    void Start()
    {
       // TVpanel = GameObject.Find($"TVKey");
        TVpanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TVpanelAct = TVpanel.activeSelf;

        if (TVpanelAct == true){
            TVnumPC();
        }
    }

    void TVnumberKey()
    {
        TVpanel.gameObject.SetActive(true);

        for(int i = 0; i < 3; i++){
            TVnum[i].GetComponent<Button>().interactable = true;
        }

       for (int i = 0; i < 3; i++){
           TVnumTri[i].gameObject.SetActive(false);
       }
    }

    //--------------スマホ、マウス操作-------------------------------
    public void TVnumButtn1(int num)
    {
        i = num;
        TVnumTriManager();

        if (number[num] < 9){
            number[num]++;
        }else if (number[num] == 9) {
            number[num] = 0;
        }
        TVnum[num].GetComponentInChildren<Text>().text = number[num].ToString();
    }

    public void TVnumOK()
    {
        for (int i = 0; i < 3; i++){
            TVnum[i].GetComponent<Button>().interactable = false;
        }

        NowTime();

        for (int r = 0; r < number.Length; r++){
            if (number[r] == Answer730[r] ) {
                if (r == 2) core = true;
                ResultLog.SetIntegerVariable("TV", 730);

            } else if (number[r] == Answer815[r]){
                if (r == 2) core = true;
                ResultLog.SetIntegerVariable("TV", 815);

            }else if (number[r] == Answer412[r]){
                if (r == 2) core = true;
                ResultLog.SetIntegerVariable("TV", 412);

            }else if (number[r] == AnswerTime[r]){
                if (r == 2) core = true;
                ResultLog.SetIntegerVariable("TV", 777);

            }else{
                core = false;
                break;
            }
        }

        if (core == false) {
            ResultLog.SendFungusMessage("vvv");

        }else {
            ResultLog.SendFungusMessage("ttt");
        }

        TVpanel.gameObject.SetActive(false);
    }

    void NowTime()
    {
        AnswerTime[0] = (System.DateTime.Now.Year / 10) %10;
        AnswerTime[1] = System.DateTime.Now.Month % 10;
        AnswerTime[2] = System.DateTime.Now.Day %10;
        Debug.Log($"Day:{AnswerTime[0]}, Hour:{AnswerTime[1]}, min:{AnswerTime[2]}");
    }

    //--------------------------PCキー操作----------------------------------
    void TVnumPC()
    {
        if (Input.GetKeyDown("right") == true) {
            if (i < 2 && i >= 0) {
                number[i] = number[i++];
                TVnumTriManager();
            }
        }

        if (Input.GetKeyDown("left") == true) {
            if (i > 0 && i <= 2) {
                number[i] = number[i--];
                TVnumTriManager();
            }
        }

        if (Input.GetKeyDown("up") == true){
            if (number[i] < 9) {
                number[i]++;
                TVnumTriManager();

            } else if (number[i] == 9){
                number[i] = 0;
            }
        }

        if (Input.GetKeyDown("down") == true){
            if (number[i] > 0){
                number[i]--;
                TVnumTriManager();

            }else if (number[i] == 0){
                number[i] = 9;
            }
        }

        for (int i = 0; i < 3; i++) {
            TVnum[i].GetComponentInChildren<Text>().text = number[i].ToString();
        }

        if (Input.GetKeyDown(KeyCode.Return) == true){
            TVnumOK();
        }
    }

    void TVnumTriManager()
    {
        TVnumTri[i].gameObject.SetActive(true);

        if (i == 0){
            TVnumTri[1].gameObject.SetActive(false);
            TVnumTri[2].gameObject.SetActive(false);

        }else if (i == 1) {
            TVnumTri[2].gameObject.SetActive(false);
            TVnumTri[0].gameObject.SetActive(false);

        }
        else if (i == 2) {
            TVnumTri[0].gameObject.SetActive(false);
            TVnumTri[1].gameObject.SetActive(false);
        }
    }
}

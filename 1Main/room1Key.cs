using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;


public class room1Key : MonoBehaviour
{
    [SerializeField] Flowchart ResultLog = null;
    [SerializeField] GameObject[] TVnum = new GameObject[4];
    [SerializeField] int[] correctAnswer = new int[4];
    [SerializeField] GameObject[] TVnumTri = new GameObject[4];

    public GameObject TVpanel;
    private int[] number = {0, 0, 0, 0};
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

            if (number[0] == correctAnswer[0] && number[1] == correctAnswer[1] && number[2] == correctAnswer[2] && number[3] == correctAnswer[3]){
                core = true;
            }
        }

    }

    void TVnumberKey()
    {
        TVpanel.gameObject.SetActive(true);

        for(int i = 0; i < 4; i++){
            TVnum[i].GetComponent<Button>().interactable = true;
        }

       for (int i = 0; i < 4; i++){
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
        for (int i = 0; i < 4; i++){
            TVnum[i].GetComponent<Button>().interactable = false;
        }

        if(core == false) {
            ResultLog.SendFungusMessage("vvv");

        }else {
            ResultLog.SetBooleanVariable("room1KEY", true);
            ResultLog.SendFungusMessage("kkk");
        }

        TVpanel.gameObject.SetActive(false);
    }

    //--------------------------PCキー操作----------------------------------
    void TVnumPC()
    {
        if (Input.GetKeyDown("right") == true) {
            if (i < 3 && i >= 0) {
                number[i] = number[i++];
                TVnumTriManager();
            }
        }

        if (Input.GetKeyDown("left") == true) {
            if (i > 0 && i <= 3) {
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

        for (int i = 0; i < 4; i++) {
            TVnum[i].GetComponentInChildren<Text>().text = number[i].ToString();
        }

        if (Input.GetKeyDown(KeyCode.Return) == true){
            TVnumOK();
        }
    }

    void TVnumTriManager()
    {
        TVnumTri[i].gameObject.SetActive(true);

        for (int r = 0; r < 4; r++){
            if (r != i) TVnumTri[r].gameObject.SetActive(false);
        }

        /*
         * IEnumerator
         * 
        yield return new WaitForSecounds(2.0f);
        */
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;


public class room1picture : MonoBehaviour
{
    [SerializeField] Flowchart ResultLog = null;
    GameObject[] Button = new GameObject[16];
    bool[] ButtonON = new bool[16];
    Button[] btn = new Button[16];
    public GameObject panel;
    int ON=0;
    bool panelAct;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < Button.Length; i++){
            Button[i] = GameObject.Find($"pic{i}");
        }

        panel.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        panelAct = panel.activeSelf;
        if (panelAct == true && Input.GetKeyDown("z") == true){
                Picfalse();
        }

        if (ON == 16){
            Pictrue();
        }
    }

    public void PicPanel()
    {
        panel.SetActive(true);
        ON = 0;
        for (int i = 0; i < Button.Length; i++){
            ButtonON[i] = false;
            btn[i] = Button[i].GetComponent<Button>();
            btn[i].image.color = new Color(255, 180, 180);
        }
    }

    public void PicButton(int num)
    {
        btn[num] = Button[num].GetComponent<Button>();


        if (ButtonON[num] == false){
            ButtonON[num] = true;
            ON++;
            btn[num].image.color = Color.gray;
            Debug.Log($"ON={ON}");

        }
        else
        {
            ButtonON[num] = false;
            ON--;
            btn[num].image.color = new Color(255, 180, 180);

        }

    }

    void Pictrue()
    {
        ResultLog.SetBooleanVariable("Pic815", true);
        ResultLog.SendFungusMessage("ppp");
        ON = 0;
        for (int i = 0; i < Button.Length; i++){
            Button[i].GetComponent<Button>().interactable = false;
        }
        panel.SetActive(false);

    }

    void Picfalse()
    {
        ResultLog.SendFungusMessage("ccc");
        panel.SetActive(false);
    }

}

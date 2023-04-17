using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;


public class room1count : MonoBehaviour
{
    [SerializeField] Flowchart ResultLog = null;
    [SerializeField] GameObject Hissan;

    public GameObject Countpanel;
    public GameObject CountButton;
    int count = 0;
    bool panelAct;

    // Start is called before the first frame update
    void Start()
    {
        Countpanel.gameObject.SetActive(false);
        Hissan.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        panelAct = Countpanel.activeSelf;

        if (panelAct == true){
            countPC();
        }

    }

    void countKey()
    {
        Countpanel.gameObject.SetActive(true);
        CountButton.GetComponent<Button>().interactable = true;
        count = 0;
        CountButton.GetComponentInChildren<Text>().text = count.ToString();

    }

    //--------------�X�}�z�A�}�E�X����-------------------------------
    public void countButtn()
    {
        count++;
        CountButton.GetComponentInChildren<Text>().text = count.ToString();
    }

    public void countOK()
    {
        CountButton.GetComponent<Button>().interactable = false;

        if (count == 25) {
            ResultLog.SendFungusMessage("ooo");

        }else {
            ResultLog.SendFungusMessage("vvv");
        }

        Countpanel.gameObject.SetActive(false);
    }

    //--------------------------PC�L�[����----------------------------------
    void countPC()
    {
        if (Input.GetKeyDown("z") == true) {
            count++;
            CountButton.GetComponentInChildren<Text>().text = count.ToString();
        }

        if (Input.GetKeyDown(KeyCode.Return) == true){
            countOK();
        }
    }

    public void hissanON()
    {
        Hissan.gameObject.SetActive(true);
    }

    public void hissanOFF()
    {
        Hissan.gameObject.SetActive(false);
    }


}

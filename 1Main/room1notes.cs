using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class room1notes : MonoBehaviour
{
    public static bool button = false;
    GameObject play;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown("z") == true)
        {
            button = true;
        }
        
        if (Input.GetKeyDown("z") == false)
        {
            button = false;
        }
        */

    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (button == true || Input.GetKeyDown("z") == true)
        {
            if (col.gameObject.tag == "notes"){
                notesEffect();          //�����A���̂܂ܑ��s

            }else{
                Debug.Log("note!!!");   //�Ԉ�����Ƃ��̃G�t�F�N�gor���̃X�e�[�W�Ɉڍs
            }

            button = false;
        }
    }

    public void notesEffect()
    {
        /*
        var changeTime = 0;
        var size_x = Screen.width;
        var size_y = Screen.height;
        var rtf = GetComponent<RectTransform>();

        //gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 150);
        rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 300);
        rtf.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 200);
        */
        
        Destroy(this.gameObject);
        //Fungus�ŉ����Đ�

        room1notesSpawner.notescount++;
        Debug.Log($"notescount = {room1notesSpawner.notescount}");
    }

}

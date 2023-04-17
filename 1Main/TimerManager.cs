using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private int minute;    //�������Ԃ̕��ƕb
    [SerializeField] private float seconds;
    [SerializeField] Flowchart ResultLog = null;

    private float totalTime;    //����������
    private float oldSeconds;   //�O��Update���̕b��
    private Text timerText;
    bool isPlaying = false;
    bool start = false;

    // Start is called before the first frame update
    void Start()
    {
        isPlaying = true;
        totalTime = minute * 60 + seconds;
        oldSeconds = 0f;
        timerText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        start = ResultLog.GetBooleanVariable("Timer");

        //�������Ԃ�0�b�ȉ��Ȃ牽�����Ȃ�
        if (totalTime <= 0f){
            return;
        }

        if(isPlaying == true && start == true){
            //���������Ԃ��v�Z
            totalTime = minute * 60 + seconds;
            totalTime -= Time.deltaTime;

            //�Đݒ�
            minute = (int)totalTime / 60;
            seconds = totalTime - minute * 60;

            //�e�L�X�g�Ɏ��Ԃ�\��
            if ((int)seconds != (int)oldSeconds)
            {
                timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
            }
            oldSeconds = seconds;
        }

        //�������ԏI���ɂȂ�����
        if (totalTime <= 0f) {
            Debug.Log("�������ԏI��");
            ResultLog.SendFungusMessage("Limit");
            isPlaying = false;
        }
    }
}

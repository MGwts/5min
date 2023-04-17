using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private int minute;    //制限時間の分と秒
    [SerializeField] private float seconds;
    [SerializeField] Flowchart ResultLog = null;

    private float totalTime;    //総制限時間
    private float oldSeconds;   //前回Update時の秒数
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

        //制限時間が0秒以下なら何もしない
        if (totalTime <= 0f){
            return;
        }

        if(isPlaying == true && start == true){
            //総制限時間を計算
            totalTime = minute * 60 + seconds;
            totalTime -= Time.deltaTime;

            //再設定
            minute = (int)totalTime / 60;
            seconds = totalTime - minute * 60;

            //テキストに時間を表示
            if ((int)seconds != (int)oldSeconds)
            {
                timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
            }
            oldSeconds = seconds;
        }

        //制限時間終了になったら
        if (totalTime <= 0f) {
            Debug.Log("制限時間終了");
            ResultLog.SendFungusMessage("Limit");
            isPlaying = false;
        }
    }
}

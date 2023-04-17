using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    [SerializeField] RectTransform[] rect;
    RectTransform[] target = new RectTransform[2];
    RectTransform[] start = new RectTransform[2];
    float speed = 20.0f;

    //[SerializeField] GameObject kbL;
    //[SerializeField] GameObject kbR;

    // Start is called before the first frame update
    void Start()
    {
        rect[0] = GetComponent<RectTransform>();
        rect[1] = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Close1()
    {
        target[0].localPosition = new Vector3(-300, -3, 0);
        target[1].localPosition = new Vector3(300, -3, 0);
        start[0].localPosition = new Vector3(-630, -3, 0);
        start[1].localPosition = new Vector3(630, -3, 0);

        rect[0].localPosition = Vector3.MoveTowards(start[0].localPosition, target[0].localPosition, speed * Time.deltaTime);
        rect[1].localPosition = Vector3.MoveTowards(start[1].localPosition, target[1].localPosition, speed * Time.deltaTime);
    }

    public void Close2()
    {
        rect[0].localPosition = new Vector3(-210, -3, 0);
        rect[1].localPosition = new Vector3(210, -3, 0);
    }
}

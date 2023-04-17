using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TVnumTrimove : MonoBehaviour
{
    int counter = 0;
    float speed = 0.07f;
    int change = 50;
    RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        this.rect.localPosition = new Vector3(this.rect.localPosition.x, Mathf.Clamp(this.rect.localPosition.y, 57, 65), this.rect.localPosition.z);
        counter++;

        if (counter < change)
        {
            rect.localPosition += new Vector3(0, speed, 0);
        }
        else if (counter < change * 2)
        {
            rect.localPosition -= new Vector3(0, speed, 0);
        }
        else if (counter == change * 2) { 
            counter = 0;
        }
    }
}

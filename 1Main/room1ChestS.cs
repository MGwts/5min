using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room1ChestS : MonoBehaviour
{
    [SerializeField] GameObject Zahyo;

    // Start is called before the first frame update
    void Start()
    {
        Zahyo.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void zahyouON()
    {
        Zahyo.gameObject.SetActive(true);
    }

    public void zahyouOFF()
    {
        Zahyo.gameObject.SetActive(false);
    }
}

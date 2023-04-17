using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] Fungus.Flowchart flowchart;
    public FloatingJoystick inputMove;   // �����JoyStick
    float moveSpeed = 5.0f;   // �ړ����鑬�x
    //public float speed = 5.0f;

    //Rigidbody2D playerRb;  // Player��Rigidbody
    bool Playing = false;

    PlayerAnimetion cr;
    Rigidbody2D rbody;

    void Start()
    {
        //playerRb = this.gameObject.GetComponent<Rigidbody2D>();
        cr = GetComponent<PlayerAnimetion>();
        rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Playing = flowchart.GetBooleanVariable("Text");

        if(Playing == false){
            PlayerMove();
        }
    }

    void PlayerMove()
    {
        // ���X�e�B�b�N�ł̈ړ�
        float axisX = inputMove.Horizontal; // ���������̓���
        float axisY = inputMove.Vertical; // ���������̓���

        Vector2 currentPos = rbody.position;
        Vector2 inputVector = new Vector2(axisX, axisY);

        //�L�[�ړ�
        Vector2 move = Vector2.zero;
        if (Input.GetKey("right") == true) {
            //this.transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
            inputVector += new Vector2(1, 0);
        }

        if (Input.GetKey("left") == true) {
            //this.transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
            inputVector += new Vector2(-1, 0);
        }

        if (Input.GetKey("up") == true) {
            //this.transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
            inputVector += new Vector2(0, 1);
        }

        if (Input.GetKey("down") == true){
            //this.transform.position -= new Vector3(0, moveSpeed * Time.deltaTime, 0);
            inputVector += new Vector2(0, -1);
        }

        /*
        playerRb.velocity = Vector3.zero;
        playerRb.AddForce(transform.right * axisX * moveSpeed); // ���E�����̓���
        playerRb.AddForce(transform.up * axisY * moveSpeed); // ���ʕ����̓���
        */

        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector * moveSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        cr.SetDirection(movement);
        rbody.MovePosition(newPos);

    }
}

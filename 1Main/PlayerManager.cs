using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] Fungus.Flowchart flowchart;
    public FloatingJoystick inputMove;   // 左画面JoyStick
    float moveSpeed = 5.0f;   // 移動する速度
    //public float speed = 5.0f;

    //Rigidbody2D playerRb;  // PlayerのRigidbody
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
        // 左スティックでの移動
        float axisX = inputMove.Horizontal; // 水平方向の動き
        float axisY = inputMove.Vertical; // 垂直方向の動き

        Vector2 currentPos = rbody.position;
        Vector2 inputVector = new Vector2(axisX, axisY);

        //キー移動
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
        playerRb.AddForce(transform.right * axisX * moveSpeed); // 左右方向の動き
        playerRb.AddForce(transform.up * axisY * moveSpeed); // 正面方向の動き
        */

        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector * moveSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        cr.SetDirection(movement);
        rbody.MovePosition(newPos);

    }
}

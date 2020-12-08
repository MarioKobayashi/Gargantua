﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 // UFOのコンポーネント
public class UFO : MonoBehaviour
{
    //rigidbodyコンポーネントの変数
    Rigidbody2D rigid2D;

    //左右移動の力
    public float moveForce;

    //左右移動の最大スピード
    public float MaxMoveSpeed;

    //左右移動のブレーキの力
    public float friction;

    //上昇する力
    public float upForce;

    //上昇スピードの最大値
    public float maxUpSpeed;

    //左右のキー入力を取得する変数
    private int Key;

    //上昇のキー入力を取得する変数
    private int upKey;

    //ロケットの炎
    public GameObject injectionLeft;
    public GameObject injectionRight;
    public GameObject injectionUp;

    void Start()
    {
        //rigidbody2Dコンポーネントを取得し、rigid2D変数へ代入
        this.rigid2D = GetComponent<Rigidbody2D>();

        //UFOの炎を消す
        this.injectionLeft.SetActive(false);
        this.injectionRight.SetActive(false);
        this.injectionUp.SetActive(false);
        
    }

    
    void Update()
    {
        

        //左右矢印を押していない間はKeyを0にする
        Key = 0;

        //上矢印を押していない間はupKeyを0にする
        upKey = 0;

        //右矢印を押している間
        if (Input.GetKey(KeyCode.RightArrow)) Key = 1;
       
        //左矢印を押している間
        if (Input.GetKey(KeyCode.LeftArrow)) Key = -1;

        //上矢印を押している間
        if (Input.GetKey(KeyCode.UpArrow)) upKey = 1;

        //Keyが0の時左右の炎を消す
        if (Key == 0)
        {
            this.injectionLeft.SetActive(false);
            this.injectionRight.SetActive(false);
        }

        //upKeyが0の時上昇の炎を消す
        if (upKey == 0) this.injectionUp.SetActive(false);

        //右のキーを押すと左から炎がでる
        if (Key == 1)
        {
            this.injectionLeft.SetActive(true);
            this.injectionRight.SetActive(false);
        }

        //左のキーを押すと右から炎がでる
        if (Key == -1)
        {
            this.injectionRight.SetActive(true);
            this.injectionLeft.SetActive(false);
        }

        //上のキーを押すと上昇の炎がでる
        if (upKey == 1) this.injectionUp.SetActive(true);

    }

    void FixedUpdate()
    {

        //Keyをそのまま使うとエラーが出るので下記の変数にKeyを代入
        int direction_x = Key;
        int direction_y = upKey;

        //X方向のスピード
        float speedx = this.rigid2D.velocity.x;
        //Debug.Log(speedx);

        //Y方向のスピード
        float speedY = this.rigid2D.velocity.y;
        //Debug.Log(speedY);


        //+X方向へ力を加える(スピード制限有)
        if (direction_x == 1 && speedx < this.MaxMoveSpeed)
        {
            this.rigid2D.AddForce(transform.right * direction_x * this.moveForce);
        }

        //-X方向へ力を加える(スピード制限有)
        if (direction_x == -1 && speedx > -this.MaxMoveSpeed)
        {
            this.rigid2D.AddForce(transform.right * direction_x * this.moveForce);
        }

        //矢印キーを押していない&& +X方向へスピードが0より大きい場合、ブレーキをかける
        if (direction_x == 0 && this.rigid2D.velocity.x > 0)
        {
            //-X方向へブレーキをかける
            this.rigid2D.AddForce(transform.right * -this.friction);
        }

        //矢印キーを押していない && -X方向へスピードが0より大きい場合、ブレーキをかける
        if (direction_x == 0 && this.rigid2D.velocity.x < 0)
        {
            //X方向へブレーキをかける
            this.rigid2D.AddForce(transform.right * this.friction);
        }

        //Y方向へ力を加える(スピード制限有)
        if(direction_y == 1 && speedY < this.maxUpSpeed)
        {
            this.rigid2D.AddForce(transform.up * upForce);
        }

    }


}

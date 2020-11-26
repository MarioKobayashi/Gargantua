using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 // UFOのコンポーネント
public class UFO : MonoBehaviour
{
    //rigidbodyコンポーネントの変数
    Rigidbody2D rigid2D;

    //左右移動の力
    public float moveForce;

    //左右移動の最大の力
    public float MaxmoveSpeed;

    //左右移動のブレーキの力
    public float friction;

    //左右のキー入力を取得する変数
    private int Key;

    void Start()
    {
        //rigidbody2Dコンポーネントを取得し、rigid2D変数へ代入
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        //矢印を押していない間はKeyを0にする
        Key = 0;

        //右矢印を押している間
        if (Input.GetKey(KeyCode.RightArrow)) Key = 1;

        //左矢印を押している間
        if (Input.GetKey(KeyCode.LeftArrow)) Key = -1;

       
    }

    void FixedUpdate()
    {

        //Keyをそのまま使うとエラーが出るので下記の変数にKeyを代入
        int direction_x = Key;

        //UFOの左右移動の速度
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);
        Debug.Log(speedx);

        //左より右が大きい場合、
        if (speedx < this.MaxmoveSpeed)
        {
            this.rigid2D.AddForce(transform.right * direction_x * this.moveForce);
        }

        //矢印キーを押していない&& +X方向へスピードが0より大きい場合、ブレーキをかける
        if(direction_x == 0 && this.rigid2D.velocity.x > 0)
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

    }


}

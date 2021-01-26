using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敵の攻撃力、HP等を管理するコンポーネント
public class Enemy : MonoBehaviour
{
    //敵の攻撃力
    public int damage = 1;

    //UFOのHPを管理するコンポーネント
    public UFOHealth ufoHealth;

    private void Start()
    {
        if (this.ufoHealth == null)
        {
            this.ufoHealth = GameObject.Find("UFO").GetComponent<UFOHealth>();
            Debug.Log("nullあり");
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        //UFOがダメージ中では無い場合、
        if(ufoHealth.on_damage == false)
        {
            if (coll.gameObject.tag == "player")
            {
                //プレイヤーへdamageを渡す
                this.ufoHealth.HP -= damage;
                
            }

        }



    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ミサイルに直接付けるコンポーネント
public class Missile : MonoBehaviour
{
    Transform transf_missile;

    //パーティクルゲームオブジェクト
    public GameObject missileBomb;

    //ミサイルの発射からの持続時間
    public float MISSILE_LIFE_TIME = 4;

    //ミサイル発射からの経過時間
    private float missileLifeTimer;

    //ミサイルスピード
    public float moveSpeed;

    //タップしたポジション
    Vector3 targetPos;
    //プレイヤーポジション
    Vector3 ufoPos;
    //プレイヤーからタップした位置へのベクトル
    Vector3 attackPos;

    //ミサイルの回転角度
    float angle;  

    private void Update()
    {
        transf_missile.eulerAngles = new Vector3(0, 0, angle);
        //弾の移動
        transf_missile.position += new Vector3(attackPos.x, attackPos.y, 0).normalized * moveSpeed * Time.deltaTime;

        //弾の持続時間をカウント
        missileLifeTimer -= Time.deltaTime;
        //一定時間経過後、非アクティブにする
        if (missileLifeTimer < 0) this.gameObject.SetActive(false);

    }



    public void Init(Vector3 startPos)
    {
        //Transformをキャッシュしておく
        transf_missile = GetComponent<Transform>();
        //弾の位置を発射場所に設定
        transf_missile.position = startPos;

        //弾が飛んでいられる時間を設定
        missileLifeTimer = MISSILE_LIFE_TIME;

        //弾をアクティブにする
        gameObject.SetActive(true);

        this.targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //カメラのzポジションから10引いて0にする
        this.targetPos.z -= 10;
        this.ufoPos = transform.position;

        //２点間の角度を取得(UFOから見たクリックした位置の角度)
        angle = Utils.GetAngle(ufoPos, targetPos);

        //角度からベクトルを取得する
        this.attackPos = Utils.GetDirection(angle);
    }

    


    private void OnTriggerEnter2D(Collider2D coll)
    {
        
        if (coll.gameObject.tag == "player")
        {
            return;
        }

        this.gameObject.SetActive(false);
        //ミサイルパーティクル生成(オブジェクトプールが難しいので取り敢えずこれで)
        GameObject Part = Instantiate(missileBomb, transform.position, Quaternion.identity) as GameObject;
        Destroy(Part, 0.5f);
        
        





    }











}

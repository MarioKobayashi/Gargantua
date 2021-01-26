using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//UFOのHP、残機、当たり判定を管理するコンポーネント(当たり判定のアクションは全てここで管理)
public class UFOHealth : MonoBehaviour
{
    public int HP;//UFOの最大HP
    SpriteRenderer Renderer;
    public Sprite UFO_NO_ARMOUR; //UFOのダメージを受けた姿
    public Sprite UFO; //HPMAX時のUFOの姿
    public bool on_damage = false; //ダメージを受けてる最中かどうか
    public CameraShake shake;
    public GameObject missileBomb; //パーティクルゲームオブジェクト
    [SerializeField] private float stopTime = 0.3f;
    [SerializeField] private float mutekiTime = 1.0f;
    

    private void Awake()
    {
        this.Renderer = GetComponent<SpriteRenderer>();

        if(shake == null)
        {
            this.shake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
            Debug.Log("nullあり");
        }
    }

    

    private void Update()
    {
        if (on_damage)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            Renderer.color = new Color(1f, 1f, 1f, level);
        }
    }





    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (on_damage) return; //点滅状態の時はダメージを受けない

        //ダメージを受けた時の当たり判定
        if (coll.gameObject.tag == "DAMAGE")
        {

            if (HP == 1)
            {
                StartCoroutine(WaitRealTime());
                StartCoroutine(MutekiRealTime());
            }

            if(HP == 0)
            {
                this.gameObject.SetActive(false);
                //残機を1減らす
                SceneController.zanki -= 1;
            }
        }

        


    }

    //ダメージを受けた時に画面が一瞬ストップする
    private IEnumerator WaitRealTime()
    {
            //時を止める
            Time.timeScale = 0;
            //0.5s待つ
            yield return new WaitForSecondsRealtime(stopTime);
        　　 //時を再開
            Time.timeScale = 1;
            shake.Shake(0.2f, 0.2f);
            //パーティクル作成
            GameObject Part = Instantiate(missileBomb, transform.position, Quaternion.identity) as GameObject;
            Destroy(Part, 1.0f);
            //HPが1になった時、スプライトを変える
            this.Renderer.sprite = UFO_NO_ARMOUR;
    }

    //UFOの無敵状態
    private IEnumerator MutekiRealTime()
    {
        //ダメージ中状態をonにする
        on_damage = true;
        //規定秒数点滅させる
        yield return new WaitForSecondsRealtime(stopTime + mutekiTime);
        //ダメージ中状態をoffにする
        on_damage = false;

        //点滅終了
        Renderer.color = new Color(1f, 1f, 1f, 1f);
    }

    




}

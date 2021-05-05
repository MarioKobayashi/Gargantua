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
    private CameraShake shake;
    public GameObject missileBomb; //パーティクルゲームオブジェクト
    [SerializeField] private float mutekiTime = 1.0f;

    private void Awake()
    {
        this.Renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if(shake == null)
        {
            this.shake = GameObject.Find("MainCamera").GetComponent<CameraShake>();
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

            if (HP >= 1)
            {
                Damage(1.0f);
                StartCoroutine(MutekiRealTime());
            }

            if(HP == 0)
            {
                Damage(10f);
                //残機を1減らす
                SceneController.zanki -= 1;
            }
        }

        


    }

    //ダメージを受けた時に画面が一瞬ストップする(死んだ時と分岐)
    public void Damage(float partTime)//引数はパーティクル持続時間
    {
 
            shake.Shake(0.2f, 0.5f);
            //パーティクル作成
            GameObject Part = Instantiate(missileBomb, transform.position, Quaternion.identity) as GameObject;
            Destroy(Part, partTime);

        if(HP >= 1)
        {
            //HPが1になった時、スプライトを変える
            this.Renderer.sprite = UFO_NO_ARMOUR;
        }else if(HP == 0)
        {　　//ゲームオーバー(UFOを消す)
            this.gameObject.SetActive(false);
        }
            
    }

    //UFOの無敵状態
    private IEnumerator MutekiRealTime()
    {
        //ダメージ中状態をonにする
        on_damage = true;
        //規定秒数点滅させる
        yield return new WaitForSeconds(mutekiTime);
        //ダメージ中状態をoffにする
        on_damage = false;

        //点滅終了
        Renderer.color = new Color(1f, 1f, 1f, 1f);
    }

    




}

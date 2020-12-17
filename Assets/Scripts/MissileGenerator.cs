using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileGenerator : MonoBehaviour
{
    //エディタから弾として使うプレハブを設定
    public GameObject pf_missile;

    //UFOのトランスフォーム
    public GameObject ufo;

    //弾を備蓄しておくList
    List<Missile> list_missile = new List<Missile>();
    //備蓄しておく弾の数
    public int MAX_MISSILE;

    Missile missile;

    //ミサイル発射間隔のon/off
    private bool missileBool  = true;
    //ミサイルの発射間隔の秒数
    public float missileTime;

    

    private void Start()
    {
        if (ufo == null)
        {
            this.ufo = GameObject.Find("UFO");
            Debug.Log("nullあり");
        }

        


        //最初に一定数の弾を備蓄しておく
        for (int i = 0; i< MAX_MISSILE; i++)
        {
            //弾の生成
            this.missile = Instantiate(pf_missile).GetComponent<Missile>();
            //弾をミサイルジェネレーターオブジェクトの子にする
            missile.transform.parent = this.transform;
            //発車前は非アクティブにする
            missile.gameObject.SetActive(false);
            //Listに追加
            list_missile.Add(missile);
        }
   }

    private void Update()
    {
        if(missileBool)
        {
            Vector3 ufoPos = this.ufo.transform.position;

            if (Input.GetMouseButtonDown(0))
            {
                FireMissile(ufoPos);
                missileBool = false;
                StartCoroutine(MissileStop());

            }
        }
        
    }

    public void FireMissile(Vector3 startPos)
    {
        //リストの中身を最初から確認し、非アクティブのオブジェクトを探す
        for(int i = 0; i < list_missile.Count; i++)
        {
            
            if(list_missile[i].gameObject.activeSelf == false)
            {
                //非アクティブな弾を発射する
                list_missile[i].Init(startPos);
                return;
            }
        }
        //弾が全てtrueの場合は新たにオブジェクトを１つ生成してリストに追加する
        this.missile = Instantiate(pf_missile).GetComponent<Missile>();
        missile.transform.parent = this.transform;
        missile.gameObject.SetActive(false);
        list_missile.Add(missile);
        //リストの中の.Count-1で要素の末尾を取得しそれを撃つ
        list_missile[list_missile.Count - 1].Init(startPos);
        //Debug.Log(list_missile.Count);

    }

    private IEnumerator MissileStop()
    {
        yield return new WaitForSeconds(missileTime);
        missileBool = true; 
    }



}


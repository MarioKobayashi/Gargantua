using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeItemBox : MonoBehaviour
{
    //scritableObjectの配列
    //0 ミサイル
    //1 ボム(仮)
    //2 シールド(仮)

    public ItemBoxData itemBoxData;

    private GameObject item;　//アイテムボックスへ入れるアイテム

    Transform parent;//自分自身のトランスフォーム

    private string itemName; //現在ItemBoxに入っているアイテムの名称

    public int num;

    private void Awake()
    {
        parent = this.transform;//自分自身のトランスフォーム(変数へ代入)

        num = ES3.Load<int>("itemNum", defaultValue: -1); //直前に使っていたアイテムをロード、-1はアイテム無し

        if(num >= 0)
        {
            item = Instantiate(itemBoxData.Item[num], transform.position, Quaternion.identity, parent);
            item.name = itemBoxData.Item[num].name;
            itemName = item.name;
        }
    }

    public void NumGet(int num) //アイテム生成
    {
        //if (BUTTON == num) return; //前に押されたボタンがもう一度押された場合は何もしない

        if (item != null)
        {
            Destroy(item);
            //ここまではアイテムの共通の処理

            if (itemName == "MissileGenerator")//ミサイルの場合、missileBoxが生成されるのでそれを削除する
            {
                GameObject missileBox = GameObject.Find("missileBox");
                Destroy(missileBox);
            }

            
        }

        item = Instantiate(itemBoxData.Item[num], transform.position, Quaternion.identity, parent);
        item.name = itemBoxData.Item[num].name;
        itemName = item.name;

        //選択したアイテム番号を記録、簡単なものなので
        //saveManagerを経由せず、直接ここでセーブとロードをやる
        ES3.Save<int>("itemNum", num); 

    }

    public void NumDestroy() //アイテムボックスにアイテムが何もない事を記録する関数
    {
        ES3.Save("itemNum", -1);
    }
    
}

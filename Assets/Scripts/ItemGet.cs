using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//新たなアイテムをゲットした時
public class ItemGet : MonoBehaviour
{
    [SerializeField]
    private string ItemNumber = null;//アイテム名(番号)をインスペクタから指定する

    SaveManager save;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "player")
        {
            if(save == null)
            {
                save = GameObject.Find("SaveManager").GetComponent<SaveManager>();
            }
            
            if(ItemNumber == "0")//ミサイルとの接触の場合
            {
                save.missileBool = true;
                save.SaveItem();
                Destroy(gameObject);
            }

            if (ItemNumber == "1")//ボムとの接触の場合
            {
                save.BombBool = true;
                save.SaveItem();
                Destroy(gameObject);
                
            }
            
        }
    }
}

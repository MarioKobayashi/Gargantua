using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//アイテムアイコンを押した時のリアクション
public class ItemIconOn : MonoBehaviour
{
    //0 ミサイル
    //1 ボム(仮)
    //2 ライト(仮)

    [SerializeField]
    private Sprite itemImage = null;

    Image image;

    private MakeItemBox item; //アイテムボックス

    private string itemName; //アイテムの名前(数字)string

    private int num; //アイテム番号

    SaveManager save;

    void Awake()
    {
        

        if(image == null)
        {
            image = GetComponent<Image>();
        }

        if (save == null)
        {
            save = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        }

        //アイテムの番号を取得
        itemName = gameObject.name;
        num = int.Parse(itemName); 

        //イベントトリガーをスクリプトから制御(意味は謎)
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => { OnPointerDownDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry);
    }

    private void OnEnable()
    {
       save.RoadItem();//アイテムのセーブデータをONにする

        if (num == 0)//ミサイルの場合
        {
            if (save.missileBool)
            {
                image.sprite = itemImage;
            }
                
        }

        if (num == 1)//ボムの場合
        {
            if (save.BombBool)
            {
                image.sprite = itemImage;
            }

        }
    }
    

    //この中に押された時の処理を書く
    public void OnPointerDownDelegate(PointerEventData data)
    {
        ////アイテムがない場合処理を終了する////
        if (num == 0)//ミサイルの場合
        {
            if (!save.missileBool)
            {
                return;
            }

        }

        if (num == 1)//ボムの場合
        {
            if (!save.BombBool)
            {
                return;
            }

        }
        ///////////////////////////////////追加予定↑

        ////アイテムがある場合////
        if (num == 0)//ミサイルの場合
        {
            if (save.missileBool)
            {
                if (item == null)
                {
                    item = GameObject.Find("ItemBox").GetComponent<MakeItemBox>();
                }
                item.NumGet(num);
            }

        }

        if (num == 1)//ボムの場合
        {
            if (save.BombBool)
            {
                if (item == null)
                {
                    item = GameObject.Find("ItemBox").GetComponent<MakeItemBox>();
                }
                item.NumGet(num);
            }

        }
        ///////////////////////////////////追加予定↑



    }



}

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

    [SerializeField]
    private ItemDescriptionData ItemDescriptionData = null;

    Image image;

    private MakeItemBox item; //アイテムボックス

    private string itemName; //アイテムの名前(数字)string

    private GameObject itemBox; //アイテムボックスオブジェクト

    private GameObject missileBox; //ミサイルボックスオブジェクト

    private Text ItemNameText; //アイテム名オブジェクト

    private Text ItemDescriptionText;  //アイテム説明のオブジェクト

    private int num; //アイテム番号

    SaveManager save;

    WakuController wakuController;

    void Awake()
    {
        if(ItemNameText == null)
        {
            ItemNameText = GameObject.Find("ItemNameText").GetComponent<Text>();
        }

        if(ItemDescriptionText == null)
        {
            ItemDescriptionText = GameObject.Find("ItemDescriptionText").GetComponent<Text>();
        }
   
        if(image == null)
        {
            image = GetComponent<Image>();
        }

        if (save == null)
        {
            save = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        }

        if(wakuController == null)
        {
            wakuController = transform.parent.gameObject.GetComponent<WakuController>();
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

        //アイテムのタイトル、説明をそれぞれ空欄にする
        ItemNameText.text = ItemDescriptionData.empty;
        ItemDescriptionText.text = "アイコンをタップして\n\nアタッチメントを選択して下さい";

        if (itemBox == null)
        {
            itemBox = GameObject.Find("ItemBox");
        }

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

        if (num == 2)//シールドの場合
        {
            if (save.ShildBool)
            {
                image.sprite = itemImage;
            }

        }
    }


    //この中にアイコンが押された時の処理を書く
    public void OnPointerDownDelegate(PointerEventData data)
    {
        wakuController.wakuNum(num);//どの枠が有効になるかを指定

        //0番のミサイルボックス以外が押された場合はミサイルボックスを削除する
        if (num != 0)
        {
                missileBox = GameObject.Find("missileBox");

            if (missileBox)
            {
                Destroy(missileBox);
            }
        }

        //ミサイルの場合
        if (num == 0)
        {
            if (!save.missileBool)//セーブデータがない場合
            {
                ItemNameText.text = ItemDescriptionData.empty; //アイテム名が????になる
                ItemDescriptionText.text = ItemDescriptionData.empty_des; //アイテム説明が????になる

                foreach (Transform i in itemBox.transform)
                {
                    Destroy(i.gameObject);
                }
            }
            else if (save.missileBool)//セーブデータがある場合
            {
                ItemNameText.text = ItemDescriptionData.missile; 
                ItemDescriptionText.text = ItemDescriptionData.missile_des;

                if (item == null)
                {
                    item = GameObject.Find("ItemBox").GetComponent<MakeItemBox>();
                }
                item.NumGet(num);
                
            }
        }

        //ボムの場合
        if (num == 1)
        {
            if (!save.BombBool)
            {
                ItemNameText.text = ItemDescriptionData.empty;
                ItemDescriptionText.text = ItemDescriptionData.empty_des;

                foreach (Transform i in itemBox.transform)
                {
                    Destroy(i.gameObject);
                }
            }
            else if (save.BombBool)
            {
                ItemNameText.text = ItemDescriptionData.bomb;
                ItemDescriptionText.text = ItemDescriptionData.bomb_des;

                if (item == null)
                {
                    item = GameObject.Find("ItemBox").GetComponent<MakeItemBox>();
                }
                item.NumGet(num);
            }
        }

        //シールドの場合
        if (num == 2)
        {
            if (!save.ShildBool)
            {
                ItemNameText.text = ItemDescriptionData.empty;
                ItemDescriptionText.text = ItemDescriptionData.empty_des;

                foreach (Transform i in itemBox.transform)
                {
                    Destroy(i.gameObject);
                }
            }
            else if (save.ShildBool)
            {
                ItemNameText.text = ItemDescriptionData.shild;
                ItemDescriptionText.text = ItemDescriptionData.shild_des;

                if (item == null)
                {
                    item = GameObject.Find("ItemBox").GetComponent<MakeItemBox>();
                }
                item.NumGet(num);
            }

        }



    }

    

}

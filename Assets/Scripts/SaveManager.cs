using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//アイテムを持っているかどうかを判定するJSON用クラス
[System.Serializable]
public class ItemSaveData
{
    public bool missileBool; //初期のアイテム状態(アイテムを持っていない)

    public bool BombBool; //初期のアイテム状態(アイテムを持っていない)
}

public class SaveManager : MonoBehaviour
{

    public bool missileBool;

    public bool BombBool;

    ItemSaveData itemSaveData = new ItemSaveData();//アイテムセーブデータインスタンスを取得

    private void Awake()
    {
        missileBool = itemSaveData.missileBool;
        BombBool = itemSaveData.BombBool;
    }

    //アイテムデータをセーブ
    public void SaveItem()
    {
        StreamWriter writer;

        //ItemSaveData(JSON)に現在の状態を保存する
        itemSaveData.missileBool = missileBool;
        itemSaveData.BombBool = BombBool;

        string jsonstr = JsonUtility.ToJson(itemSaveData);//アイテムセーブデータをJSONに変換
        

        writer = new StreamWriter(Application.dataPath + "/SaveFile/ItemSave.json", false);//falseはデータを上書き

        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();

    }

    //アイテムデータをロード
    public void RoadItem()
    {

        string datastr = "";

        StreamReader reader;

        reader = new StreamReader(Application.dataPath + "/SaveFile/ItemSave.json"); //データロード
        datastr = reader.ReadToEnd();
        reader.Close();

        itemSaveData = JsonUtility.FromJson<ItemSaveData>(datastr);

        missileBool = itemSaveData.missileBool;
        BombBool = itemSaveData.BombBool;
    }
    
}




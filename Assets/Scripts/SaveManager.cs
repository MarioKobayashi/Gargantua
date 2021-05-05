using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class SaveManager : MonoBehaviour
{

    public bool missileBool = false; //ミサイルを持っているか

    public bool bombBool = false; //ボムを持っているか

    public bool shildBool = false; //シールドを持っているか

    private void Awake()
    {
        missileBool = ES3.Load<bool>("missileBool", defaultValue: false);
        bombBool = ES3.Load<bool>("bombBool", defaultValue: false);
        shildBool = ES3.Load<bool>("shildBool", defaultValue: false);

    }

    //アイテムデータをセーブ
    public void SaveItem(int itemNum)
    {
        if(itemNum == 0)
        {
            ES3.Save<bool>("missileBool", true);
        }

        if (itemNum == 1)
        {
            ES3.Save<bool>("bombBool", true);
        }

        if (itemNum == 2)
        {
            ES3.Save<bool>("shildBool", true);
        }

    }
    
}


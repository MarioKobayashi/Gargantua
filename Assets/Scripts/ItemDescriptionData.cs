using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item_Des_Data", menuName = "Item_Des_Data")]
public class ItemDescriptionData : ScriptableObject
{
    //アイテムの名前(配列)
    public string missile = "- タップミサイル -";
    public string bomb = "- スーパーボム -"; //仮
    public string shild = "- タイムシールド -"; //仮
    public string empty = "- ???? -";//まだアイテムを持っていない場合は????になる
    //アイテムの名前


    //アイテムの説明(配列)
    public string missile_des = "タップした場所にミサイルを打つ事が出来るアタッチメント。\n \n約1秒に一発打ち込む事が可能だ。";
    public string bomb_des = "UFOの真下に爆弾を落下させる事が出来るアタッチメント。\n \n 驚異の破壊力を誇る。";
    public string shild_des = "発動から3秒間全ての攻撃を防ぐアタッチメント。\n \n　ピンチの時に使おう。";
    public string empty_des = "????"; //アイテムを持っていない場合
    //アイテムの説明(配列)








}

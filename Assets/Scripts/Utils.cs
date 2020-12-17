using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ゲームでよく使用する関数を管理する静的なクラス
public static class Utils
{
    //指定された２つの位置から角度を求めて返す(from→to)
    public static float GetAngle(Vector3 from, Vector3 to)
    {
        float dx = to.x - from.x;
        float dy = to.y - from.y;

        //ラジアンを求める
        float rad = Mathf.Atan2(dy, dx);

        //ラジアンを度数に変換
        return rad * Mathf.Rad2Deg;
    }

    //指定した角度をベクトルに変換して返す
    public static Vector3 GetDirection(float angle)
    {
        return new Vector3(Mathf.Cos(angle * Mathf.PI / 180f), Mathf.Sin(angle * Mathf.PI / 180f), 0);
    }









}

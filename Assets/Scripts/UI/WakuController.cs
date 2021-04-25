using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakuController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] waku = null;

    private void OnEnable()
    {
        for (int i = 0; i < waku.Length; i++)
        {
            waku[i].SetActive(false); //オブジェクトが有効になったら枠を初期化
        }
    }

    public void wakuNum(int num)//押されたボタンの枠が有効になり、押されていない枠は無効になる
    {
        for(int i = 0; i < waku.Length; i++)
        {
            if(i == num)
            {
                waku[i].SetActive(true);
            }else if(i != num)
            {
                waku[i].SetActive(false);
            }
        }
    }



}

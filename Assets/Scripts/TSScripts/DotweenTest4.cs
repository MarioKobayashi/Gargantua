using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//ドットウィーンの具体的な使い方
public class DotweenTest4 : MonoBehaviour
{
    private Sequence seq;

    private void Start()
    {
        this.seq = DOTween.Sequence();
        //任意のタイミングで呼ぶ為にStart()でこれを呼び出す。
        this.seq = Utils.CreateReusableSequence(gameObject);

        //動きを個別にまとめる事が出来る
        var LightMove = this.transform.DOMoveX(2, 3).SetEase(Ease.InBounce);
        var LeftMove = this.transform.DOMoveX(0, 3);

        seq.Append(LightMove)
            //Appendのコールバック、関数が終了して呼ばれる処理、関数も呼べる(これがラムダですか？)
            .AppendCallback(() =>
        {
            Debug.Log("左移動完了");
        })
            .Append(LeftMove).AppendCallback(() =>
            {
                Debug.Log("右移動完了");
            });


        


    }

    private void Update()
    {
       

        if (Input.GetKey(KeyCode.A))
        {
            //これで任意のタイミングでアニメーションを呼べる
            seq.Restart();
        }
    }
}

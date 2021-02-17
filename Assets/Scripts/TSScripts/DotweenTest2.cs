using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//ドットウィーンを止める方法
public class DotweenTest2 : MonoBehaviour
{
    //kill等を使うのに必要
    Tween tween;

    
    
    void Start()
    {
        //this.tween = this.transform.DOMove(new Vector3(5, 0, 0), 2f)
        //.SetLoops(-1, LoopType.Yoyo);

        //回転(SetEaseとLoopTypeで色々な回転が可能)
        //Ease.Linerで等速運動
        this.tween = this.transform.DORotate(new Vector3(0,0,1) * 180f, 1)
        .SetEase(Ease.InBounce)
        .SetLoops(-1, LoopType.Incremental).SetLink(gameObject);

        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //返り値を保存しておいて止める
            this.tween.Kill();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            //参照元を指定して止める
            this.transform.DOKill();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            //Objectを指定して止める
            DOTween.Kill(this.transform);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            //全ての実行を止める
            DOTween.KillAll();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            this.tween.Pause();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            //リスタート
            this.tween.Restart();
        }

    }
}

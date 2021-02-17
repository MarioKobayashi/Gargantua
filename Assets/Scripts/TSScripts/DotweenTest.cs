using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//ドットウィーンテスト
public class DotweenTest : MonoBehaviour
{
    private void Start()
    {
        //3秒かけて(5.0.0)へ移動
        //this.transform.DOMove(new Vector3(5f, 0, 0), 3f);

        //(5.0.0)へ1秒で移動するのを3回繰り返す
        //LoopTypeはYoyo,Restart,Incrementの3種類がある
        //SetLoopsの第一引数を-1にすると無限ループ
        //this.transform.DOMove(new Vector3(5, 0, 0),1f).SetLoops(6, LoopType.Incremental);

        //遅延(SetDelay)
        //この場合,3秒待機→一秒かけて指定の座標へ移動
        //this.transform.DOMove(new Vector3(5f, 0, 0), 1f).SetDelay(3f);

        //Ease(始点と終点をどのように繋ぐか設定できる)
        //https://github.com/Nightonke/WoWoViewPager/blob/master/Pictures/ease.png
        //Easeの種類
        //INが付くものは進む前に逆に助走をつける感じになる(使えそうなものが多い)
        //ドットで改行すると読みやすい

        this.transform.DOMove(new Vector3(3, 0, 0), 1f)
            .SetEase(Ease.InOutBack)
            .SetLoops(-1, LoopType.Yoyo).SetLink(gameObject);








    }

}

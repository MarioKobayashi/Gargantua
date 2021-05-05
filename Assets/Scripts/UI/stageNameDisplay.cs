using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class stageNameDisplay : MonoBehaviour
{
    [SerializeField] private RectTransform rectT = default;

    [SerializeField] private Text StageText; //ステージ名を表示するインスタンス

    private MakeSceneObj makeSceneObj; //makeSceneObjに格納されているstage名を取得するのに必要

    private string sceneName;

    private Sequence seq;//DOTweenのシーケンス

    private void Start()
    {
        //makeSceneObjから現在のステージ名を取得
        makeSceneObj = GameObject.Find("MakeSceneObj").GetComponent<MakeSceneObj>();
        sceneName = makeSceneObj.stageName;

        //ステージ名を表示
        StageText.text = sceneName;
        Action();


    }

    void Action()
    {
        this.seq = DOTween.Sequence();

        //動きを個別にまとめ、変数に格納する
        //UIimageのscaleXを0から1にする
        var action1 = rectT.DOScaleX(1f, 0.1f);

        //UIを削除する
        var action3 = rectT.DOScaleX(0f, 0.1f);

        seq.AppendInterval(0.5f)
            .Append(action1)
            .AppendInterval(2.0f) //1秒待機
            .Append(action3)
            .AppendCallback(() =>
            {
                //gameObject.SetActive(false);
            })
            .SetAutoKill(false)
            .SetLink(gameObject);

    }
}

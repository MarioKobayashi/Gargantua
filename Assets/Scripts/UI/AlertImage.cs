using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class AlertImage : MonoBehaviour
{
    [SerializeField] private RectTransform rectT = default;

    static string SceneName = null;//ステージ名、最初はnull

    private Sequence seq;

    private void Start()
    {
        //SceneNameに何も登録されていない場合ステージ名を表示
        if(SceneName == null)
        {
            SceneName = SceneManager.GetActiveScene().name;
            Action();
        }

        //現在SceneNameに保存されている内容が現在のシーン名と一致しない場合
        if (!SceneName.Equals(SceneManager.GetActiveScene().name))
        {
            Action();
        }
        
    }

    private void Update()
    {
        //ゲームオーバーになったらSceneNameの中身を空にする
        if (SceneController.zanki < 0) SceneName = null;
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

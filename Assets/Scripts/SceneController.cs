using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//シーン遷移を管理するコンポーネント
public class SceneController : MonoBehaviour
{
    //現在のシーン名
    private string SceneName;
    //初期の残機数
    public static int zanki = 0;
    //初期の残機数の記録の為の変数
    private int CurrentZanki;

    private LightController lightController;

    //タイトルシーン
    string TitleScene = "TitleScene";

    private void Start()
    {
        if(lightController == null)
        {
            lightController = GameObject.Find("LIGHT").GetComponent<LightController>();
        }

        //現在のシーン名を取得
        this.SceneName = SceneManager.GetActiveScene().name;

        //初期の残機数を記録変数へ代入
        CurrentZanki = zanki;
    }

    private void Update()
    {
        //初期の残機数と現在の残機数にが等しければ処理を終了
        if (CurrentZanki == zanki) return;

            //残機数がまだ残っている場合
            if(zanki >= 0)
            {
            
            //現在シーンの初期位置へ戻る
            StartCoroutine(SceneChange(SceneName));
            }

            //残機数が無くなった場合
            if(zanki < 0)
            {
            StartCoroutine(SceneChangeTitle(TitleScene));
            }
    }

    //残機がある場合の画面遷移
    private IEnumerator SceneChange(string scene)
    {
        yield return new WaitForSeconds(1f);
        lightController.fadeIn = true;

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }

    //残機が無くなった場合の画面遷移
    private IEnumerator SceneChangeTitle(string scene)
    {
        yield return new WaitForSeconds(4f);
        lightController.fadeIn = true;

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(scene);
    }


    }




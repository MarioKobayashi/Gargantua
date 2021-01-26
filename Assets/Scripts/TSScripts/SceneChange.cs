using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//シーン遷移を管理するコンポーネント(シーン間の間やエフェクト等を管理)
public class SceneChange : MonoBehaviour
{

    //タイトルシーンへ移動
    public void ChangeScene()
    {
        SceneController.zanki = 2;
        SceneManager.LoadScene("SampleScene");
    }



}

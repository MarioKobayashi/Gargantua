using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MakeObjeList", menuName = "MakeObjeList")]
public class MakeSceneObjDATA : ScriptableObject

{
    public GameObject UFO; //UFOのインスタンス

    public GameObject LIGHT; //ライト

    public GameObject CanvasFADE; //フェードアウトするUIキャンバス

    public GameObject CanvasNO_FADE; //フェードアウトしないUIキャンバス

    public GameObject EventSystem; //イベントシステム

    public GameObject SceneController; //シーンコントローラー

    public GameObject SaveManager; //セーブマネージャー

}



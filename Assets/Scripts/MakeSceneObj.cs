﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSceneObj : MonoBehaviour
{
    
    public MakeSceneObjDATA makeSceneObjData; //シーンに必ず存在するオブジェクトのデータ

    public string stageName; //ステージの名称(ユニークなデータなのでsceneごとに登録が必要)

    private GameObject UFO;

    private GameObject LIGHT;

    private GameObject CanvasFADE;

    private GameObject CanvasNO_FADE;

    private GameObject EventSystem;

    private GameObject SceneController;

    private GameObject SaveManager;

    //参照があるものAwake()でインスタンス化
    private void Awake()
    {
        this.SaveManager = Instantiate(makeSceneObjData.SaveManager);
        SaveManager.name = "SaveManager";
    }

    private void Start()
    {
        //フェードキャンバスをインスタンス化
        this.CanvasFADE = Instantiate(makeSceneObjData.CanvasFADE);
        CanvasFADE.name = "Canvas(FADE)";

        //フェードしないキャンバスをインスタンス化
        this.CanvasNO_FADE = Instantiate(makeSceneObjData.CanvasNO_FADE);
        CanvasNO_FADE.name = "Canvas(NO_FADE)";

        //イベントシステムをインスタンス化
        this.EventSystem = Instantiate(makeSceneObjData.EventSystem);
        EventSystem.name = "EventSystem";

        //UFOをインスタンス化
        this.UFO = Instantiate(makeSceneObjData.UFO);
        UFO.name = "UFO";

        //ライトをインスタンス化
        this.LIGHT = Instantiate(makeSceneObjData.LIGHT);
        LIGHT.name = "LIGHT";

        //シーンコントローラーをインスタンス化
        this.SceneController = Instantiate(makeSceneObjData.SceneController);
        SceneController.name = "SceneController";
    }
}

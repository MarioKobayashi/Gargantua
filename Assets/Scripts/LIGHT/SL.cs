using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using DG.Tweening;

public class SL : MonoBehaviour
{
    public Light2D spotLight;

    Vector3 SceneCamera;

    //スポットライト生成時の半径の大きさ
    [SerializeField] float SLRadius = 30;

    //スポットライトが消えるまでの時間
    [SerializeField] float lightTime = 3;

    private void Awake()
    {
        this.spotLight.pointLightOuterRadius = SLRadius;
        this.spotLight.pointLightInnerRadius = SLRadius;
    }

    private void Start()
    {
        //カメラをシーンから見つける(この書き方で他のオブジェクトの座標を取得できる)
        Vector3 SceneCamera = GameObject.Find("MainCamera").transform.position;
        //カメラの座標をゲームオブジェクトに代入(zは0にする)
        gameObject.transform.position = new Vector3(SceneCamera.x, SceneCamera.y, 0);
        
        //5秒で円が消える
        DOTween.To(() => SLRadius, x => SLRadius = x, 0, lightTime).SetDelay(1.0f);
        
    }


    void Update()
    {
        //スポットライトの半径を更新
        this.spotLight.pointLightOuterRadius = SLRadius;
        this.spotLight.pointLightInnerRadius = SLRadius;

    }

   
}

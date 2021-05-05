using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using DG.Tweening;


//カメラ制御のコンポーネント
public class CameraCon : MonoBehaviour
{
    [SerializeField]
    private GameObject UFOObj;

    Vector3 ufoPos;

    PixelPerfectCamera came;

    //基本となるpixelPerUnit
    private const int PPU = 32;

    //通常使用するカメラをoffにするときに使用
    bool anotherCamera;

    private void Start()
    {
        if (UFOObj == null)
        {
            this.UFOObj = GameObject.Find("UFO");
        }

        came = GetComponent<PixelPerfectCamera>();
       
    }


    void LateUpdate()
    {
        ufoCamera();
    }


    //プレイ中の基本動作(UFOを追従するカメラ)
    private void ufoCamera()
    {
        //UFOがいない場合処理は終了する
        if (!UFOObj.activeSelf) return;

        //UFOが存在する場合、UFOに追従する
        //UFOのポジションをufoPosへ代入する
        ufoPos = UFO.UFOPOS;

        //gameObject(カメラ)をUFOに追従させる
        gameObject.transform.position = new Vector3(UFO.UFOPOS.x, UFO.UFOPOS.y, -10);
    }


    //ズームイン(引数1 カメラサイズ、引数2 移動するまでの時間、引数3 ポジション)
    public void ZoomIn(int PPUChange, float time)
    {
        DOTween.To(() => came.assetsPPU, (x) => came.assetsPPU = x, PPUChange, time)
            //TimeScaleを無視出来る
            .SetUpdate(true);

        Time.timeScale = 0;    
    }

    //ズームアウト
    public void ZoomOut()
    {
        DOTween.To(() => came.assetsPPU, (x) => came.assetsPPU = x, PPU, 0.2f)
            .SetUpdate(true)
            .OnComplete(() =>
            {
                Time.timeScale = 1;
            });
            
    }




}

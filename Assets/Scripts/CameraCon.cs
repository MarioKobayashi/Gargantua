using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//カメラ制御のコンポーネント
public class CameraCon : MonoBehaviour
{
    public GameObject UFO;

    void LateUpdate()
    {
        //UFOがいない場合処理は終了する
        if (!UFO) return;

        //UFOが存在する場合、UFOに追従する
        //UFOのポジションをufoPosへ代入する
        Vector3 ufoPos = this.UFO.transform.position;

        //gameObject(カメラ)をUFOに追従させる
        gameObject.transform.position = new Vector3(ufoPos.x, ufoPos.y, -10);
    
    }
}

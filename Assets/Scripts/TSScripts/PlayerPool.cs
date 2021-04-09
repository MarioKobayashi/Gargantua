using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPool : MonoBehaviour
{
    //生成する弾
    [SerializeField] GameObject bullet = null;

    //弾をプーリングする空のオブジェクト
    Transform bullets;

    float duration = 0f;

    private void Start()
    {
        //弾を保持する空のオブジェクトを生成
        bullets = new GameObject("poolBullets").transform;
        
    }

    private void Update()
    {
        gameObject.transform.Rotate(0, 0, 05f);

        duration += Time.deltaTime;
        if(duration > 0.1)
        {
            InstBullet(transform.position, transform.rotation);
            duration = 0;
        }
        
            
       
        
        
    }

    private void InstBullet(Vector3 pos, Quaternion rotation)
    {
        //bulletsの子オブジェクトの中から非アクティブな物を探す
        foreach(Transform t in bullets.transform)
        {
            if (!t.gameObject.activeSelf)
            {
                //非アクティブなオブジェクトの位置と回転を設定
                //SetPositionAndRotationはpositionとrotationを同時に設定できる
                // 従来
                //transform.position = new Vector3(1, 1, 1);
                //transform.rotation = Quaternion.Euler(0, 180, 0);
                t.SetPositionAndRotation(pos, rotation);
                //アクティブにする
                t.gameObject.SetActive(true);

                return;

                
            }
        }
        //非アクティブなオブジェクトが無い場合新規作成
        //生成時にbulletsの子オブジェクトにする
        Instantiate(bullet, pos, rotation, bullets);
    }

    



}

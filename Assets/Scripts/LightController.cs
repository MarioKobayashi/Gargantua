using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

//ライトを制御するコンポーネント
public class LightController : MonoBehaviour
{
    public Light2D fade;

    public GameObject UFO;

    private void Start()
    {
        //フェードアウトするので最初は真っ暗
        fade.intensity = 0;
        
    }


    private void Update()
    {
        StartCoroutine(Test());
        /*if(fade.intensity >= 0 && fade.intensity <= 1)
        {
            FadeOut();
        }*/



    }

    //フェードアウト
    /*private void FadeOut()
    {
        //例外処理(ライトが付いている時は処理しない)
        if (fade.intensity == 1) return;

        //明るさを加算(0なら1秒で通常の明るさになる)
        fade.intensity += 1 * Time.deltaTime;

        //ライトの明るさが1以上になったら1に戻す
        if (fade.intensity > 1) fade.intensity = 1;
    }*/

    public void FadeIn()
    {
        fade.intensity -= 1 * Time.deltaTime;
            
        }

    private IEnumerator Test()
    {
        yield return new WaitForSeconds(3);
        fade.intensity += 1 * Time.deltaTime;
        if (fade.intensity > 1) fade.intensity = 1;
        
    }
        
    }



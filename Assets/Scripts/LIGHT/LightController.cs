using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

//ライトを制御するコンポーネント
public class LightController : MonoBehaviour
{
    public Light2D fade;

    //public GameObject spotLight;

    //ライトのon、offのbool変数
    public bool fadeOut = false;
    public bool fadeIn = false;

    private void Start()
    {
        //フェードアウトするので、最初は真っ暗にする
        fade.intensity = 0f;
        fadeOut = true;
    }


    private void Update()
    {
        if (fadeOut == true)
        {
            FadeOut();
        }

        if(fadeIn == true)
        {
            FadeIn();
        }
    }

    //フェードアウト
    private void FadeOut()
    {
        fade.intensity += Time.deltaTime;

        if(fade.intensity > 1)
        {
            fade.intensity = 1;
            fadeOut = false;
        }
    }

    //フェードイン
    private void FadeIn()
    {
        fade.intensity -= Time.deltaTime;
        if(fade.intensity < 0)
        {
            fade.intensity = 0;
            fadeIn = false;
        }
    }

    //スポットライトを有効にする関数
    /*public void spotLigthOn()
    {
        fade.intensity = 0;
        spotLight.SetActive(true);
    }*/

    }



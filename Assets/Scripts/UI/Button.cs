using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Button : MonoBehaviour
{
    public Image image;

    public float PushColor;

    public float alpha;

    private bool tweenOn = true; //アニメーションを一度だけ実行する為の変数

    private void Start()
    {

        if(image == null)
        {
            this.image = GetComponent<Image>();
            Debug.Log("nullあり");
        }
    }

    private void Update()
    {
        //UFOが画面から消えたら
        if (!UFO.ufo.gameObject.activeSelf && SceneController.zanki < 0)
        {
            if(tweenOn == true)
            {
                image.DOFade(0, 1f).SetEase(Ease.Linear).SetLink(gameObject);
                tweenOn = false;
            }
            
           
        }
    }

    //ボタンを押している間
    public void ButtonDonw()
    {
        this.image.color = new Color(PushColor, PushColor, PushColor, 1.0f);
    }

    //ボタンを離した瞬間
    public void ButtonUp()
    {
        this.image.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }





}

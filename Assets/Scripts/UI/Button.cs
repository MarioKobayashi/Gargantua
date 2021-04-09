using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Button : MonoBehaviour
{
    public Image image;

    public float PushColor;

    private void Start()
    {

        if(image == null)
        {
            this.image = GetComponent<Image>();
            Debug.Log("nullあり");
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

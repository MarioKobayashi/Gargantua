using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using DG.Tweening;

public class MoveButton : MonoBehaviour
{
   
    public Image image;

    public float PushColor;//ボタンを押した時の色

    private string ButtonName;

    private void Awake()
    {
        ButtonEvent();
    }

    private void Start()
    {
        ButtonName = gameObject.name;//ボタンの名前を取得

        if(image == null)
        {
            this.image = GetComponent<Image>();
        }
    }

    //ボタンを押している間
    private void ButtonDownEvent(PointerEventData data)
    {
        ButtonDonwColor();

        if(ButtonName == "UpButton")
        {
            UFO.ufo.UpButtonDown();
        }

        if (ButtonName == "LButton")
        {
            UFO.ufo.LButtonDown();
        }

        if (ButtonName == "RButton")
        {
            UFO.ufo.RButtonDown();
        }
    }

    private void ButtonUpEvent(PointerEventData data)
    {
        ButtonUp();

        if (ButtonName == "UpButton")
        {
           UFO.ufo.UpButtonUP();
        }

        if (ButtonName == "LButton")
        {
            UFO.ufo.LButtonUP();
        }

        if (ButtonName == "RButton")
        {
            UFO.ufo.RButtonUP();
        }
    }

    private void ButtonEvent()
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry pointerDownEntry = new EventTrigger.Entry();
        pointerDownEntry.eventID = EventTriggerType.PointerDown;
        pointerDownEntry.callback.AddListener((data) => { ButtonDownEvent((PointerEventData)data); });
        trigger.triggers.Add(pointerDownEntry);

        EventTrigger.Entry pointerUpEntry = new EventTrigger.Entry();
        pointerUpEntry.eventID = EventTriggerType.PointerUp;
        pointerUpEntry.callback.AddListener((data) => { ButtonUpEvent((PointerEventData)data); });
        trigger.triggers.Add(pointerUpEntry);
    }



    //ボタンを押している時のカラー
    public void ButtonDonwColor()
    {
        this.image.color = new Color(PushColor, PushColor, PushColor, 1.0f);
    }

    //ボタンを離した時のカラー
    public void ButtonUp()
    {
        this.image.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    
}
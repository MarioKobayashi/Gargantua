using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class DotweenTest3 : MonoBehaviour
{
    SpriteRenderer Renderer;

    

    void Start()
    {

        this.Renderer = GetComponent<SpriteRenderer>();
        //カラーを変える、アルファの値を変えて点滅も可能
        this.Renderer.DOColor(new Color(1, 0, 0, 0), 2f)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo)
            .SetLink(gameObject);

    }

    
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour
{
    public Text text;

    [SerializeField]
    private float delayTime = 2;//遅延時間

    [SerializeField]
    private float fadeOutTime = 1;//何秒でalpha値を1にするか

    private float alpha = 0;//カラーのアルファ値

    private float setTimer = 0;//コンポーネントが有効になってからの時間

    private void Awake()
    {
        //最初に文字を透明にする
        text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
    }

   

    private void Update()
    {
        if(alpha <= 1)
        {
            this.setTimer += Time.deltaTime;

            //遅延時間を超えたら処理を開始する
            if(setTimer > delayTime)
            {
                this.alpha += Time.deltaTime / fadeOutTime;
                text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);

                if (alpha > 1) alpha = 1;
                

            }
  
        }
    }
}

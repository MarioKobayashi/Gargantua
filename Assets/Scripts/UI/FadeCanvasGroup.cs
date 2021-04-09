using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeCanvasGroup : MonoBehaviour
{
    [SerializeField]
    private float DurationTime = 1f;

    [SerializeField]
    private CanvasGroup canvasGroup = null;

private Sequence seq;

    private bool tweenOn = true;

    private void Start()
    {
        this.seq = DOTween.Sequence(); 
    }

    private void Update()
    {
        
        //UFOが消える&&残機が0より小さい
        if (!UFO.ufo.gameObject.activeSelf && SceneController.zanki < 0)
        {
           if(tweenOn == true)
            {
                this.canvasGroup.DOFade(0, DurationTime).SetEase(Ease.Linear).SetLink(gameObject);
                tweenOn = false;
            }
        }
    }

   








}

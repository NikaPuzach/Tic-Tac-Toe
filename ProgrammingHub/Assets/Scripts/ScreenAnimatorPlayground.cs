using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScreenAnimatorPlayground : MonoBehaviour
{
    [SerializeField] Image hightlight;

    [SerializeField] Color hightlightColorPale;
    [SerializeField] Color hightlightColorBright;

    float buttonAnimationDuration = 0.5f;

    
    private void Start()
    {
        AnimateFrame();
    }

    private void AnimateFrame()
    {
        hightlight.color = hightlightColorPale;

        var buttonTweenColor = DOTween.To(
            () => hightlight.color,
            c => hightlight.color = c,
            hightlightColorBright,
            buttonAnimationDuration);

        buttonTweenColor.SetEase(Ease.Flash);

        buttonTweenColor.SetLoops(-1, LoopType.Yoyo);
    }

    
}

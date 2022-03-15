using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TextField = TMPro.TextMeshProUGUI;

public class ScreenAnimatorYourHero : MonoBehaviour
{
    [SerializeField] Image buttonImage;

    [SerializeField] Color buttonColorPale;
    [SerializeField] Color buttonColorBright;

    float buttonAnimationDuration = 0.5f;

    private void Start()
    {
        AnimateButton();
    }

    private void AnimateButton()
    {
        buttonImage.color = buttonColorPale;

        var buttonTweenColor = DOTween.To(
            () => buttonImage.color,
            c => buttonImage.color = c,
            buttonColorBright,
            buttonAnimationDuration);

        buttonTweenColor.SetEase(Ease.InOutFlash);

        buttonTweenColor.SetLoops(-1, LoopType.Yoyo);
    }
}

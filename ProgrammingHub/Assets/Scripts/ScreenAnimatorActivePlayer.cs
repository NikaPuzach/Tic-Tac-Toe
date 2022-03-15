using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScreenAnimatorActivePlayer : MonoBehaviour
{
    [SerializeField] Image firstPlayerImage;
    [SerializeField] Image secondPlayerImage;

    private void Start()
    {
        AnimateActivePlayer();
    }

    private void Update()
    {
        AnimateActivePlayer();
    }

    //изменяем размер изображения ативного игрока
    private void AnimateActivePlayer()
    {
        //check if this player is active - adjust size (make it twice bigger for ex)
        if (GamePlayController.Instance.chosenPlayer.team
            == Player.Teams.Circle)
        {
            MakeBigger(secondPlayerImage);
            MakeSmaller(firstPlayerImage);
        }
        else 
        {
            MakeBigger(firstPlayerImage);
            MakeSmaller(secondPlayerImage);
        }

    }

    private void MakeBigger(Image image)
    {
        image.transform.localScale = Vector3.one / 2;

        var imageTweenSize = DOTween.To(
            () => image.transform.localScale,
            s => image.transform.localScale = s,
            Vector3.one,
            1f);

        imageTweenSize.SetEase(Ease.OutElastic);
    }

    private void MakeSmaller(Image image)
    {
        image.transform.localScale = Vector3.one;

        var imageTweenSize = DOTween.To(
            () => image.transform.localScale,
            s => image.transform.localScale = s,
            Vector3.one / 2,
            1f);

        imageTweenSize.SetEase(Ease.InOutFlash);
    }
}

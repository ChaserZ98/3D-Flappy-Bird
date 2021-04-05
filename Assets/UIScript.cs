using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void fadeOut(float second)
    {
        canvasGroup.DOFade(0, second).OnComplete(new TweenCallback(() => { gameObject.SetActive(false); }));
    }

    public void fadeIn(float second)
    {
        gameObject.SetActive(true);
        foreach (Transform item in gameObject.transform)
        {
            item.gameObject.SetActive(true);
        }
        canvasGroup.DOFade(1, second);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NavMenu : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private GameObject navPanel;

    [SerializeField] private float cardAnimMoveToHidePointDuration    = 0.1f;
    [SerializeField] private float cardAnimMoveHiddenPointDuration    = 0.1f;
    [SerializeField] private float cardAnimMoveToVisiblePointDuration = 0.1f;
    [SerializeField] private float cardAnimMoveToStartPointDuration   = 0.1f;

    private bool isOpen = true;
    
    public void Toggle()
    {
        if (isOpen)
        {
            transform.DOMove(new Vector3(-450, 0), cardAnimMoveToHidePointDuration)
                .OnComplete(delegate()
                {
                    navPanel.transform.DOMove(new Vector3(-500, 0), cardAnimMoveHiddenPointDuration);
                    arrow.transform.DORotate(new Vector3(0, 0, 90), cardAnimMoveHiddenPointDuration);
                });
        }
        else
        {
            arrow.transform.DORotate(new Vector3(0, 0, -90), cardAnimMoveToVisiblePointDuration);
            navPanel.transform.DOMove(new Vector3(-450, 0), cardAnimMoveToVisiblePointDuration)
                .OnComplete(delegate()
                {
                    transform.DOMove(new Vector3(0, 0, 0), cardAnimMoveToStartPointDuration);
                });
        }

        isOpen = !isOpen;
    }
}

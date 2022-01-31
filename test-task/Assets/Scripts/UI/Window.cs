using DG.Tweening;
using UnityEngine;


public class Window : MonoBehaviour
{
    [SerializeField] private float fadeInTime;
    [SerializeField] private float fadeOutTime;
    private CanvasGroup _group;

    protected virtual void Init()
    {
        _group = GetComponent<CanvasGroup>();
    }

    protected void ShowWindow()
    {
        DoFade(1, fadeInTime);
    }

    protected void HideWindow()
    {
        DoFade(0, fadeOutTime);
    }

    private void DoFade(int value, float time)
    {
        _group.DOFade(value, time).OnComplete(() => SetInteractable(value == 1));
    }

    private void SetInteractable(bool active)
    {
        _group.interactable = active;
        _group.blocksRaycasts = active;
    }
}

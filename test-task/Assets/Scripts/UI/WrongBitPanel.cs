using Bits;
using DG.Tweening;
using UnityEngine;

public class WrongBitPanel : MonoBehaviour
{
    private CanvasGroup _panel;
    private const float FadeTime = 0.15f;
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _panel = GetComponent<CanvasGroup>();
        BitsCollection.WrongBitClicked += ShowPanel;
    }

    private void ShowPanel()
    {
        _panel.DOFade(1, FadeTime).OnComplete(() =>
        {
            _panel.DOFade(0, FadeTime);
        });
    }
}

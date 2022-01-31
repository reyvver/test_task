using System.Collections.Generic;
using Bits;
using Game;
using Player;
using UnityEngine;

public class BitPanelUI : MonoBehaviour
{
    [SerializeField] private GameObject bitsRow;
    [SerializeField] private List<BitStatic> bits;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        foreach (var bit in bits)
        {
            bit.BitClicked += OnBitStaticClicked;
        }
        
        GameState.GameStatusChanged += OnGameStatusChanged;
    }

    private void OnGameStatusChanged(GameState.GameStatus status)
    {
        switch (status)
        {
            case GameState.GameStatus.GameStarted:
            {
                HideOrShowRow(true);
                ToggleAllStaticBits();
                break;
            }
            case GameState.GameStatus.GameFinished:
            {
                StopAllStaticBits();
                HideOrShowRow(false);
                break;
            }
        }
    }

    private void ToggleAllStaticBits()
    {
        foreach (var bit in bits)
        {
            bit.StartColorChange();
        }
    }

    private void StopAllStaticBits()
    {
        foreach (var bit in bits)
        {
            bit.StopColorChange();
        }
    }

    private void HideOrShowRow(bool active)
    {
        bitsRow.SetActive(active);
    }

    private void OnBitStaticClicked(Bit bit)
    {
        var bitStatic = (BitStatic)bit;
        
        if (!bitStatic.Active) return;
        PlayerInfo.UpdateScore(bit.BitPoints);
    }

}

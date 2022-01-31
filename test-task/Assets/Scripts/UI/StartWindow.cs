using Game;
using UnityEngine;
using UnityEngine.UI;

public class StartWindow : Window
{
    [SerializeField] private Button buttonStart;

    private void Awake()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();
        buttonStart.onClick.AddListener(OnButtonStartClicked);
        GameState.GameStatusChanged += OnGameStatusChanged;
    }

    private void OnButtonStartClicked()
    {
        GameManager.StartGame();
    }

    private void OnGameStatusChanged(GameState.GameStatus status)
    {
        switch (status)
        {
            case GameState.GameStatus.GameStarted:
            {
                HideWindow();
                break;
            }
            case GameState.GameStatus.GameFinished:
            {
                ShowWindow();
                break;
            }
        }
    }
}

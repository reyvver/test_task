using Game;

public class GameWindow : Window
{
    private void Awake()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();
        GameState.GameStatusChanged += OnGameStatusChanged;
    }

    private void OnGameStatusChanged(GameState.GameStatus status)
    {
        switch (status)
        {
            case GameState.GameStatus.GameStarted:
            {
                ShowWindow();
                break;
            }
            case GameState.GameStatus.GameFinished:
            {
                HideWindow();
                break;
            }
        }
    }
}
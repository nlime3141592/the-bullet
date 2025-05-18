using System;
using UnityEngine.UI;

namespace Unchord
{
    public class UIMainView : UIView
    {
        private Button _btnGameMode;
        private Button _btnLeaderBoard;
        private Button _btnStart;

        private int _gameModeCount;
        private int _gameMode;

        protected override void Awake()
        {
            base.Awake();

            _btnGameMode = transform.Find("GameModeButton").GetComponent<Button>();
            _btnLeaderBoard = transform.Find("LeaderBoardButton").GetComponent<Button>();
            _btnStart = transform.Find("GameStartButton").GetComponent<Button>();

            _btnGameMode.onClick.AddListener(OnGameModeButtonClicked);
            _btnLeaderBoard.onClick.AddListener(OnLeaderBoardButtonClicked);
            _btnStart.onClick.AddListener(OnStartButtonClicked);

            _gameModeCount = Enum.GetValues(typeof(_GameMode)).Length;
            _gameMode = 0;
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            GameManager gm = GameManager.Instance;

            _gameMode = (int)gm.CurrentGameMode;
            ShowGameModeIcon(_gameMode);
        }

        private void ShowGameModeIcon(int gameMode)
        {

        }

        private void OnGameModeButtonClicked()
        {
            UnityEngine.Debug.Log("OnGameModeButtonClicked");
            _gameMode = (_gameMode + 1) % _gameModeCount;
            ShowGameModeIcon(_gameMode);
        }

        private void OnLeaderBoardButtonClicked()
        {
            UnityEngine.Debug.Log("OnLeaderBoardButtonClicked");
        }

        private void OnStartButtonClicked()
        {
            UnityEngine.Debug.Log("OnStartButtonClicked");

            UIManager um = UIManager.Instance;
            GameManager gm = GameManager.Instance;

            um.GetView("UIBlackView").HideImmediate();
            um.GetView("UIMainView").HideImmediate();
            gm.CameraSight.SetPositionForGame();
            um.GetView("UIGameView").ShowImmediate();
            gm.StartGame((_GameMode)_gameMode);
        }
    }
}
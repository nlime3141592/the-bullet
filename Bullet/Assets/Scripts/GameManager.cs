using System.Collections.Generic;

namespace Unchord
{
    public sealed class GameManager : Singleton<GameManager>
    {
        public bool GameStarted { get; private set; }

        public float ElapsedPlayingTimestamp { get; private set; }
        public float AbsolutePlayingTimestamp { get; private set; }

        public int MaxScore { get; private set; }
        public int CurrentScore { get; private set; }
        public int MaxCombo { get; private set; }
        public int CurrentCombo { get; private set; }

        public GameData GameData { get; private set; }

        #region Inspector Properties
        public float comboDuration = 3.0f;
        #endregion

        private float _lastComboTimestamp;

        public void StartGame()
        {
            GameStarted = true;
        }

        public void EndGame()
        {
            StoreGameData();
            GameData.Save();

            GameStarted = false;

            ElapsedPlayingTimestamp = 0.0f;
            AbsolutePlayingTimestamp = 0.0f;

            CurrentScore = 0;
            CurrentCombo = 0;

            _lastComboTimestamp = 0.0f;
        }

        private void StoreGameData()
        {
            ++GameData.totalGamePlayCount;

            GameData.totalElapsedPlaytime += ElapsedPlayingTimestamp;
            GameData.totalAbsolutePlaytime += AbsolutePlayingTimestamp;

            GameData.totalScore += CurrentScore;
            GameData.maxScore = MaxScore;

            GameData.totalCombo += CurrentCombo;
            GameData.maxCombo = MaxCombo;
        }

        private void Awake()
        {
            this.GameData = GameData.Instance;
        }

        private void Update()
        {
            if (!GameStarted)
                return;

            ClearCombo();
        }

        public void AddScore()
        {
            if (++CurrentScore >= MaxScore)
                MaxScore = CurrentScore;
        }

        public void AddCombo()
        {
            if (++CurrentCombo >= MaxCombo)
                MaxCombo = CurrentCombo;

            _lastComboTimestamp = ElapsedPlayingTimestamp;
        }

        private void ClearCombo()
        {
            if (ElapsedPlayingTimestamp - _lastComboTimestamp < comboDuration)
                return;

            CurrentCombo = 0;
        }
    }
}
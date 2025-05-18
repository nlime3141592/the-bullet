using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Unchord
{
    public sealed class GameManager : Singleton<GameManager>
    {
        public bool GameStarted { get; private set; }
        public bool GamePaused { get; set; }

        public _GameMode CurrentGameMode { get; private set; }

        public float ElapsedPlayingTimestamp { get; private set; }
        public float AbsolutePlayingTimestamp { get; private set; }
        public bool TimestampDisabled { get; set; }

        public int MaxScore { get; private set; }
        public int CurrentScore { get; private set; }
        public int MaxCombo { get; private set; }
        public int CurrentCombo { get; private set; }

        public bool AdWatched { get; set; }

        public ObjectPool<Bullet> BulletPool { get; private set; }
        public ObjectPool<Line> LinePool { get; private set; }

        public GameData GameData { get; private set; }

        public Camera MainCamera { get; private set; }
        public CameraSight CameraSight { get; private set; }

        #region Inspector Properties
        public float comboDuration = 3.0f;
        #endregion

        private float _lastComboTimestamp;
        private float _generationTimestamp;

        private List<Bullet> _bList;
        private List<Line> _lList;

        public void StartGame(_GameMode gameMode)
        {
            CurrentGameMode = gameMode;
            GameStarted = true;
        }

        public IEnumerator EndGame()
        {
            ReleaseAllBullets();
            ReleaseAllLines();

            GameStarted = false;

            StoreGameData();
            GameData.Save();

            yield return new WaitForSecondsRealtime(2.0f);

            // TODO: Show result gui.

            ClearPlayingData();
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

        private void Awake()
        {
            this.GameData = GameData.Instance;

            BulletPool = new ObjectPool<Bullet>(OnCreateBullet, OnGetBullet, OnReleaseBullet, null, true, 32, 1024);
            LinePool = new ObjectPool<Line>(OnCreateLine, OnGetLine, OnReleaseLine, null, true, 32, 1024);

            MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
            CameraSight = MainCamera.GetComponent<CameraSight>();

            _bList = new List<Bullet>(32);
            _lList = new List<Line>(32);

            ClearPlayingData();
        }

        private void Update()
        {
            if (!GameStarted)
                return;

            UpdateTimestamp();
            UpdateCombo();
            UpdateGeneration();
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

        private void UpdateCombo()
        {
            if (ElapsedPlayingTimestamp - _lastComboTimestamp < comboDuration)
                return;

            CurrentCombo = 0;
        }

        private void UpdateTimestamp()
        {
            if (!TimestampDisabled)
                ElapsedPlayingTimestamp += Time.deltaTime;

            AbsolutePlayingTimestamp += Time.deltaTime;
        }

        private void ClearPlayingData()
        {
            ElapsedPlayingTimestamp = 0.0f;
            AbsolutePlayingTimestamp = 0.0f;

            CurrentGameMode = _GameMode.Score;

            CurrentScore = 0;
            CurrentCombo = 0;

            _lastComboTimestamp = 0.0f;
            _generationTimestamp = 1.0f;

            AdWatched = false;
        }

        private void UpdateGeneration()
        {
            if (_generationTimestamp > ElapsedPlayingTimestamp)
                return;

            _generationTimestamp = GetNextGenerationDelay();

            int genCountPerFrame = GetGenerationCount();

            for (int i = 0; i < genCountPerFrame; ++i)
            {
                GenerateBullet();
            }
        }

        private void GenerateBullet()
        {
            float lx = Random.Range(-0.5f, 2.5f);
            float ly = 0.48f;
            float lz = -0.5f;

            float bx = lx;
            float by = 0.7f;
            float bz = -10.5f;

            if (Random.value < 0.5f)
            {
                // swap two values.
                (lx, lz) = (lz, lx);
                (bx, bz) = (bz, bx);
            }

            Bullet bullet = BulletPool.Get();
            Line line = LinePool.Get();

            bullet.transform.position = new Vector3(bx, by, bz);
            line.transform.position = new Vector3(lx, ly, lz);
        }

        private void ReleaseAllBullets()
        {
            for (int i = _bList.Count - 1; i >= 0; --i)
            {
                BulletPool.Release(_bList[i]);
            }
        }

        private void ReleaseAllLines()
        {
            for (int i = _lList.Count - 1; i >= 0; --i)
            {
                LinePool.Release(_lList[i]);
            }
        }

        private float GetNextGenerationDelay()
        {
            int w = CurrentScore / 40;

            float min = 1.1f - 0.1f * (float)w;
            float max = 1.2f - 0.1f * (float)Mathf.Min(1, w);

            return Random.Range(min, max);
        }

        private int GetGenerationCount()
        {
            int maxExclusive = 2 + (CurrentScore / 50);

            return Random.Range(1, maxExclusive);
        }

        private Bullet OnCreateBullet()
        {
            // TODO: should implement.

            return null;
        }

        private void OnGetBullet(Bullet bullet)
        {
            _bList.Add(bullet);
            bullet.gameObject.SetActive(true);
        }

        private void OnReleaseBullet(Bullet bullet)
        {
            _bList.Remove(bullet);
            bullet.gameObject.SetActive(false);
        }

        private Line OnCreateLine()
        {
            // TODO: should implement.

            return null;
        }

        private void OnGetLine(Line line)
        {
            _lList.Add(line);
            line.gameObject.SetActive(true);
        }

        private void OnReleaseLine(Line line)
        {
            _lList.Remove(line);
            line.gameObject.SetActive(false);
        }
    }
}
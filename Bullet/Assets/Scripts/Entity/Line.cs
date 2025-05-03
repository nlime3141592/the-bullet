using UnityEngine;

namespace Unchord
{
    public class Line : MonoBehaviour
    {
        #region Inspector Properties
        public float lineDuration = 0.5f;
        #endregion

        private float _releaseTimestamp;

        private void OnEnable()
        {
            _releaseTimestamp = GameManager.Instance.ElapsedPlayingTimestamp + lineDuration;
        }

        private void Update()
        {
            if (_releaseTimestamp < GameManager.Instance.ElapsedPlayingTimestamp)
                return;

            GameManager.Instance.LinePool.Release(this);
        }
    }
}
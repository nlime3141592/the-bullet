using UnityEngine;

namespace Unchord
{
    public class Bullet : MonoBehaviour
    {
        public float Speed { get; set; }
        public Vector3 Direction { get; set; }

        #region Inspector Properties
        public float grazingThreshold = 0.05f;
        #endregion

        private float _grazingAreaEnteredTimestamp;
        private bool _comboApplied;

        public void OnPlayerGrazingAreaEnter()
        {
            _grazingAreaEnteredTimestamp = GameManager.Instance.ElapsedPlayingTimestamp;
        }

        public void OnPlayerGrazingAreaExit()
        {
            if (_comboApplied)
                return;

            GameManager gm = GameManager.Instance;

            if (gm.ElapsedPlayingTimestamp - _grazingAreaEnteredTimestamp >= _grazingAreaEnteredTimestamp)
            {
                gm.AddCombo();
                _comboApplied = true;
            }
        }

        public void OnBulletEndpointReached()
        {
            GameManager gm = GameManager.Instance;

            gm.AddScore();
            gm.BulletPool.Release(this);
        }

        private void OnEnable()
        {
            _grazingAreaEnteredTimestamp = -1.0f;
            _comboApplied = false;
        }

        private void FixedUpdate()
        {
            transform.position += Speed * Time.fixedDeltaTime * Direction;
        }
    }
}
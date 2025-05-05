using UnityEngine;

namespace Unchord
{
    public class CameraSight : MonoBehaviour
    {
        #region Inspector Properties
        public float targetDepth = 9.0f;
        public float targetDistance = 5.848f;

        public float yPosOnIdle = 3.0f;
        public float yPosOnGame = 4.5f;

        public float traceSpeed = 3.5f;
        #endregion

        private Camera _camera;
        private float _aspect;
        private float _posY;

        public void SetPositionForIdle()
        {
            _posY = yPosOnIdle;
        }

        public void SetPositionForIdleImmediate()
        {
            _posY = yPosOnIdle;
            transform.position = new Vector3(transform.position.x, _posY, transform.position.z);
        }

        public void SetPositionForGame()
        {
            _posY = yPosOnGame;
        }

        public void SetPositionForGameImmediate()
        {
            _posY = yPosOnGame;
            transform.position = new Vector3(transform.position.x, _posY, transform.position.z);
        }

        private void Awake()
        {
            _camera = GetComponent<Camera>();
            
            SetPositionForIdleImmediate();
            SetFOV();
        }

        private void Update()
        {
            UpdateFOV();
            UpdatePosY();
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            if (_camera == null)
                _camera = GetComponent<Camera>();

            float x = _camera.pixelWidth;
            float y = _camera.pixelHeight * 0.5f;
            float z = targetDepth;

            Vector3 anchorLeft0 = new Vector3(0.0f, y, _camera.nearClipPlane);
            Vector3 anchorLeft1 = new Vector3(0.0f, y, targetDepth);
            Vector3 anchorRight0 = new Vector3(x, y, _camera.nearClipPlane);
            Vector3 anchorRight1 = new Vector3(x, y, targetDepth);

            Vector3 pointLeft0 = _camera.ScreenToWorldPoint(anchorLeft0);
            Vector3 pointLeft1 = _camera.ScreenToWorldPoint(anchorLeft1);
            Vector3 pointRight0 = _camera.ScreenToWorldPoint(anchorRight0);
            Vector3 pointRight1 = _camera.ScreenToWorldPoint(anchorRight1);

            Gizmos.color = Color.green;
            Gizmos.DrawLine(pointLeft0, pointRight0);
            Gizmos.DrawLine(pointLeft0, pointLeft1);
            Gizmos.DrawLine(pointLeft1, pointRight1);
            Gizmos.DrawLine(pointRight0, pointRight1);

            Debug.Log(Vector3.Distance(pointLeft1, pointRight1));
        }
#endif

        private void UpdateFOV()
        {
            if (_aspect != _camera.aspect)
            {
                _aspect = _camera.aspect;
                SetFOV();
            }
        }

        private void UpdatePosY()
        {
            if (Mathf.Abs(transform.position.y - _posY) < 0.001f)
                return;

            float y = Mathf.Lerp(transform.position.y, _posY, traceSpeed * Time.deltaTime);

            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }

        private void SetFOV()
        {
            float targetHeight = targetDistance / _camera.aspect;
            float fov = 2.0f * Mathf.Atan(0.5f * targetHeight / targetDepth) * Mathf.Rad2Deg;

            _camera.fieldOfView = fov;
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace Unchord
{
    public sealed class UICarousel : UIView, IUICarousel
    {
        //public bool IsCyclicCarousel { get; set; } = false;

        public int CurrentBanner => _currentBanner;

        #region Inspector Properties
        public float spacing;
        public float traceSpeed = 15.0f;
        #endregion

        private RectTransform _rectTransform;
        private Rect _rect;
        private int _currentBanner;

        private RectTransform _bannerL;
        private RectTransform _bannerC;
        private RectTransform _bannerR;
        
        public override void Hide()
        {
            if (transform.childCount == 0)
                return;

            //Banners[_currentBanner].Hide();
        }

        public override void HideImmediate()
        {
            if (transform.childCount == 0)
                return;

            //Banners[_currentBanner].HideImmediate();
        }

        public override void Show()
        {
            if (transform.childCount == 0)
                return;

            //Banners[_currentBanner].Show();
        }

        public override void ShowImmediate()
        {
            if (transform.childCount == 0)
                return;

            //Banners [_currentBanner].ShowImmediate();
        }

        public void SetBannerImmediate(int index)
        {
            _bannerL?.gameObject.SetActive(false);
            _bannerC?.gameObject.SetActive(false);
            _bannerR?.gameObject.SetActive(false);

            UnityEngine.Debug.Assert(index >= 0 && index < transform.childCount);

            _bannerC = transform.GetChild(index).GetComponent<RectTransform>();
            _bannerC.gameObject.SetActive(true);

            if (index > 0)
            {
                _bannerL = transform.GetChild(index - 1).GetComponent<RectTransform>();
                _bannerL.gameObject.SetActive(true);
            }
            else
                _bannerL = null;

            if (index < transform.childCount - 1)
            {
                _bannerR = transform.GetChild(index + 1).GetComponent<RectTransform>();
                _bannerR.gameObject.SetActive(true);
            }
            else
                _bannerR = null;
        }

        public void Next()
        {
            if (transform.childCount <= 1)
                return;
            else if (_currentBanner + 1 == transform.childCount)
                return;

            _bannerL?.gameObject.SetActive(false);
            _bannerL = transform.GetChild(_currentBanner).GetComponent<RectTransform>();
            _bannerC = transform.GetChild(++_currentBanner).GetComponent<RectTransform>();

            if (_currentBanner + 1 < transform.childCount)
            {
                _bannerR = transform.GetChild(_currentBanner + 1).GetComponent<RectTransform>();
                _bannerR.gameObject.SetActive(true);
            }
            else
                _bannerR = null;
        }

        public void Prev()
        {
            if (transform.childCount <= 1)
                return;
            else if (_currentBanner == 0)
                return;

            _bannerR?.gameObject.SetActive(false);
            _bannerR = transform.GetChild(_currentBanner).GetComponent<RectTransform>();
            _bannerC = transform.GetChild(--_currentBanner).GetComponent<RectTransform>();

            if (_currentBanner - 1 >= 0)
            {
                _bannerL = transform.GetChild(_currentBanner - 1).GetComponent<RectTransform>();
                _bannerL.gameObject.SetActive(true);
            }
            else
                _bannerL = null;
        }

        protected override void Awake()
        {
            base.Awake();

            _rectTransform = GetComponent<RectTransform>();
            _rect = _rectTransform.rect;
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            for (int i = 0; i < transform.childCount; ++i)
                transform.GetChild(i).gameObject.SetActive(false);

            SetBannerImmediate(_currentBanner);
        }

        public int testIndex;

        protected override void Update()
        {
            base.Update();

            UpdateRectSize();
            UpdateCenterBannerPosition();
            UpdateSideBannerPosition();
        }

        private void UpdateRectSize()
        {
            if (_rect.size == _rectTransform.rect.size)
                return;

            _rect = _rectTransform.rect;

            for (int i = 0; i < _rectTransform.childCount; ++i)
            {
                SetChildAnchor(_rectTransform.GetChild(i).GetComponent<RectTransform>());
            }
        }

        private void UpdateCenterBannerPosition()
        {
            if (_bannerC.offsetMin.magnitude < 0.001f)
                return;

            Vector2 nextDiffVector = Vector2.Lerp(_bannerC.offsetMin, Vector2.zero, traceSpeed * Time.deltaTime);
            Vector2 deltaVector = nextDiffVector - _bannerC.offsetMin;

            _bannerC.offsetMin += deltaVector;
            _bannerC.offsetMax = _bannerC.offsetMin;
        }

        private void UpdateSideBannerPosition()
        {
            if (_bannerL != null)
            {
                _bannerL.offsetMin = _bannerC.offsetMin + Vector2.left * (_rect.size.x + spacing);
                _bannerL.offsetMax = _bannerL.offsetMin;
            }
            if (_bannerR != null)
            {
                _bannerR.offsetMin = _bannerC.offsetMin + Vector2.right * (_rect.size.x + spacing);
                _bannerR.offsetMax = _bannerR.offsetMin;
            }
        }

        private void SetChildAnchor(RectTransform child)
        {
            child.anchorMin = Vector2.zero;
            child.anchorMax = Vector2.one;
            child.pivot = 0.5f * Vector2.one;
        }
    }
}
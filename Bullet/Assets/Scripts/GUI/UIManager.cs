using System.Collections.Generic;
using UnityEngine;

namespace Unchord
{
    public class UIManager : Singleton<UIManager>
    {
        private Canvas _canvas;
        private List<UITweener> _tweenerList;
        private List<UIView> _views;
        private Dictionary<string, UIView> _viewDict;

        public UISingleColorView testView;

        public void SubscribeTweener(UITweener tweener)
        {
            if (!_tweenerList.Contains(tweener))
                _tweenerList.Add(tweener);
        }

        public void UnsubscribeTweener(UITweener tweener)
        {
            if (_tweenerList.Contains(tweener))
                _tweenerList.Remove(tweener);
        }

        public void SortView()
        {
            _views.Sort(CompareViewOrder);

            for (int i = 0; i < _views.Count; ++i)
            {
                _views[i].transform.SetSiblingIndex(i);
            }
        }

        private void Awake()
        {
            _canvas = FindAnyObjectByType<Canvas>();
            _tweenerList = new List<UITweener>(8);
            _views = new List<UIView>(16);
            _viewDict = new Dictionary<string, UIView>(16);
        }

        private void Start()
        {
            UIView fadeView = GetView("UIFadeView");
            UIView mainView = GetView("UIMainView");
            UICarousel mainCarousel = mainView.GetComponentInChildren<UICarousel>();

            mainCarousel.onBannerChanged += OnMainCarouselBannerChanged;

            fadeView.ShowImmediate();
            mainView.ShowImmediate();
            mainCarousel.SetBannerImmediate(1);
            mainCarousel.ShowImmediate();
            fadeView.Hide();
        }

        private void Update()
        {
            UpdateTweeners();
        }

        private void UpdateTweeners()
        {
            for (int i = _tweenerList.Count - 1; i >= 0; --i)
                _tweenerList[i].Update();
        }

        private int CompareViewOrder(UIView u, UIView v)
        {
            if (u.ViewType < v.ViewType)
                return -1;
            else if (u.ViewType > v.ViewType)
                return 1;
            else if (u.ViewOrder < v.ViewOrder)
                return -1;
            else if (u.ViewOrder > v.ViewOrder)
                return 1;
            else
                return 0;
        }

        public UIView GetView(string viewName)
        {
            string root = "Prefabs/GUIs/Views/";
            string path = root + viewName;

            if (_viewDict.ContainsKey(path))
                return _viewDict[path];

            UIView resource = Resources.Load<UIView>(root + viewName);
            UIView instance = GameObject.Instantiate<UIView>(resource);

            instance.transform.SetParent(_canvas.transform, false);
            instance.HideImmediate();

            _viewDict.Add(path, instance);
            _views.Add(instance);

            this.SortView();

            return instance;
        }

        private void OnMainCarouselBannerChanged(UICarousel carousel)
        {
            if (carousel.CurrentBanner == 1)
                GetView("UIBlackView").Hide();
            else
                GetView("UIBlackView").Show();
        }
    }
}
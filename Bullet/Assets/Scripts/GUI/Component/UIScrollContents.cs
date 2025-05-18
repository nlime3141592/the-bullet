using UnityEngine;
using UnityEngine.UI;

namespace Unchord
{
    public class UIScrollContents : UIElement
    {
        private RectTransform _content;
        private VerticalLayoutGroup _layout;

        private int _childCount;

        protected override void Awake()
        {
            base.Awake();

            _content = GetComponent<RectTransform>();
            _layout = GetComponent<VerticalLayoutGroup>();
        }

        protected override void Start()
        {
            base.Start();

            _childCount = 0;
            _content.offsetMin = Vector2.zero;
            _content.offsetMax = Vector2.zero;
        }

        protected override void Update()
        {
            base.Update();

            UpdateHeight();
        }

        private void UpdateHeight()
        {
            if (_childCount == _content.childCount)
                return;

            _childCount = _content.childCount;

            float totalPadding = _layout.padding.top + _layout.padding.bottom;
            float totalSpacing = _layout.spacing * (_content.childCount - 1);
            float sumHeight = 0.0f;

            if (totalSpacing < 0.0f)
                totalSpacing = 0.0f;

            for (int i = 0; i < _content.childCount; ++i)
            {
                RectTransform child = _content.GetChild(i).GetComponent<RectTransform>();

                sumHeight += child.rect.size.y;
            }

            float curHeight = _content.offsetMax.y - _content.offsetMin.y;
            float subHeight = (totalPadding + totalSpacing + sumHeight) - curHeight;

            _content.offsetMin += Vector2.down * subHeight;
        }
    }
}
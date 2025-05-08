using UnityEngine;

namespace Unchord
{
    public class UIView : UIElement, IUIView
    {
        public UIViewType ViewType
        {
            get => _viewType;
            set
            {
                if (_viewType == value)
                    return;

                _viewType = value;
                UIManager.Instance.SortView();
            }
        }

        public int ViewOrder
        {
            get => _viewOrder;
            set
            {
                if (_viewOrder == value)
                    return;

                _viewOrder = value;
                UIManager.Instance.SortView();
            }
        }

        #region Inspector Properties
        [SerializeField] private UIViewType _viewType = UIViewType.None;
        [SerializeField] private int _viewOrder;
        #endregion
    }
}
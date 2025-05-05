using UnityEngine;

namespace Unchord
{
    public abstract class UIElement : MonoBehaviour, IUIElement
    {
        public UIState State { get; protected set; } = UIState.Hidden;

        public abstract void Show();
        public abstract void ShowImmediate();
        public abstract void Hide();
        public abstract void HideImmediate();
    }
}
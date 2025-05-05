namespace Unchord
{
    public interface IUIElement
    {
        public UIState State { get; }

        void Show();
        void ShowImmediate();
        void Hide();
        void HideImmediate();
    }
}
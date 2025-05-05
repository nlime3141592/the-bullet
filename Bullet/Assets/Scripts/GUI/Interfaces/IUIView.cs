namespace Unchord
{
    public interface IUIView : IUIElement
    {
        public UIViewType ViewType { get; set; }
        public int ViewOrder { get; set; }
    }
}
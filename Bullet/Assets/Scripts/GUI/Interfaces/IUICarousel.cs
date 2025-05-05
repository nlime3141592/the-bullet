namespace Unchord
{
    public interface IUICarousel : IUIElement
    {
        //bool IsCyclicCarousel { get; set; }
        int CurrentBanner { get; }

        void Next();
        void Prev();
    }
}
using UnityEngine;
using UnityEngine.EventSystems;

namespace Unchord
{
    public class UICarouselButton : UnityEngine.UI.Button
    {
        public MoveDirection direction = MoveDirection.None;

        private UICarousel ui;

        protected override void Awake()
        {
            base.Awake();

            ui = transform.parent.parent.GetComponentInChildren<UICarousel>();

            base.onClick.AddListener(OnPointerClick);
        }

        protected override void Start()
        {
            base.Start();

            ui.onBannerChanged += OnBannerChanged;
        }

        private void OnPointerClick()
        {
            switch (direction)
            {
                case MoveDirection.Left:
                case MoveDirection.Down:
                    ui?.Prev();
                    break;

                case MoveDirection.Right:
                case MoveDirection.Up:
                    ui?.Next();
                    break;

                default:
                    UnityEngine.Debug.Assert(false, "move direction should be set left, down, right or up.");
                    break;
            }
        }

        private void OnBannerChanged(UICarousel carousel)
        {
            switch (direction)
            {
                case MoveDirection.Left:
                case MoveDirection.Down:
                    this.gameObject.SetActive(!carousel.IsFirstBanner);
                    break;

                case MoveDirection.Right:
                case MoveDirection.Up:
                    this.gameObject.SetActive(!carousel.IsLastBanner);
                    break;

                default:
                    UnityEngine.Debug.Assert(false, "move direction should be set left, down, right or up.");
                    break;
            }
        }
    }
}
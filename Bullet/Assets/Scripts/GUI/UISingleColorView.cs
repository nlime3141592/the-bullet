using UnityEngine;
using UnityEngine.UI;

namespace Unchord
{
    public class UISingleColorView : UIView
    {
        #region Inspector Properties
        public Color colorOnHidden;
        public Color colorOnShown;
        #endregion

        private UITweener _colorTweener;
        private Image _image;

        public override void Show()
        {
            gameObject.SetActive(true);
            _colorTweener.IsTweeningUp = true;
        }

        public override void ShowImmediate()
        {
            gameObject.SetActive(true);
            _colorTweener.SetToEnd(true);
        }

        public override void Hide()
        {
            _colorTweener.IsTweeningDown = true;
        }

        public override void HideImmediate()
        {
            _colorTweener.SetToStart(true);
        }

        protected override void Awake()
        {
            base.Awake();

            _image = GetComponent<Image>();

            _colorTweener = new UITweener();
            _colorTweener.TweeningSpeed = 1.5f;
            _colorTweener.UseUnscaledDeltaTimeTweening = false;

            _colorTweener.onTweeningUpdate += OnTweeningUpdate;
            _colorTweener.onTweeningComplete += OnTweeningCompleted;
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            UIManager.Instance.SubscribeTweener(_colorTweener);
        }

        private void OnTweeningUpdate(UITweener tweener, float tweeningValue)
        {
            UnityEngine.Debug.Assert(tweener.IsTweeningDown ^ tweener.IsTweeningUp);

            if (tweener.IsTweeningDown)
                base.State = UIState.Hiding;
            else
                base.State = UIState.Showing;

            _image.color = Color.Lerp(colorOnHidden, colorOnShown, tweeningValue);
        }

        private void OnTweeningCompleted(UITweener tweener, float tweeningValue)
        {
            UnityEngine.Debug.Assert(tweener.TweeningValue == 0.0f || tweener.TweeningValue == 1.0f);

            if (tweeningValue == 0.0f)
            {
                base.State = UIState.Hidden;
                UIManager.Instance.UnsubscribeTweener(_colorTweener);
                gameObject.SetActive(false);
            }
            else
                base.State = UIState.Shown;

            _image.color = Color.Lerp(colorOnHidden, colorOnShown, tweeningValue);
        }
    }
}
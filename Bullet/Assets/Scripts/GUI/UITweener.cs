using System;
using UnityEngine;

namespace Unchord
{
    public class UITweener
    {
        public float TweeningValue { get; set; }
        public float TweeningSpeed { get; set; }
        public bool UseUnscaledDeltaTimeTweening { get; set; } = false;

        public bool IsTweeningUp
        {
            get => _tweeningDirection == 1.0f;
            set => _tweeningDirection = value ? 1.0f : _tweeningDirection;
        }

        public bool IsTweeningDown
        {
            get => _tweeningDirection == -1.0f;
            set => _tweeningDirection = value ? -1.0f : _tweeningDirection;
        }

        public event Action<UITweener, float> onTweeningUpdate;
        public event Action<UITweener, float> onTweeningComplete;

        private float _tweeningDirection;

        public void Update()
        {
            if (_tweeningDirection == 0.0f)
                return;

            float dt = UseUnscaledDeltaTimeTweening ? Time.unscaledDeltaTime : Time.deltaTime;
            TweeningValue = Mathf.Clamp01(TweeningValue + TweeningSpeed * _tweeningDirection * dt);
            Publish();
        }

        public void SetToStart(bool useEventPublishing = false)
        {
            TweeningValue = 0.0f;

            if (useEventPublishing)
            {
                _tweeningDirection = -1.0f;
                Publish();
            }
            else
                _tweeningDirection = 0.0f;
        }

        public void SetToEnd(bool useEventPublishing = false)
        {
            TweeningValue = 1.0f;
            
            if (useEventPublishing)
            {
                _tweeningDirection = 1.0f;
                Publish();
            }
            else
                _tweeningDirection = 0.0f;
        }

        private void Publish()
        {
            if (TweeningValue > 0.0f && TweeningValue < 1.0f)
                onTweeningUpdate?.Invoke(this, TweeningValue);
            else if ((_tweeningDirection == -1.0f && TweeningValue == 0.0f) || (_tweeningDirection == 1.0f && TweeningValue == 1.0f))
            {
                _tweeningDirection = 0.0f;
                onTweeningComplete?.Invoke(this, TweeningValue);
            }
        }
    }
}
using UnityEngine;

namespace Unchord
{
    public abstract class UIElement : MonoBehaviour, IUIElement
    {
        public UIState State { get; protected set; } = UIState.Hidden;

        public virtual void Show()
        {

        }

        public virtual void ShowImmediate()
        {

        }

        public virtual void Hide()
        {

        }

        public virtual void HideImmediate()
        {

        }

        protected virtual void Awake()
        {

        }

        protected virtual void Start()
        {

        }

        protected virtual void OnEnable()
        {

        }

        protected virtual void Update()
        {

        }

        protected virtual void OnDisable()
        {

        }
    }
}
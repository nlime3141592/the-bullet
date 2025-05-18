using UnityEngine;

namespace Unchord
{
    public abstract class UIElement : MonoBehaviour, IUIElement
    {
        public UIState State { get; protected set; } = UIState.Hidden;

        public virtual void Show()
        {
            this.gameObject.SetActive(true);
        }

        public virtual void ShowImmediate()
        {
            this.gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            this.gameObject.SetActive(false);
        }

        public virtual void HideImmediate()
        {
            this.gameObject.SetActive(false);
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
using System;
using UnityEngine.EventSystems;

namespace Unchord
{
    public class UIJoystickArea : UIElement
        , IPointerDownHandler
        , IPointerUpHandler
        , IBeginDragHandler
        , IDragHandler
        , IEndDragHandler
    {
        public event Action<PointerEventData> onPointerDown;
        public event Action<PointerEventData> onPointerUp;
        public event Action<PointerEventData> onBeginDrag;
        public event Action<PointerEventData> onDrag;
        public event Action<PointerEventData> onEndDrag;

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            onPointerDown?.Invoke(eventData);
        }

        void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
        {
            onPointerUp?.Invoke(eventData);
        }

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            onBeginDrag?.Invoke(eventData);
        }

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            onDrag?.Invoke(eventData);
        }

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            onEndDrag?.Invoke(eventData);
        }
    }
}
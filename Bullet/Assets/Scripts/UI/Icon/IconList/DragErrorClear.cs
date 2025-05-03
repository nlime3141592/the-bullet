using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragErrorClear : Icon
{
    public override void OnBeginDrag(PointerEventData pad)
    {
        base.OnBeginDrag(pad);
    }

    public override void OnDrag(PointerEventData pad)
    {
        base.OnDrag(pad);
    }

    public override void OnScroll(PointerEventData pad)
    {
        base.OnScroll(pad);
    }

    public override void OnEndDrag(PointerEventData pad)
    {
        base.OnEndDrag(pad);
    }
}

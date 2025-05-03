using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// 매번 조이스틱을 클릭할 때 마다 중앙의 위치가 클릭한 지점으로 바뀌는 조이스틱 클래스
// GamePad 객체에 적용
public class UnFixedJoystick : Joystick
{
    protected override void JoystickInitialize()
    {
        base.JoystickInitialize();
        foreach (Image r in GameObject.FindObjectsOfType<Image>())
        {
            switch (r.gameObject.name)
            {
                case "JoystickBg":
                case "JoystickBt":
                    r.raycastTarget = false;
                    continue;
            }
        }
    }

    public override void OnPointerDown(PointerEventData pad)
    {
        Vector2 bg = UIDimentionChange.ScreenToCanvas(pad.position);
        Vector2 bt = UIDimentionChange.ScreenToCanvas(pad.position);
        SetPosition(joybg, bg);
        SetPosition(joybt, bt);
    }

    public override void OnDrag(PointerEventData pad)
    {
        base.OnDrag(pad); // 부모 클래스에 정의된 OnDrag() 함수 사용
    }

    public override void OnPointerUp(PointerEventData pad)
    {
        base.OnPointerUp(pad); // 부모 클래스에 정의된 OnPointerUp() 함수 사용
    }
}

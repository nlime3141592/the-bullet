using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// 조이스틱의 위치가 중앙으로 항상 고정되어 있는 조이스틱 클래스
// 조이스틱 버튼에 적용
public class FixedJoystick : Joystick
{
    protected override void JoystickInitialize()
    {
        base.JoystickInitialize(); // 부모 클래스에 정의된 JoystickInitialize() 함수 사용
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

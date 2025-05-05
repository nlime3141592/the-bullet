using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// 조이스틱에 관련된 기본적인 정보들을 가진 클래스
public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    // 조이스택 배경, 버튼
    protected RectTransform joybg;
    protected RectTransform joybt;

    // 조이스틱의 반지름
    // Canvas상에서의 최대 반지름이다.
    protected float radius;

    // Joystick Button이 Joystick의 중심으로 부터 움직인 방향과 거리
    protected Vector2 joystickVector;

    // Screen 크기(실제 기기 해상도)
    // Canvas 크기(캔버스의 가로는 아마 1080으로 고정했을 것임, 세로 길이는 실제 기기 해상도 비율에 영향을 받음)
    // UI가 들어있는 오브젝트의 최상위 오브젝트인 Canvas 오브젝트의 Canvas Scaler에서 설정 가능
    protected Vector2 ScreenSize;
    protected Vector2 CanvasSize;

    // 플레이어 객체
    //protected Player p;

    private void Start()
    {
        JoystickInitialize();
    }

    // 조이스틱 초기화
    protected virtual void JoystickInitialize()
    {
        // 조이스틱의 색
        Color temp = new Color(1, 1, 1, 1);

        // 오브젝트 탐색
        foreach (RectTransform r in GameObject.FindObjectsOfType<RectTransform>())
        {
            switch (r.gameObject.name) // 게임 오브젝트의 이름
            {
                // 1. 조이스틱의 컴포넌트를 저장
                // 2. 게임 오브젝트의 스프라이트 설정
                // 3. 조이스틱의 색깔 설정

                case "JoystickBg": // 조이스틱 배경의 초기 설정
                    joybg = r; // 컴포넌트 저장

                    // 이미지 로드
                    r.gameObject.GetComponent<Image>().sprite = new DataGet().Get_JoystickImages()[0]; // DataGet 클래스를 두어 다양한 종류의 데이터를 불러왔었음.

                    // 색깔 로드
                    temp = new DataGet().Get_OneNowThemeMaterial(CustomVariable.JoystickBgColor).color; // DataGet 클래스를 두어 다양한 종류의 데이터를 불러왔었음.
                    r.gameObject.GetComponent<Image>().color = temp;

                    continue;

                case "JoystickBt": // 조이스틱 버튼의 초기 설정
                    joybt = r; // 컴포넌트 저장

                    // 이미지 로드
                    r.gameObject.GetComponent<Image>().sprite = new DataGet().Get_JoystickImages()[1]; // DataGet 클래스를 두어 다양한 종류의 데이터를 불러왔었음.

                    // 색깔 로드
                    temp = new DataGet().Get_OneNowThemeMaterial(CustomVariable.JoystickBtColor).color; // DataGet 클래스를 두어 다양한 종류의 데이터를 불러왔었음.
                    r.gameObject.GetComponent<Image>().color = temp;

                    continue;
            }
        }

        // 카메라 초기화
        Camera cam = GameObject.FindObjectOfType<Camera>();

        // 스크린의 크기와 캔버스의 크기를 저장함
        ScreenSize = new Vector2(cam.pixelWidth, cam.pixelHeight);
        CanvasSize = UIDimentionChange.ScreenToCanvas(ScreenSize);

        // 반지름
        radius = (CanvasSize.x * 0.2f);

        // 이미지의 크기 설정
        joybg.sizeDelta = new Vector2(radius * 2, radius * 2);
        joybt.sizeDelta = new Vector2(radius * 1.6f, radius * 1.6f);

        // 조이스틱의 위치 설정
        float x = CanvasSize.x * 0.5f;
        float y = CanvasSize.y * 0.2f;
        SetPosition(joybg, new Vector2(x, y));
        SetPosition(joybt, new Vector2(x, y));

        // 플레이어 설정
        //p = GameObject.FindObjectOfType<Player>();
    }

    // 플레이어를 움직임
    void Update()
    {
        // 조이스틱 벡터를 normalize하여 플레이어 움직임 함수에 전해주어
        // 플레이어 움직임 함수 내부에서 속도와 곱해서 움직임
        //if(GameObject.FindObjectOfType<MainScene>().Get_GameStatus() == true) // 게임이 진행중인 경우
        //    p.PlayerMovement(joystickVector.normalized);
    }

    // 조이스틱을 누를 때
    public virtual void OnPointerDown(PointerEventData pad)
    {
        OnDrag(pad);
    }

    // 조이스틱을 드래그할 때
    public virtual void OnDrag(PointerEventData pad)
    {
        // 정상좌표
        Vector2 center = UIDimentionChange.ScreenToCanvas(new Vector2(joybg.position.x, joybg.position.y));
        //VectorMessager("중심", center);

        // 정상벡터
        Vector2 temp = UIDimentionChange.ScreenToCanvas(pad.position) - center;
        //VectorMessager("조이스틱벡터1", temp);

        // 정상 길이
        float dist = Vector2.Distance(Vector2.zero, temp);
        //Debug.Log("길이 : " + dist);

        // 정상벡터
        joystickVector = dist > radius ? temp.normalized * radius : temp;
        //VectorMessager("조이스틱벡터2", joystickVector);

        Vector2 Position = center + joystickVector;

        joybt.position = UIDimentionChange.CanvasToScreen(Position);
    }

    // 포인터에서 손을 뗄 때
    public virtual void OnPointerUp(PointerEventData pad)
    {
        joystickVector = Vector2.zero;
        joybt.position = joybg.position;
    }

    // 조이스틱의 위치 설정
    protected void SetPosition(RectTransform rect, Vector2 position)
    {
        rect.localPosition = position - (CanvasSize / 2);
    }

    // 왜 만들었는지 까먹은 함수
    // 아마 조이스틱 버튼의 위치를 실시간으로 갱신하기 위해서일 듯
    protected void DeltaPosition(RectTransform rect, Vector2 delta)
    {
        rect.localPosition += (Vector3)delta;
    }
    
    // 조이스틱 벡터 로그용 함수
    protected void VectorMessager(string attribute, Vector3 vec)
    {
        Debug.Log(attribute + " : x = " + vec.x + " y = " + vec.y + " z = " + vec.z);
    }
}

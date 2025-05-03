using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class testjoy : MonoBehaviour, IPointerDownHandler
{
    Camera cam;
    Vector2 screendisplay;

    void Start()
    {
        
    }

    public void OnPointerDown(PointerEventData pad)
    {
        cam = FindObjectOfType<Camera>();
        screendisplay = new Vector2(cam.pixelWidth, cam.pixelHeight);
        VectorMessager("스크린", screendisplay);

        VectorMessager("패드 클릭 좌표", pad.position);

        Vector2 r = new Vector2(GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width, GameObject.Find("Canvas").GetComponent<RectTransform>().rect.height);
        VectorMessager("캔버스", r);

        VectorMessager("스크린을 캔버스로 변환", UIDimentionChange.ScreenToCanvas(screendisplay));

        VectorMessager("패드를 캔버스로 변환", UIDimentionChange.ScreenToCanvas(pad.position));

        GameObject.Find("testimg").GetComponent<RectTransform>().localPosition = pad.position;

        VectorMessager("캔버스를 스크린으로 전환", UIDimentionChange.CanvasToScreen(r));
    }

    void VectorMessager(string attribute, Vector3 vec)
    {
        Debug.Log(attribute + " : x = " + vec.x + " y = " + vec.y + " z = " + vec.z);
    }
}

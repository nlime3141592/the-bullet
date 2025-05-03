using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDimentionChange
{
    public static Vector2 ScreenToCanvas(Vector2 vec)
    {
        Vector2 result = Vector2.zero;

        Camera cam = GameObject.FindObjectOfType<Camera>();

        float screenx = cam.pixelWidth;
        float screeny = cam.pixelHeight;

        Vector2 screensize = new Vector2(screenx, screeny);

        RectTransform canv = GameObject.Find("Canvas").GetComponent<RectTransform>();

        float x = canv.rect.width;
        float y = canv.rect.height;

        Vector2 canvsize = new Vector2(x, y);

        result = vec * (canvsize / screensize);

        return result;
    }

    public static Vector2 CanvasToScreen(Vector2 vec)
    {
        Vector2 result = Vector2.zero;

        Camera cam = GameObject.FindObjectOfType<Camera>();

        float screenx = cam.pixelWidth;
        float screeny = cam.pixelHeight;

        Vector2 screensize = new Vector2(screenx, screeny);

        RectTransform canv = GameObject.Find("Canvas").GetComponent<RectTransform>();

        float x = canv.rect.width;
        float y = canv.rect.height;

        Vector2 canvsize = new Vector2(x, y);

        result = vec * (screensize / canvsize);

        return result;
    }
}

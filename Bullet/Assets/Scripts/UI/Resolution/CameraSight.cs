using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSight : MonoBehaviour
{
    public float displaysight = 5;

    // Start is called before the first frame update
    void Start()
    {
        setting_sight();
    }

    // Update is called once per frame
    public bool test = false;
    void Update()
    {
        if (test == true)
        { test = false; setting_sight(); }
    }

    // 카메라 시야를 설정하는 함수
    void setting_sight()
    {
        Camera cam = GameObject.FindObjectOfType<Camera>();

        Vector2 screenSize = new Vector2(cam.pixelWidth, cam.pixelHeight);

        Vector3 pxancmin = new Vector3(0, screenSize.y / 2, 5);
        Vector3 pxancmax = new Vector3(screenSize.x, screenSize.y / 2, 5);

        Vector3 ancmin2world = cam.ScreenToWorldPoint(pxancmin);
        Vector3 ancmax2world = cam.ScreenToWorldPoint(pxancmax);

        float dx = Mathf.Abs(ancmax2world.x - ancmin2world.x);

        float camsize = cam.fieldOfView;

        float ratio = displaysight / dx;

        camsize *= ratio;

        cam.fieldOfView = camsize;
    }

    void logger(Vector3 vec)
    {
        Debug.Log(vec.x + " " + vec.y + " " + vec.z);

        GameObject block = Resources.Load("Prefabs/Block/Block00") as GameObject;
        GameObject obj = GameObject.Instantiate(block, vec, Quaternion.identity);
        obj.GetComponent<MeshRenderer>().material = Resources.Load("Material/BulletHeadColor/Color00") as Material;
    }
}

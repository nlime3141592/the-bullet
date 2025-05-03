using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public string direction = "";

    // 총알의 이동속도
    public float speed;

    public float graze_time = 0.05f;
    public float passedTime = 0;

    bool processed = false;
    bool gotCombo = false;

    void Start()
    {
        Transformation();
        MaterialSetting();
    }

    void Transformation()
    {
        MainScene main = GameObject.FindObjectOfType<MainScene>();

        // 총알의 속도를 랜덤으로 지정하는 변수
        speed = CustomVariable.Speed_Bullet(main.GetGameMode().score);
        transform.parent = GameObject.Find("Terrain_Bullet").transform;
    }

    void MaterialSetting()
    {
        Material bulletheadcolor = new DataGet().Get_OneNowThemeMaterial(CustomVariable.BulletHeadColor);
        Material bulletbodycolor = new DataGet().Get_OneNowThemeMaterial(CustomVariable.BulletBodyColor);

        // 하위 오브젝트가 속해있는 그룹에 따라 Material 적용
        foreach (Transform obj in GetComponentsInChildren<Transform>())
        {
            if (obj.gameObject.name == "BulletHead")
            {
                GameObject head = obj.gameObject;

                foreach (MeshRenderer mat in head.GetComponentsInChildren<MeshRenderer>())
                {
                    mat.material = bulletheadcolor;
                }
            }
            else if (obj.gameObject.name == "BulletBody")
            {
                GameObject body = obj.gameObject;

                foreach (MeshRenderer mat in body.GetComponentsInChildren<MeshRenderer>())
                {
                    mat.material = bulletbodycolor;
                }
            }
        }
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (direction == "x")
        {
            float hor = speed * Time.deltaTime;

            transform.localPosition += new Vector3(hor, 0, 0);
        }
        else if (direction == "z")
        {
            float hor = speed * Time.deltaTime;

            transform.localPosition += new Vector3(0, 0, hor);
        }
    }

    public bool canGetCombo()
    {
        if(passedTime >= graze_time && gotCombo == false)
        {
            return true;
        }

        return false;
    }

    public void getCombo()
    {
        gotCombo = true;
    }

    public void passTime()
    {
        passedTime += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (Transform t in other.gameObject.GetComponents<Transform>())
        {
            string name = t.gameObject.name;
            if (name == "ScoreAdder" && processed == false)
            {
                processed = true;

                if (GameObject.FindObjectOfType<MainScene>().Get_GameStatus() == true)
                {
                    GameObject.FindObjectOfType<MainScene>().GetGameMode().AddScore1();
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "BulletBreaker")
        {
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임에서 기본적으로 불러와야 할 정보들 또는
// 사용자가 설정했던 여러가지 정보들을 제공하기 위한 클래스
public class DataGet
{
    // 플레이어를 불러오는 함수
    public GameObject Get_Player()
    {
        string path = "Prefabs/Object/Player";

        GameObject player = Resources.Load(path) as GameObject;

        return player;
    }

    // 맵 생성을 위한 블럭의 모양을 불러오는 함수
    public GameObject Get_MapBlock()
    {
        string path = "Prefabs/Object/Block";

        GameObject block = Resources.Load(path) as GameObject;

        return block;
    }

    // 총알이 나타나기 전 표시하는 경고선 오브젝트를 가져오는 함수
    public GameObject Get_Line()
    {
        string path = "Prefabs/Object/Line";

        GameObject line = Resources.Load(path) as GameObject;

        return line;
    }

    // 총알의 모양을 불러오는 함수
    public GameObject Get_Bullet()
    {
        // 나중에 아래 경로를 사용할 것
        //string path = "Prefabs/Object/Bullet/bullet_" + DataValue.valueTheme();
        string path = "Prefabs/Object/Bullet";

        GameObject bullet = Resources.Load(path) as GameObject;

        return bullet;
    }

    // 총알을 표시하기 전 경고선의 Material 정보를 가져오는 함수
    public Material Get_LineMaterial()
    {
        string path = "Theme/LineColor";
        Material mat = Resources.Load(path) as Material;

        return mat;
    }

    // 현재 테마의 모든 Material을 불러오는 함수
    public List<Material> Get_AllNowThemeMaterial()
    {
        List<Material> c = new List<Material>();

        string path = "Theme/" + DataValue.valueTheme() + "/Color0";

        int i = 0;
        for(i = 0; i < 7; i++) // 현재는 전체 색깔의 갯수가 7개
        {
            Material m = Resources.Load(path + i.ToString()) as Material;

            Material tc = m;

            c.Add(tc);
        }

        return c;
    }

    // 현재 테마의 특정 Material을 불러오는 함수
    public Material Get_OneNowThemeMaterial(int code)
    {
        List<Material> c = new List<Material>();
        c = Get_AllNowThemeMaterial();

        return c[code];
    }

    // 현재 테마의 조이스틱 이미지들을 불러오는 함수
    public List<Sprite> Get_JoystickImages()
    {
        List<Sprite> s = new List<Sprite>(2);

        string pathbg = "Theme/" + DataValue.valueTheme() + "/JoystickBg";
        string pathbt = "Theme/" + DataValue.valueTheme() + "/JoystickBt";

        Sprite bg = Resources.Load<Sprite>(pathbg);
        Sprite bt = Resources.Load<Sprite>(pathbt);

        s.Add(bg);
        s.Add(bt);

        // index 0 = background, index 1 = button image

        return s;
    }
}
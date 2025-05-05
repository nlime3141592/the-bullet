using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader
{
    // 맵을 로딩하는 함수, 실제적 로딩
    public void Generation_Map()
    {
        // Ground Generations

        // 이전의 땅 초기화
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Block"))
        {
            MonoBehaviour.Destroy(obj);
        }

        // 블럭, 블럭색, 맵모양 정의
        GameObject block = new DataGet().Get_MapBlock();
        Material blockMaterial = new DataGet().Get_OneNowThemeMaterial(CustomVariable.BlockColor);
        Transform parent = GameObject.Find("Terrain_Ground").transform;
        int[,] MapShape = new int[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };

        // 맵 모양에 따라 설치
        int i = 0; int j = 0;
        for (i = 0; i < 3; i++)
        {
            for (j = 0; j < 3; j++)
            {
                if (MapShape[i, j] == 1)
                {
                    Vector3 blockPos = new Vector3(i, 0, j);
                    GameObject b = GameObject.Instantiate(block, blockPos, Quaternion.identity);
                    b.transform.parent = parent;
                    b.GetComponent<MeshRenderer>().material = blockMaterial;
                    continue;
                }
            }
        }
    }

    // 플레이어를 로딩하는 함수, 실제적 로딩
    public void Generation_Player()
    {
        // 반환값
        GameObject PlayerObject = null;

        // Player Definition
        // 플레이어의 모양, 플레이어의 색, 초기 위치 정의
        GameObject player = new DataGet().Get_Player();
        Material playercolor = new DataGet().Get_OneNowThemeMaterial(CustomVariable.PlayerColor);

        Vector3 instantPos = new Vector3(1, 2, 1);
        PlayerObject = player;

        // Player Generation
        // 이전의 플레이어 초기화
        //foreach (Player obj in GameObject.FindObjectsOfType<Player>())
        //{
        //    MonoBehaviour.Destroy(obj.gameObject);
        //}

        // 로드한 플레이어 생성
        PlayerObject = GameObject.Instantiate(player, new Vector3(1, 2, 1), Quaternion.identity);
        PlayerObject.GetComponent<MeshRenderer>().material = playercolor;
    }

    // 총알을 로딩하는 함수, 개념적 로딩
    public GameObject Loading_Bullet()
    {
        // 반환값
        GameObject BulletObject = null;

        // Bullet Definition
        // 총알의 모양, 탄두 색, 탄피 색 정의
        BulletObject = new DataGet().Get_Bullet();

        return BulletObject;
    }

    // 총알을 로딩하는 함수, 실제적 로딩
    public void Generation_Bullet(Vector3 position, string dir)
    {
        //GameObject bullet = null;
        //Bullet bulletcomp = null;

        //if (dir == "x")
        //{
        //    bullet = GameObject.Instantiate(Loading_Bullet(), position + new Vector3(-10, 0.22f, 0), Quaternion.identity);
        //    bulletcomp = bullet.GetComponent<Bullet>();
        //}
        //else if (dir == "z")
        //{
        //    bullet = GameObject.Instantiate(Loading_Bullet(), position + new Vector3(0, 0.22f, -10), Quaternion.Euler(new Vector3(0, -90, 0)));
        //    bulletcomp = bullet.GetComponent<Bullet>();
        //}

        //bulletcomp.direction = dir;
    }

    // 경고선을 로딩하는 함수, 개념적 로딩
    public GameObject Loading_Line()
    {
        // Line Definition
        // 총알이 설치되기 이전에 형성되는 경고선 로딩
        GameObject line = new DataGet().Get_Line();

        return line;
    }

    // 라인을 로딩하는 함수, 실제적 로딩
    public void Generation_Line(Vector3 position, string dir)
    {
        GameObject line = null;

        Vector3 pos = position;

        // Line Generation
        // 좌측 상단에 생성
        if (dir == "x")
        {
            line = GameObject.Instantiate(Loading_Line(), pos, Quaternion.Euler(new Vector3(0, 90, 0)));
        }
        // 우측 상단에 생성
        else if(dir == "z")
        {
            line = GameObject.Instantiate(Loading_Line(), pos, Quaternion.identity);
        }
    }

    public void Generation_Integrated()
    {
        // 한 프레임당 생성할 최대 총알의 갯수
        // 1 ~ (n-1)
        //MainScene main = GameObject.FindObjectOfType<MainScene>();
        //int generatePerFrame = CustomVariable.Count_Bullet(main.GetGameMode().score);

        //int i = 0;
        //for (i = 0; i < generatePerFrame; i++)
        //{
        //    float generationDirection = Random.Range(0, 10);

        //    Vector3 LinePosition = Vector3.zero;
        //    Vector3 BulletPosition = Vector3.zero;

        //    string dir = "";

        //    float _dxz = Random.Range(-0.5f, 2.5f);

        //    if (generationDirection < 5)
        //    {
        //        LinePosition = new Vector3(-0.5f, 0.48f, _dxz);
        //        BulletPosition = LinePosition + new Vector3(-10, 0.22f, 0);
        //        dir = "x";
        //    }
        //    // 우측 상단에 생성
        //    else
        //    {
        //        LinePosition = new Vector3(_dxz, 0.48f, -0.5f);
        //        BulletPosition = LinePosition + new Vector3(0, 0.22f, -10);
        //        dir = "z";
        //    }

        //    Generation_Line(LinePosition, dir);
        //    Generation_Bullet(BulletPosition, dir);
        //}
        
    }
}

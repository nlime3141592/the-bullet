using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : UIcomponent
{
    public override void Initialize()
    {
        //MainScene main = GameObject.FindObjectOfType<MainScene>();

        // 모든 총알을 파괴
        //foreach (Bullet b in GameObject.FindObjectsOfType<Bullet>())
        //{
        //    MonoBehaviour.Destroy(b.gameObject);
        //}

        // 모든 플레이어 잔해 파괴
        foreach (Transform t in GameObject.FindObjectsOfType<Transform>())
        {
            if (t.gameObject.tag == "Particle")
            {
                MonoBehaviour.Destroy(t.gameObject);
            }
        }

        // 게임 시작 전 초기 상태로 복귀
        //main.GetGameMode().SetADwatched(false);
        //main.Set_GameStatus(false);
        //main.DataLoading();
        Time.timeScale = 1;
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class GameUI : UIcomponent
//{
//    MainScene main;

//    public void GameInitialize()
//    {
//        main = GameObject.FindObjectOfType<MainScene>();

//        foreach (Transform t in GameObject.FindObjectsOfType<Transform>())
//        {
//            if (t.gameObject.tag == "Particle")
//            {
//                MonoBehaviour.Destroy(t.gameObject);
//            }
//        }

//        foreach (Bullet b in GameObject.FindObjectsOfType<Bullet>())
//        {
//            Destroy(b.gameObject);
//        }

//        if (DataValue.valueJoystickFixed() == true)
//        {
//            GameObject.Find("JoystickBt").AddComponent<FixedJoystick>();
//        }
//        else
//        {
//            GameObject.Find("GamePad").AddComponent<UnFixedJoystick>();
//        }

//        Time.timeScale = 1;

//        int pl = 0;
//        foreach(Player p in GameObject.FindObjectsOfType<Player>())
//        { pl++; }
//        if(pl == 0) { new SceneLoader().Generation_Player(); }
//    }

//    public void GameClear()
//    {
//        main.GetGameMode().SetADwatched(false);
//        main.GetGameMode().SetScore(0);
//        main.GetGameMode().SetCombo(0);
//        main.GetGameMode().SetComboTotal(0);
//        main.GetGameMode().SetComboTick(0);
//        main.GetGameMode().SetPlaytime(0);
//        main.GetGameMode().Display_GameUI();
//        main.Set_GameStatus(true);
//    }

//    public void GameContinue()
//    {
//        main.GetGameMode().SetADwatched(true);
//        main.GetGameMode().SetCombo(0);
//        main.GetGameMode().SetComboTick(0);
//        main.Set_GameStatus(true);
//    }
//}

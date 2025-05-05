//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class TimeMode : GameMode
//{
//    public TimeMode()
//    {
//        main = GameObject.FindObjectOfType<MainScene>();

//        MonoBehaviour mb = GameObject.FindObjectOfType<MainScene>() as MonoBehaviour;

//        mb.StartCoroutine(AddPlaytime());
//    }

//    public override void Display_GameUI()
//    {
//        displayvalue = DevideNumberToString(playtime, 1);
//    }

//    public override void Recording_GameEndUI()
//    {
//        // UI 화면 탐색
//        GameEndUI ui = GameObject.FindObjectOfType<GameEndUI>();

//        // 기본적으로 실행할 함수들을 실행
//        base.Recording_GameEndUI();

//        int playtime_total = playtime + combo_total;
//        highvalue = DataValue.valueHighEnduringTime();

//        // 토탈 점수가 최고 기록을 넘으면
//        if (playtime_total > highvalue)
//        {
//            // 1차적으로, 기본 점수가 최고 점수를 넘을 때
//            if (playtime > highvalue)
//            {
//                DataChanger.setHighEnduringTime(playtime);
//                highvalue = playtime;
//            }
//        }

//        // 메세지 설정
//        string m1 = DevideNumberToString(playtime, 1);
//        string m2 = DevideNumberToString(highvalue, 1);
//        // 메세지 출력
//        ui.SetScoreboardMessage(m1, m2);

//        // 돈 지급
//        DataChanger.modulateMoneyInGame(playtime_total / 10);

//        // 현재 점수 출력
//        ui.PlayAnimation_NowScore();
//    }

//    public override IEnumerator OverCombo1()
//    {
//        // UI 화면 탐색
//        GameEndUI ui = GameObject.FindObjectOfType<GameEndUI>();

//        if (combo >= 1)
//        {
//            // 콤보를 얼마 더했는지 확인하는 임시변수
//            int t = 0;

//            int nowplaytime = playtime;
//            int totalcombo = combo_total;
//            int totalplaytime = nowplaytime + totalcombo;
//            int highscore = DataValue.valueHighEnduringTime();

//            // 메세지 설정
//            string txtnow = "";
//            string txtbest = "";

//            // 이어하기 시 적용될 점수 설정하고 콤보 초기화
//            SetScore(totalplaytime);
//            SetComboTotal(0);

            
//            // 최고점수 갱신
//            if (totalplaytime > highscore)
//            {
//                DataChanger.setHighEnduringTime(totalplaytime);
//            }

//            for (t = 1; t <= totalcombo; t++)
//            {
//                int temp1 = nowplaytime + t;
//                int temp2 = highscore;

//                if (temp1 > temp2)
//                {
//                    temp2 = temp1;
//                }

//                txtnow = DevideNumberToString(temp1, 1);
//                txtbest = DevideNumberToString(temp2, 1);

//                ui.SetScoreboardMessage(txtnow, txtbest);

//                // 포인트 산정 시 딜레이 주는 기능
//                if (t < totalcombo)
//                {
//                    yield return new WaitForSeconds(1.5f / totalcombo);
//                    continue;
//                }
//                else { break; }
//            }
//        }

//        // 점수 출력이 끝났으면 장면 이동을 위한
//        // 버튼 선택지를 제공, 애니메이션 출력
//        ui.PlayAnimation_OpenButton();
//        ui.PlayAD();
//    }
//}

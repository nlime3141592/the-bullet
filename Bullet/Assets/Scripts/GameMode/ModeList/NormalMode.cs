using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMode : GameMode
{
    public override void Display_GameUI()
    {
        displayvalue = score.ToString();
    }

    public override void Recording_GameEndUI()
    {
        // UI 화면 탐색
        GameEndUI ui = GameObject.FindObjectOfType<GameEndUI>();

        // 기본적으로 실행할 함수들을 실행
        base.Recording_GameEndUI();

        int score_total = score + combo_total;
        highvalue = DataValue.valueHighScore();

        // 토탈 점수가 최고 기록을 넘으면
        if (score_total > highvalue)
        {
            // 1차적으로, 기본 점수가 최고 점수를 넘을 때
            if(score > highvalue)
            {
                DataChanger.setHighScore(score);
                highvalue = score;
            }
        }

        // 메세지 설정
        string m1 = score.ToString();
        string m2 = highvalue.ToString();
        // 메세지 출력
        ui.SetScoreboardMessage(m1, m2);

        // 돈 지급
        DataChanger.modulateMoneyInGame(score_total);

        // 현재 점수 출력
        ui.PlayAnimation_NowScore();
    }

    public override IEnumerator OverCombo1()
    {
        // UI 화면 탐색
        GameEndUI ui = GameObject.FindObjectOfType<GameEndUI>();

        if (combo >= 1)
        {
            // 콤보를 얼마 더했는지 확인하는 임시변수
            int t = 0;

            int nowscore = score;
            int totalcombo = combo_total;
            int totalscore = nowscore + totalcombo;
            int highscore = DataValue.valueHighScore();

            // 메세지 설정
            string txtnow = "";
            string txtbest = "";

            // 이어하기 시 적용될 점수 설정하고 콤보 초기화
            SetScore(totalscore);
            SetComboTotal(0);

            // 최고점수 갱신
            if(totalscore > highscore)
            {
                DataChanger.setHighScore(totalscore);
            }

            for(t = 1; t <= totalcombo; t++)
            {
                int temp1 = nowscore + t;
                int temp2 = highscore;

                if (temp1 > temp2)
                {
                    temp2 = temp1;
                }

                txtnow = temp1.ToString();
                txtbest = temp2.ToString();

                ui.SetScoreboardMessage(txtnow, txtbest);

                // 포인트 산정 시 딜레이 주는 기능
                if (t < totalcombo)
                {
                    yield return new WaitForSeconds(1.5f / totalcombo);
                    continue;
                }
                else { break; }
            }
        }

        // 점수 출력이 끝났으면 장면 이동을 위한
        // 버튼 선택지를 제공, 애니메이션 출력
        ui.PlayAnimation_OpenButton();
        //ui.PlayAD();
    }
}
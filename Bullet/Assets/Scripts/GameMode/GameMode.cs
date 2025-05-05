using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode
{
    public int score { get; private set; } // 현재 점수
    public int playtime { get; private set; } // 플레이타임
    public int combo { get; private set; } // 현재 콤보
    public int combo_total { get; private set; } // 누적 콤보
    public int highvalue { get; protected set; } // 최고 기록(시간 or 점수)

    public float combo_tick { get; private set; } // 콤보 유지시간

    public bool ADwatched { get; private set; } = false;

    // 실제 게임UI에 보여주고자하는 값
    public string displayvalue;

    //protected MainScene main;

    public virtual void Display_GameUI()
    {

    }

    public virtual void Recording_GameEndUI()
    {

    }

    public void SetScore(int value) { score = value; }
    public void AddScore1() { score++; }

    public void SetCombo(int value) { combo = value; }
    public void AddCombo1() { combo++; }

    public void SetComboTotal(int value) { combo_total = value; }
    public void AddComboTotal1() { combo_total++; }

    public void SetComboTick(float value) { combo_tick = value; }
    public void ReupdateComboTick() { combo_tick -= Time.deltaTime; }

    public void SetADwatched(bool value) { ADwatched = value; }

    public void SetPlaytime(int value) { playtime = value; }
    public IEnumerator AddPlaytime()
    {
        while(true)
        {
            //yield return new WaitUntil(() => main.Get_GameStatus() == true);

            yield return new WaitForSeconds(0.1f);

            //if (main.Get_GameStatus() == true)
            //{
            //    playtime++;
            //    Display_GameUI();
            //}
        }
    }

    public string DevideNumberToString(int number, int underintegerdigit)
    {
        List<int> num = new List<int>();

        int i = 0;
        while (Mathf.Pow(10, i) < number)
        {
            i++;

            int thisleft = number % (int)Mathf.Pow(10, i);
            int formerleft = number % (int)Mathf.Pow(10, i - 1);

            int digit = (thisleft - formerleft) / (int)Mathf.Pow(10, i - 1);

            num.Add(digit);
        }

        while (num.Count <= underintegerdigit)
        {
            num.Add(0);
        }

        string result = "";
        for (i = 0; i < num.Count; i++)
        {
            int temp = num[num.Count - 1 - i];
            if (i == num.Count - underintegerdigit)
            {
                result += ".";
            }

            result += temp;
        }

        return result;
    }

    public virtual IEnumerator OverCombo1()
    {
        yield return new WaitForSeconds(0);
    }
}

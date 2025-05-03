using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeUI : UIcomponent
{
    public int screenindex = 2;

    MainUI main;

    public override void Initialize()
    {
        main = GameObject.FindObjectOfType<MainUI>();
    }

    protected override void Loop()
    {
        ThemeReset();
    }

    void ThemeReset()
    {
        if (main.screenindex != screenindex)
        {
            Scrollbar sc = GameObject.Find("ScrollView_Theme").GetComponentInChildren<Scrollbar>();
            float val = sc.value;
            val = Mathf.Lerp(val, 1, 7 * Time.deltaTime);
            sc.value = val;

            foreach (ThemeIcon t in GameObject.FindObjectsOfType<ThemeIcon>())
            {
                t.animedir = -1;
            }
        }
    }
}

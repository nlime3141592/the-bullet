using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : UIcomponent
{
    Scrollbar scroll;

    public int screenindex = 1;

    public bool restrict = false;

    public override void Initialize()
    {
        foreach(Scrollbar s in GetComponentsInChildren<Scrollbar>())
        {
            if (s.name == "Scrollbar Horizontal")
            {
                scroll = s;
                break;
            }
        }

        scroll.value = 0.5f;
    }

    protected override void Loop()
    {
        //Set_ScreenIndex();
        Set_ScrollValue();
    }
    /*
    public void Set_ScreenIndex()
    {
        if(restrict == false)
        {
            float v = scroll.value;

            if (v <= 0.25f)
            {
                screenindex = 0;
            }
            else if(v > 0.25f && v < 0.75f)
            {
                screenindex = 1;
            }
            else if(v >= 0.75f)
            {
                screenindex = 2;
            }
        }
    }*/

    public void Set_ScreenIndex()
    {
        float v = scroll.value;

        int nowscreenindex = screenindex;

        switch(nowscreenindex)
        {
            case 0:
                if (v >= 0.095f)
                {
                    screenindex = 1;
                }
                break;

            case 1:
                if (v <= 0.405f)
                {
                    screenindex = 0;
                    break;
                }
                if (v >= 0.595f)
                {
                    screenindex = 2;
                    break;
                }
                break;

            case 2:
                if (v <= 0.855f)
                {
                    screenindex = 1;
                    break;
                }
                break;
        }
    }

    public void Set_ScrollValue()
    {
        if (restrict == true)
        {
            float value = scroll.value;

            switch (screenindex)
            {
                case 0:
                    value = Mathf.Lerp(value, 0f, 10 * Time.deltaTime);
                    break;

                case 1:
                    value = Mathf.Lerp(value, 0.5f, 10 * Time.deltaTime);
                    break;

                case 2:
                    value = Mathf.Lerp(value, 1f, 10 * Time.deltaTime);
                    break;
            }

            value = Mathf.Clamp01(value);

            scroll.value = value;
        }
    }
}
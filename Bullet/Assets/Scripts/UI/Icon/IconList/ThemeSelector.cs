using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThemeSelector : Icon
{
    public override void OnBeginDrag(PointerEventData pad)
    {
        draged = true;
        base.OnBeginDrag(pad);
    }

    public override void OnDrag(PointerEventData pad)
    {
        base.OnDrag(pad);
    }

    public override void OnScroll(PointerEventData pad)
    {
        base.OnScroll(pad);
    }

    // 아래 함수들은 Drag false 이벤트가 적용되어 있다
    public override void OnEndDrag(PointerEventData pad)
    {
        base.OnEndDrag(pad);
    }

    public override void OnPointerUp(PointerEventData pad)
    {
        if (draged == false)
        {
            func();
        }
        draged = false;
    }

    //
    void func()
    {
        Theme theme = transform.parent.GetComponent<Theme>();
        DataChanger.setTheme(theme.ThemeName);

        new SceneLoader().Generation_Map();
        new SceneLoader().Generation_Player();

        BGMset();

        GameObject.FindObjectOfType<MainScene>().colorMix.ResetColor();
    }

    void BGMset()
    {
        AudioSource bgm = GameObject.Find("Audio_BGM").GetComponent<AudioSource>();

        bgm.volume = DataValue.valueBGM();

        string theme = DataValue.valueTheme();
        string path = "Audio/ThemeAudio/ThemeAudio_" + theme;

        AudioClip clip = Resources.Load(path) as AudioClip;

        if (bgm.clip == null)
        {
            bgm.clip = clip;
            bgm.Play();
        }
        else if(bgm.clip != clip)
        {
            bgm.clip = clip;
            bgm.Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public float RewardAdsOpened = 1;

    void Update()
    {
        volChanger();
    }

    float BGMsound()
    {
        float vol = DataValue.valueBGM() * RewardAdsOpened;

        return vol;
    }

    float EFFECTsound()
    {
        float vol = DataValue.valueEffectSound() * RewardAdsOpened;

        return vol;
    }

    void volChanger()
    {
        AudioSource bgm = GameObject.Find("Audio_BGM").GetComponent<AudioSource>();
        bgm.volume = BGMsound();

        foreach (AudioSource a in GameObject.Find("Audio_Effect").GetComponentsInChildren<AudioSource>())
        {
            a.volume = EFFECTsound();
        }
    }
}

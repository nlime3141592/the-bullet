using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEffectSound
{
    public void sound(string name)
    {
        switch(name)
        {
            case "ButtonClick":
                GameObject.Find("Sound_ButtonClick").GetComponent<AudioSource>().Play();
                break;

            case "ComboAdd":
                GameObject.Find("Sound_ComboAdd").GetComponent<AudioSource>().Play();
                break;

            case "PlayerDie":
                GameObject.Find("Sound_PlayerDie").GetComponent<AudioSource>().Play();
                break;

            case "ProductBought_Success":
                GameObject.Find("Sound_ProductBought_Success").GetComponent<AudioSource>().Play();
                break;

            case "ProductBought_Fail":
                GameObject.Find("Sound_ProductBought_Fail").GetComponent<AudioSource>().Play();
                break;
        }
    }
}

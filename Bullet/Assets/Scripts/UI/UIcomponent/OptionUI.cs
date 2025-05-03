using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : UIcomponent
{
    public int screenindex = 0;

    private void Start()
    {
        OptionInitialize();
    }

    private void Update()
    {
        volSet();

        TextboxRemove();
    }

    void OptionInitialize()
    {
        foreach(Scrollbar s in GetComponentsInChildren<Scrollbar>())
        {
            string name = s.gameObject.name;

            switch(name)
            {
                case "ScrollBar_BGM":
                    s.value = DataValue.valueBGM();
                    continue;

                case "ScrollBar_Effect":
                    s.value = DataValue.valueEffectSound();
                    continue;
            }
        }
    }

    void volSet()
    {
        foreach (Scrollbar s in GetComponentsInChildren<Scrollbar>())
        {
            string name = s.gameObject.name;

            switch (name)
            {
                case "ScrollBar_BGM":
                    DataChanger.setVolumeBGM(s.value);
                    continue;

                case "ScrollBar_Effect":
                    DataChanger.setVolumeEffect(s.value);
                    continue;
            }
        }
    }

    void TextboxRemove()
    {
        if (GameObject.FindObjectOfType<MainUI>().screenindex != screenindex)
        {
            foreach (TextboxUI t in GameObject.FindObjectsOfType<TextboxUI>())
            {
                Destroy(t.gameObject);
            }
        }
    }
}

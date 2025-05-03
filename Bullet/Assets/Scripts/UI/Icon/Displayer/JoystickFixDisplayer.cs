using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickFixDisplayer : MonoBehaviour
{
    Image i;

    void Start()
    {
        i = GetComponent<Image>();
    }

    void Update()
    {
        string path = "";

        bool tempb = DataValue.valueJoystickFixed();

        Sprite icon = null;

        if (tempb == true)
        {
            path = "Prefabs/UI/JoystickFixing/JoystickFix";
            icon = Resources.Load<Sprite>(path);
        }
        else
        {
            path = "Prefabs/UI/JoystickFixing/JoystickUnFix";
            icon = Resources.Load<Sprite>(path);
        }
        i.sprite = icon;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour
{
    Text t;

    void Start()
    {
        t = GetComponent<Text>();
    }

    void Update()
    {
        t.text = DataValue.valueMoneyInGame().ToString();
    }
}

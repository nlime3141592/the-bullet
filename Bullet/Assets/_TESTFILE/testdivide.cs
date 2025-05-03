using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testdivide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int number;
    public int digitunder;
    public bool test = false;
    void Update()
    {
        if (test == true)
        {
            test = false;

            string t = DevideNumberToString(number, digitunder);

            GetComponent<Text>().text = t;
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
            Debug.Log(temp);
            if (i == num.Count - underintegerdigit)
            {
                result += ".";
            }

            result += temp;
        }

        return result;
    }
}

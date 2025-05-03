using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Theme : MonoBehaviour
{
    // 테마 이름
    public string ThemeName;

    // 색깔 리스트
    //public List<Color> ColorList;

    void Start()
    {
        string path = "Theme/" + ThemeName;

        foreach(Image img in GetComponentsInChildren<Image>())
        {
            string imgname = img.name;

            switch(imgname)
            {
                case "UI_Theme00":
                    img.color = (Resources.Load(path + "/Color00") as Material).color;
                    break;

                case "UI_Theme01":
                    img.color = (Resources.Load(path + "/Color01") as Material).color;
                    break;

                case "UI_Theme02":
                    img.color = (Resources.Load(path + "/Color02") as Material).color;
                    break;

                case "UI_Theme03":
                    img.color = (Resources.Load(path + "/Color03") as Material).color;
                    break;

                case "UI_Theme04":
                    img.color = (Resources.Load(path + "/Color04") as Material).color;
                    break;

                case "UI_Theme05":
                    img.color = (Resources.Load(path + "/Color05") as Material).color;
                    break;

                case "UI_Theme06":
                    img.color = (Resources.Load(path + "/Color06") as Material).color;
                    break;
            }
        }
    }
}

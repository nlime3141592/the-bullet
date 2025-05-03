using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxColorMix
{
    List<Color> colorlist;

    float mix = 0;

    float dir = 1;

    int index = 1;

    Color color_1;
    Color color_2;


    public void ResetColor()
    {
        colorlist = new List<Color>();

        foreach(Material mat in new DataGet().Get_AllNowThemeMaterial())
        {
            colorlist.Add(mat.color);
        }

        color_1 = colorlist[0];
        color_2 = colorlist[1];

        mix = 0;
        dir = 1;

        index = 1;
    }

    public void ChangeColor()
    {
        float hor = Time.deltaTime * CustomVariable.SkyboxColorMixSpeed * dir;

        mix += hor;

        mix = Mathf.Clamp01(mix);

        Color c = Color.Lerp(color_1, color_2, mix);

        if (mix == 1)
        {
            dir = -1;
            /*
            index++;
            if (index >= colorlist.Count)
            {
                index = 0;
            }*/
            index = RandomIndex(index, colorlist.Count);
            color_1 = colorlist[index];
        }
        if (mix == 0)
        {
            dir = 1;
            /*
            index++;
            if (index >= colorlist.Count)
            {
                index = 0;
            }*/
            index = RandomIndex(index, colorlist.Count);
            color_2 = colorlist[index];
        }

        RenderSettings.skybox.SetColor("_Tint", c);
    }

    int RandomIndex(int nowIndex, int arraySize)
    {
        int i = 0;

        System.Random random = new System.Random();

        int result = 0;

        for (i = 0; i < arraySize; i++)
        {
            if (i == nowIndex)
            {
                continue;
            }
            if (i == arraySize - 1)
            {
                result = i;
                return result;
            }

            int r = random.Next(arraySize - 1);

            if (r == 0)
            {
                result = i;
                return result;
            }
            else
            {
                continue;
            }
        }

        return 0;
    }
}

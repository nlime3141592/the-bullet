using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeProduct
{
    static Product Theme_Basic = new Product("basic", 25);

    // 인-게임 상품
    static Product Theme_Mountain = new Product("mountain", 0);
    static Product Theme_Rainbow = new Product("rainbow", 0);
    static Product Theme_Sea = new Product("sea", 0);
    static Product Theme_SnowMountain = new Product("snowmountain", 0);
    static Product Theme_Volcano = new Product("volcano", 0);

    // 과금 상품    


    // 테마를 함수를 통해 얻는다
    public static Product Get_Theme(string themeName)
    {
        switch(themeName)
        {
            case "mountain":
                return Theme_Mountain;

            case "rainbow":
                return Theme_Rainbow;

            case "sea":
                return Theme_Sea;

            case "snowmountain":
                return Theme_SnowMountain;

            case "volcano":
                return Theme_Volcano;
        }

        // 잘못된 데이터를 입력했을 경우 기본 테마를 출력
        return Theme_Basic;
    }

    public struct Product
    {
        string name;
        int price;

        public Product(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        public bool CanBought()
        {
            if (DataValue.valueMoneyInGame() >= price)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Bought()
        {
            PlayerPrefs.SetInt("Theme_" + name, 1);
        }

        public void UnBought()
        {
            PlayerPrefs.SetInt("Theme_" + name, 0);
        }

        public bool isBought()
        {
            bool r = PlayerPrefs.GetInt("Theme_" + name) == 1 ? true : false;

            return r;
        }

        public int Get_Price()
        {
            return price;
        }
    }
}

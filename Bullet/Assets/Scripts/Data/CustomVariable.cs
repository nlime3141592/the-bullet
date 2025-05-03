using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 개발자가 개발 과정에서
// 게임 플레이에 영향을 줄 수 있는, 변화시킬 수 있는 다양한 요소들을
// 모아놓은 클래스
public class CustomVariable
{
    // 총알과 경고선이 다음에 생성되는 딜레이
    public static float Delay_Generation_Integrated(int score)
    {
        float min = 0;
        min = 1.1f - (0.1f * (int)((int)score / (int)40));

        float max = 0;
        if (score <= 40) { max = 1.2f; }
        else { max = 1.1f; }

        // 딜레이 초 단위
        float t = UnityEngine.Random.Range(min, max);
        return t;
    }

    // 플레이어의 속도
    public static float Speed_Player()
    {
        float speed = 3.3f;

        return speed;
    }

    // 총알의 속도
    public static float Speed_Bullet(int score)
    {
        // 기존 Bullet 앱에서 점수가 높아질수록 총알이 미쳐 날뛰던 이유
        // 180점 이후부터 min이 max를 초과하여 뭔가 이상해졌기 때문
        //
        // 이건 내 뇌피셜인데, UnityEngine.Random.Range 함수 안에
        // min이 더 클 경우 두 숫자를 바꾸는 로직이 존재하지 않을까 하는 생각이 듦.
        // 딱히 뭐라할만한 컴파일 오류나 실행 오류가 없었음.
        float min = 3f + (float)(score / (int)20); // C#은 자료형 type 체크가 엄격한 언어이기 때문에 자동으로 int를 float로 바꿔주지 않음. 아마도....

        float max = 11f;

        // 속도 1unit 단위
        float t = UnityEngine.Random.Range(min, max);
        return t;
    }

    // 총알 생성되는 갯수
    public static int Count_Bullet(int score)
    {
        // 한 사이클당 생성할 최대 총알의 갯수
        // 1 ~ max
        int max = 1 + (score / 50); // 기존 Bullet 앱에서 200점 넘기가 힘들었던 이유, 200점 이후부터 5개 이상씩 생성되서 피하기 사실상 불가능이었다.

        // 한 사이클당 생성할 최대 총알의 갯수
        // 1 ~ {(max+1) - 1}
        int count = UnityEngine.Random.Range(1, max + 1);

        return count;
    }

    // 이것들은 아마 DataGet 안에 있는
    // 한 테마의 모든 material을 가져오는 함수(DataGet.Get_AllNowThemeMaterial() 함수)의 index로 쓰였을 것임.
    //
    // 오브젝트에 적용시킬 Theme의 색깔번호
    public static int PlayerColor = 0;
    public static int PlayerDieParticle = 0;
    public static int BlockColor = 1;
    public static int BulletHeadColor = 2;
    public static int BulletBodyColor = 3;

    // 기존에는 경고선의 색깔도 테마에 지정된 색깔을 이용하여 설정하려 했는데,
    // 준환이가 색깔이 유사한 테마의 경우, 가시성이 떨어진다고 해서
    // 회색으로 고정하고, 지금은 Deprecated. ("(더 이상) 사용되지 않는", 프로그래밍에서 많이 쓰이는 단어이니 알아두기)
    //public static int LineColor = 4; 

    public static int JoystickBgColor = 4;
    public static int JoystickBtColor = 5;

    // 스카이박스 컬러 믹스 스피드
    public static float SkyboxColorMixSpeed = 0.2f;
}
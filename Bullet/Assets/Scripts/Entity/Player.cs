using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{ 
    Joystick joy;

    MainScene main;

    private void Start()
    {
        main = GameObject.FindObjectOfType<MainScene>();
    }

    public void PlayerMovement(Vector2 direction)
    {
        float weight = JoystickWeight(direction);
        Vector3 dir = new Vector3(direction.x, 0, direction.y).normalized;

        dir = Quaternion.Euler(0, -135, 0) * dir * weight;

        transform.localPosition += dir * CustomVariable.Speed_Player() * Time.deltaTime;
    }
    float JoystickWeight(Vector2 joystickVector) // 조이스틱에 가중치를 곱하기
    {
        float angle = 0;

        float min = 0.75f;
        float max = 1.0f;

        angle = Vector2.Angle(Vector2.up, joystickVector);

        return min + ((max - min) * (angle / 180));
    }

    void PlayerDie()
    {
        GameObject particle = new DataGet().Get_Player();

        Transform parent = GameObject.Find("Terrain_Particle").transform;

        int i = 0;
        for (i = 0; i < 20; i++)
        {
            GameObject part = GameObject.Instantiate(particle, transform.position, Quaternion.identity);
            part.transform.parent = parent;
            Destroy(part.GetComponent<Player>());
            part.AddComponent<DieParticle>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Bullet"))
        {
            main.Set_GameStatus(false);
            main.Set_GameEnd();
            PlayerDie();

            new MenuEffectSound().sound("PlayerDie");

            // 게임 종료 캔버스
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 총알을 스쳤을 때 콤보를 추가하는 기능
        // 아래로 옮겼다
        if(other.gameObject.name.Contains("Bullet"))
        {

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name.Contains("Bullet"))
        {
            if (other.GetComponent<Bullet>().canGetCombo() == true)
            {
                other.GetComponent<Bullet>().getCombo();

                new MenuEffectSound().sound("ComboAdd");

                main.GetGameMode().AddComboTotal1();
                main.GetGameMode().AddCombo1();
                main.GetGameMode().SetComboTick(5);

                string c = main.GetGameMode().combo.ToString();

                GameObject comboanime = GameObject.Find("Textbox_ComboText");

                comboanime.GetComponent<Text>().text = c + " Combo";
                comboanime.GetComponent<Animator>().Play("Movement");
            }

            other.GetComponent<Bullet>().passTime();
        }
    }
}

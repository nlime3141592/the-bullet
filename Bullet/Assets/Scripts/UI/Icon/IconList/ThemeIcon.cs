using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThemeIcon : Icon
{
    // 아이콘 잠금
    public bool Lock = true;

    // 애니메이션 컨트롤용 변수
    Animator anime;
    float runtime = 0;
    public int animedir = -1;

    string themename;


    public override void OnBeginDrag(PointerEventData pad)
    {
        draged = true;
        base.OnBeginDrag(pad);
    }

    public override void OnDrag(PointerEventData pad)
    {
        base.OnDrag(pad);
    }

    public override void OnScroll(PointerEventData pad)
    {
        base.OnScroll(pad);
    }

    public override void OnEndDrag(PointerEventData pad)
    {
        base.OnEndDrag(pad);
    }

    public override void OnPointerUp(PointerEventData pad)
    {
        // 스크롤 뷰를 전환하기 위해
        // 드래그를 하지 않았다면
        if (draged == false)
        {
            // 아이콘이 잠긴 상태라면
            if (Lock == true)
            {
                // 구매의 여부를 묻는 회화창을 열고
                GameObject convui = new UIopener().Open_ConversationUI(this, "구매할래?", 2);

                // 회화창에 이벤트 등록
                convui.GetComponent<ConversationUI>().event_ok = new ConversationUI.ButtonFunction(Toggled_ok);
                convui.GetComponent<ConversationUI>().event_yes = new ConversationUI.ButtonFunction(Toggled_yes);
                convui.GetComponent<ConversationUI>().event_no = new ConversationUI.ButtonFunction(Toggled_no);
            }
            // 아니라면
            else
            {
                // 테마를 연다
                animedir = animedir == 1 ? -1 : 1;
            }
        }

        draged = false;
    }

    private void Start()
    {
        anime = transform.parent.GetComponent<Animator>();

        themename = transform.parent.GetComponent<Theme>().ThemeName;
    }

    private void Update()
    {
        if (Lock == true)
        {
            LockingIcon();
        }
        else
        {
            UnlockingIcon();
        }

        UpdateList();

        IconAnimation();
    }
    /*
    public override void OnPointerClick(PointerEventData pad)
    {
        draged = false;
    }
    */
    // 아이콘을 잠그는 함수
    void LockingIcon()
    {
        foreach(Image img in GetComponentsInChildren<Image>())
        {
            string iname = img.name;

            if (iname == "LockIcon")
            {
                img.color = new Color(0, 0, 0, 0.6f);
                break;
            }
        }
    }

    // 아이콘을 여는 함수
    void UnlockingIcon()
    {
        foreach (Image img in GetComponentsInChildren<Image>())
        {
            string iname = img.name;

            if (iname == "LockIcon")
            {
                img.color = new Color(0, 0, 0, 0);
                break;
            }
        }
    }

    public void Set_IconLockStatus(bool value)
    {
        Lock = value;
    }

    // 상점 리스트를 지속적으로 갱신
    void UpdateList()
    {
        bool bought = ThemeProduct.Get_Theme(themename).isBought();

        Set_IconLockStatus(!bought);
    }

    void IconAnimation()
    {
        runtime += Time.deltaTime * animedir;
        runtime = Mathf.Clamp01(runtime);

        anime.SetFloat("PlayTime", runtime);
    }

    // ok 버튼을 눌렀을 때 실행하는 메소드
    public override void Toggled_ok()
    {
        base.Toggled_ok();

        // 회화창을 닫는 함수
        UIcloser.closeConversation();
    }

    // yes 버튼을 눌렀을 때 실행하는 메소드
    public override void Toggled_yes()
    {
        base.Toggled_yes();
        
        // 부모 개체의 Theme 클래스 접근해 테마 이름 확인하기
        Theme theme = transform.parent.GetComponent<Theme>();

        // 조건에 맞으면 해금하고 정보를 알림
        if (ThemeProduct.Get_Theme(themename).CanBought() == true)
        {
            UnlockingIcon();

            // 구매 성공!
            GameObject convui = new UIopener().Open_ConversationUI(this, "구매 성공 :)", 1);

            // PlayerPrefs의 데이터를 변경하기
            int price = ThemeProduct.Get_Theme(themename).Get_Price();
            ThemeProduct.Get_Theme(themename).Bought();
            DataChanger.modulateMoneyInGame(-price);
            Set_IconLockStatus(true);

            // 회화창에 이벤트 등록
            convui.GetComponent<ConversationUI>().event_ok = new ConversationUI.ButtonFunction(Toggled_ok);

            return;
        }
        // 조건에 맞지 않으면 새로운 회화창
        else
        {
            // 구매 실패!
            GameObject convui = new UIopener().Open_ConversationUI(this, "구매 실패 :(", 1);

            // 회화창에 이벤트 등록
            convui.GetComponent<ConversationUI>().event_ok = new ConversationUI.ButtonFunction(Toggled_ok);
        }
    }

    // no 버튼을 눌렀을 때 실행하는 메소드
    public override void Toggled_no()
    {
        base.Toggled_no();

        // 회화창을 닫는 함수
        UIcloser.closeConversation();
    }
}

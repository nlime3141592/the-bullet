using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Icon : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IScrollHandler, IPointerClickHandler
{
    // 이 아이콘이 하는 기능
    public string function;

    public bool draged = false;

    MainUI main;

    public bool OnlyIcon = false;

    void Update()
    {
        foreach(MainUI m in GameObject.FindObjectsOfType<MainUI>())
        {
            main = m;
        }
    }

    // 대화창에서 ok 버튼이 눌렸을 때 실행되는 메소드
    public virtual void Toggled_ok()
    {
        Debug.Log("OK 함수 실행");
    }

    // 대화창에서 yes 버튼이 눌렸을 때 실행되는 메소드
    public virtual void Toggled_yes()
    {
        Debug.Log("YES 함수 실행");
    }

    // 대화창에서 no 버튼이 눌렸을 때 실행되는 메소드
    public virtual void Toggled_no()
    {
        Debug.Log("NO 함수 실행");
    }

    // 아이콘을 눌렀을 때 실행되는 메소드
    public virtual void OnPointerDown(PointerEventData pad)
    {
        
    }

    // 아이콘 드래그 시작할 때 실행되는 메소드
    string dir = "null";
    public virtual void OnBeginDrag(PointerEventData pad)
    {
        if (OnlyIcon == false)
        {
            if (Vector2.Angle(Vector2.right, pad.delta) < 30 || Vector2.Angle(Vector2.left, pad.delta) < 30)
            {
                dir = "horizontal";

                if (main != null)
                {
                    main.restrict = false;
                }

                ScrollViewControl("begin", "ScrollView_Main", pad);
                return;
            }
            else if (Vector2.Angle(Vector2.up, pad.delta) < 30 || Vector2.Angle(Vector2.down, pad.delta) < 30)
            {
                dir = "vertical";
                ScrollViewControl("begin", "ScrollView_Theme", pad);
                return;
            }
        }
    }

    // 아이콘을 드래그할 때 실행되는 메소드
    public virtual void OnDrag(PointerEventData pad)
    {
        if (OnlyIcon == false)
        {
            if (dir == "horizontal")
            {
                ScrollViewControl("draging", "ScrollView_Main", pad);
            }
            else if (dir == "vertical")
            {
                ScrollViewControl("draging", "ScrollView_Theme", pad);
            }
        }
    }

    // 스크롤바와 관련된 메소드
    public virtual void OnScroll(PointerEventData pad)
    {
        if (OnlyIcon == false)
        {
            if (dir == "horizontal")
            {
                ScrollViewControl("scroll", "ScrollView_Main", pad);
            }
            else if (dir == "vertical")
            {
                ScrollViewControl("scroll", "ScrollView_Theme", pad);
            }
        }
    }

    // 아이콘 드래그 끝낼 때 실행되는 메소드
    public virtual void OnEndDrag(PointerEventData pad)
    {
        if (OnlyIcon == false)
        {
            if (dir == "horizontal")
            {
                ScrollViewControl("end", "ScrollView_Main", pad);
            }
            else if (dir == "vertical")
            {
                ScrollViewControl("end", "ScrollView_Theme", pad);
            }

            if (main != null)
            {
                main.restrict = true;
            }
        }
    }

    // 아이콘을 클릭 후 손에서 뗐을 때 실행되는 메소드
    public virtual void OnPointerUp(PointerEventData pad)
    {
        if (OnlyIcon == false)
        {
            main = GameObject.FindObjectOfType<MainUI>();
            if (main == null) { return; }

            if (dir == "horizontal")
            {
                main.Set_ScreenIndex();
            }

            dir = "null";

            if (main != null)
            {
                main.restrict = true;
            }
        }
    }

    // 아이콘을 클릭했을 때 실행되는 메소드
    public virtual void OnPointerClick(PointerEventData pad)
    {
        if (OnlyIcon == false)
        {
            main = GameObject.FindObjectOfType<MainUI>();
            if (main == null) { return; }

            if (dir == "horizontal")
            {
                GameObject.FindObjectOfType<MainUI>().Set_ScreenIndex();
            }

            dir = "null";

            if (main != null)
            {
                main.restrict = true;
            }
        }
    }

    // targetname = ScrollView_Theme, ScrollView_Main
    void ScrollViewControl(string status, string targetname, PointerEventData pad)
    {
        if(main == null)
        {
            return;
        }

        if (OnlyIcon == true)
        {
            return; 
        }

        ScrollRect target = GameObject.Find(targetname).GetComponent<ScrollRect>();

        if (target == null)
        {
            return;
        }

        switch(target.name)
        {
            case "ScrollView_Main":
                break;

            case "ScrollView_Theme":
                if(main != null)
                {
                    if (main.screenindex != GameObject.FindObjectOfType<ThemeUI>().screenindex)
                    {
                        return;
                    }
                }
                break;
        }

        if (target != null)
        {
            switch (status)
            {
                case "begin":
                    target.OnBeginDrag(pad);
                    break;
                case "draging":
                    target.OnDrag(pad);
                    break;
                case "end":
                    target.OnEndDrag(pad);
                    break;
                case "scroll":
                    target.OnScroll(pad);
                    break;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIcloser
{
    public static void closeAll()
    {
        foreach(UIcomponent ui in GameObject.FindObjectsOfType<UIcomponent>())
        {
            MonoBehaviour.Destroy(ui.gameObject);
        }
    }

    public static void closeMenu()
    {
        foreach (MenuUI ui in GameObject.FindObjectsOfType<MenuUI>())
        {
            MonoBehaviour.Destroy(ui.gameObject);
        }
    }

    public static void closePause()
    {
        foreach (PauseUI ui in GameObject.FindObjectsOfType<PauseUI>())
        {
            MonoBehaviour.Destroy(ui.gameObject);
        }
    }

    public static void closeGame()
    {
        //foreach (GameUI ui in GameObject.FindObjectsOfType<GameUI>())
        //{
        //    MonoBehaviour.Destroy(ui.gameObject);
        //}
    }

    public static void closeGameEnd()
    {
        foreach (GameEndUI ui in GameObject.FindObjectsOfType<GameEndUI>())
        {
            MonoBehaviour.Destroy(ui.gameObject);
        }
    }

    public static void closeOption()
    {
        foreach (OptionUI ui in GameObject.FindObjectsOfType<OptionUI>())
        {
            MonoBehaviour.Destroy(ui.gameObject);
        }
    }

    public static void closeConversation()
    {
        foreach (ConversationUI ui in GameObject.FindObjectsOfType<ConversationUI>())
        {
            MonoBehaviour.Destroy(ui.gameObject);
        }
    }

    public static void closeTheme()
    {
        foreach(ThemeUI ui in GameObject.FindObjectsOfType<ThemeUI>())
        {
            MonoBehaviour.Destroy(ui.gameObject);
        }
    }

    public static void closeTextbox()
    {
        foreach(TextboxUI ui in GameObject.FindObjectsOfType<TextboxUI>())
        {
            MonoBehaviour.Destroy(ui.gameObject);
        }
    }
}

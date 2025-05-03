using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndUIAnimationEventHandler : MonoBehaviour
{
    public void PlayBest()
    {
        GetComponentInParent<GameEndUI>().PlayAnimation_BestScoreAndText();
    }

    public void AfterAnimation()
    {
        GetComponentInParent<GameEndUI>().AfterAnimation();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcomponent : MonoBehaviour
{ 
    private void Awake()
    {
        
    }

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        Loop();
    }

    // 초기화하는 함수
    public virtual void Initialize()
    {

    }

    // 반복하는 함수
    protected virtual void Loop()
    {

    }
}
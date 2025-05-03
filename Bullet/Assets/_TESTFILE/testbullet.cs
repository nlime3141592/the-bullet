using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testbullet : MonoBehaviour
{
    public Vector3 position;
    public Vector3 direction;

    public float speed = 5;

    void Update()
    {
        Vector3 hor = direction.normalized * speed * Time.deltaTime;

        transform.localPosition += hor;
    }
}
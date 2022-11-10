using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveX : MonoBehaviour
{
    public float speed = 2.0f;
    Rigidbody rb;
    void Start()
    {
        transform.Translate(0, 0, speed);
    }

    void FixedUpdate()
    {

    }
}

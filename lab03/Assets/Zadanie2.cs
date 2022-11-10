using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie2 : MonoBehaviour
{
    Vector3 targetPosition = new Vector3(10, 0, 0);
    public float speed = 2.0f;
    void Start()
    {
    }
    void Update()
    {

        float move = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, move);
        if (transform.position.x == 10)
        {
            targetPosition = new Vector3(0, 0, 0);
        }
    }
}

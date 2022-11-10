using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie3 : MonoBehaviour
{
    Vector3 targetPosition = new Vector3(10, 0, 0);
    public float speed = 2.0f;
    float angle = 90;
    void Start()
    {
        Debug.Log(Vector3.Distance(transform.position, targetPosition));
    }
    void Update()
    {

        float move = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, move);
        if (transform.position.x == 10)
        {
            transform.rotation *= Quaternion.Euler(Vector3.up * 90);
        }
        
    }
}

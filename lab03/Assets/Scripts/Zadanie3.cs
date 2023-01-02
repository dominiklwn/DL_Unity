using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie3 : MonoBehaviour
{
    public float speed;
    private Vector3 targetPosition = new Vector3(10, 0, 0);
    void Update()
    {
        float move = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, move);
        if (transform.position.x <= 0 && transform.position.z <= 0)
        {
            targetPosition = new Vector3(10, 0, 0);
            transform.Rotate(0, -90, 0);
        }
        if (transform.position.x >= 10 && transform.position.z <= 0)
        {
            targetPosition = new Vector3(10, 0, 10);
            transform.Rotate(0, -90, 0);
        }
        if (transform.position.x >= 10 && transform.position.z >= 10)
        {
            targetPosition = new Vector3(0, 0, 10);
            transform.Rotate(0, -90, 0);
        }
        if (transform.position.x <= 0 && transform.position.z >= 10)
        {
            targetPosition = new Vector3(0, 0, 0);
            transform.Rotate(0, -90, 0);
        }
        
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Elevator : MonoBehaviour
{
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _stop;
    [SerializeField] private float _speed = 2f;

    [HideInInspector] public bool isTriggered = false;


    private void FixedUpdate()
    {
        if (isTriggered)
        {
            transform.position = Vector2.MoveTowards(transform.position, _stop.position, _speed* Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, _start.position, _speed* Time.deltaTime);
        }
    }
}
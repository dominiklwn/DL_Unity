using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorUpDown : MonoBehaviour
{
    [SerializeField] private Transform _top;
    [SerializeField] private Transform _bottom;
    [SerializeField] private float _speed = 2f;

    private bool isMovingDown;
    // Start is called before the first frame update
    void Start()
    {
        isMovingDown = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingDown)
        {
            transform.position = Vector2.MoveTowards(transform.position, _bottom.position, _speed * Time.deltaTime) ;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, _top.position, _speed * Time.deltaTime);
        }
        if (transform.position == _bottom.position)
            isMovingDown = false;
        else if (transform.position == _top.position)
            isMovingDown = true;


    }
}

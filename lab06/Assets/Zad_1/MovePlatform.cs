using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    
    private bool isRunningUp = true;
    private bool isRunningDown = false;
    public float elevatorSpeed = 2.0f;
    public float distance = 10.0f;
    private bool isRunning = false;
    private float startPosition;
    private float endPosition;
    private Transform oldParent;

    void Start()
    {
        startPosition = transform.position.z;
        endPosition = transform.position.z + distance;
        
    }

    void Update()
    {
        if (isRunningUp && transform.position.z >= endPosition)
        {
            isRunning = false;
        }
        else if (isRunningDown && transform.position.z <= startPosition)
        {
            isRunning = false;
        }

        if (isRunning)
        {
            Vector3 move = transform.forward * elevatorSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            oldParent = other.gameObject.transform.parent;
            other.gameObject.transform.SetParent(transform);
            if (transform.position.z >= endPosition)
            {
                isRunningDown = true;
                isRunningUp = false;
                elevatorSpeed = -elevatorSpeed;
            }
            else if (transform.position.z <= startPosition)
            {
                isRunningUp = true;
                isRunningDown = false;
                elevatorSpeed = Mathf.Abs(elevatorSpeed);
            }
            isRunning = true;
        }
        Debug.Log(oldParent);
        
    }
    private void OnTriggerExit(Collider other)
    {
            Debug.Log("exit");
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent = null;
        }
    }
}

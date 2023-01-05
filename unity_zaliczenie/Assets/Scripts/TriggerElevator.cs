using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerElevator : MonoBehaviour
{
    [SerializeField] private Elevator elevator;
    [SerializeField] private Animator animator;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Watergirl") || collision.CompareTag("Fireboy"))
        {
            elevator.isTriggered = true;
            animator.SetBool("isTriggered", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Watergirl") || collision.CompareTag("Fireboy"))
        {
            elevator.isTriggered = false;
            animator.SetBool("isTriggered", false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerElevator2 : MonoBehaviour
{
    [SerializeField] private Elevator elevator;
    [SerializeField] private Animator animator2;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Watergirl") || collision.CompareTag("Fireboy"))
        {
            elevator.isTriggered = true;
            animator2.SetBool("isTriggered", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Watergirl") || collision.CompareTag("Fireboy"))
        {
            elevator.isTriggered = false;
            animator2.SetBool("isTriggered", false);
        }
    }
}

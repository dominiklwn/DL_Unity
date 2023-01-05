using UnityEngine;

public class EndLevelBoy : MonoBehaviour
{
    [SerializeField] private Transform doorLeft;
    [SerializeField] private Transform doorRight;
    [SerializeField] private Fireboy fireboy;
    [SerializeField] float distance = 0.5f;
    [SerializeField] float speed = 0.025f;
    private Vector2 _targetLeft;
    private Vector2 _targetRight;
    [SerializeField] private Animator animator;
    [SerializeField] private Animator fireboyAnimator;

    private void Update()
    {
        if (GlobalVariableStorage._pIsWin)
        {
            fireboy.transform.position = Vector2.MoveTowards(fireboy.transform.position, transform.position, speed);
            fireboy.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            fireboyAnimator.SetBool("isTriggered", true);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fireboy"))
        {
            GlobalVariableStorage._pIsBoyOn = true;
            animator.SetBool("isTriggered", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Fireboy"))
        {
           GlobalVariableStorage._pIsBoyOn = false;
           animator.SetBool("isTriggered", false);
        }
    }
}

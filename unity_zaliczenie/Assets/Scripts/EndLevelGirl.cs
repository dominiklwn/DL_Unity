using UnityEngine;

public class EndLevelGirl : MonoBehaviour
{
    [SerializeField] private Transform doorLeft;
    [SerializeField] private Transform doorRight;
    [SerializeField] private Watergirl watergirl;
    [SerializeField] float distance = 0.5f;
    [SerializeField] float speed = 0.025f;
    private Vector2 _targetLeft;
    private Vector2 _targetRight;
    [SerializeField] private Animator animator;
    [SerializeField] private Animator watergirlAnimator;
    

    private void Update()
    {
        if (GlobalVariableStorage._pIsWin)
        {
            watergirl.transform.position = Vector2.MoveTowards(watergirl.transform.position, transform.position, speed);
            watergirl.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            watergirlAnimator.SetBool("isTriggered", true);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Watergirl"))
        {
            GlobalVariableStorage._pIsGirlOn = true;
            animator.SetBool("isTriggered", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Watergirl"))
        {
            GlobalVariableStorage._pIsGirlOn = false;
            animator.SetBool("isTriggered", false);
        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class WinLose : MonoBehaviour
{
    private bool isGameFinished;
    private void Update()
    {

        if (GlobalVariableStorage._pIsBoyOn && GlobalVariableStorage._pIsGirlOn)
        {
            GlobalVariableStorage._pIsWin = true;
            WinLevel();
        }
    }
    public void WinLevel()
    {
        //Physics2D.IgnoreCollision(watergirl.GetComponent<Collider2D>(), player2.GetComponent<Collider2D>());
        InputSystem.DisableDevice(Keyboard.current);
    }
    public void LoseLevel()
    {
        if (!isGameFinished)
        {
            Debug.Log("You failed");
            isGameFinished = true;
            SceneManager.LoadScene("GameLost");
        }
    }
}

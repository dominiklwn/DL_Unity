using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void BackToMenuScript()
    {
        SceneManager.LoadScene("Menu");
    }
}

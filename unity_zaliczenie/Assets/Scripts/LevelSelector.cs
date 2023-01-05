using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class LevelSelector : MonoBehaviour
{
    public int level;
    public TMPro.TMP_Text levelText;
    void Start()
    {
        levelText.text = "Level " + level.ToString();
    }
    public void OpenScene()
    {
        SceneManager.LoadScene("Level" + level.ToString());
    }
}

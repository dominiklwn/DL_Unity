using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public WinLose winLoseScript;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Watergirl"))
        {
            winLoseScript.LoseLevel();
        }
    }
}

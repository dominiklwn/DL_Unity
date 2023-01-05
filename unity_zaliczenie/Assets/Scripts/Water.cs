using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public WinLose winLoseScript;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Fireboy"))
        {
            winLoseScript.LoseLevel();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariableStorage : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool _pIsGirlOn;
    public static bool _pIsBoyOn;
    public static bool _pIsWin;
    void Start()
    {
        _pIsBoyOn = false;
        _pIsGirlOn = false;
        _pIsWin = false;
    }
}

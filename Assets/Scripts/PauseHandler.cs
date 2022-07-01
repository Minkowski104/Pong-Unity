using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    public void OnButtonPress()
    {
        Time.timeScale = Time.timeScale==0?1:0;
    }
}

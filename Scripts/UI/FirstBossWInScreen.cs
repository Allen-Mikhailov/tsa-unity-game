using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossWInScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public void Replay()
    {
        Debug.Log("REplay");
        Time.timeScale = 1;
        SceneTransitions.trans.Transition("Boss Level");
    }

    public void BackToMenu()
    {
        Debug.Log("Back to main");
        Time.timeScale = 1;
        SceneTransitions.trans.Transition("Main Menu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    // Start is called before the first frame update
    public static SceneTransitions trans;
    public RectTransform rect;
    string nextScene;
    float alpha = -1;
    int dir;

    float tweenTime = 1;

    void Start()
    {
        if (trans == null)
        {
            trans = this;
            GameObject.DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }

        rect.position = new Vector3(-Screen.width/2, Screen.height/2, 0);
    }

    public void Transition(string newScene)
    {
        nextScene = newScene;
        alpha = 0;
        dir = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (alpha != -1)
        {
            alpha += Time.deltaTime/tweenTime;
            alpha = Mathf.Min(alpha, 1);

            if (dir == 1)
            {
                rect.position = new Vector3(-Screen.width/2 + alpha * Screen.width, Screen.height/2);
            } else if (dir == 0) {
                rect.position = new Vector3(Screen.width/2+1, Screen.height/2);
            } else if (dir == -1) {
                rect.position = new Vector3(Screen.width/2 - alpha * Screen.width, Screen.height/2);
            }

            if (alpha == 1)
            {
                if (dir == -1)
                {
                    alpha = -1;
                } else {
                    SceneManager.LoadScene(nextScene);
                    alpha = 0;
                    dir--;
                }
            }
        }
    }
}

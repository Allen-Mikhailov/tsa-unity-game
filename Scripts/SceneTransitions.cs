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

    private string current_scene = "Main Menu";

    [System.Serializable]
    public struct SceneMusic { public string scene_name; public AudioClip music; }

    private Dictionary<string, int> scene_to_music = new Dictionary<string, int>();

    public SceneMusic[] sceneMusic;
    private AudioSource source;

    float tweenTime = 1;
    bool hadMusicUpdate = false;

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

        source = gameObject.GetComponent<AudioSource>();

        for (int i = 0; i < sceneMusic.Length; i++)
        {
            scene_to_music[sceneMusic[i].scene_name] = i;
        }

        updateMusic();
    }

    public void updateMusic()
    {
        if (hadMusicUpdate) {return;}
        source.clip = sceneMusic[scene_to_music[current_scene]].music;
        source.Play();

        Debug.Log(current_scene + ", " + scene_to_music[current_scene]);

        hadMusicUpdate = true;
    }

    public void Transition(string newScene)
    {
        nextScene = newScene;
        alpha = 0;
        dir = 1;

        hadMusicUpdate = false;
        
        if (PlayerMovement.plr != null)
            PlayerMovement.plr.freeze = true;
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
                current_scene = nextScene;
            } else if (dir == -1) {
                rect.position = new Vector3(Screen.width/2 - alpha * Screen.width, Screen.height/2);
            }

            if (alpha == 1)
            {
                if (dir == -1)
                {
                    alpha = -1;
                } else if (dir == 1) {
                    updateMusic();
                    SceneManager.LoadScene(nextScene);
                    alpha = 0;
                    dir = 0;
                } else if (dir == 0) {
                    alpha = 0;
                    dir = -1;
                }
            }
        }
    }
}

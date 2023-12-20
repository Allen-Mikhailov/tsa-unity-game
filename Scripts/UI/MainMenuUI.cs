using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject PlayButton;

    public GameObject LevelsMenu;
    public GameObject LevelButton;

    public string[] Levels = {};

    float spacing = 200;

    void Start()
    {
        for (int j = 0; j < Levels.Length; j++)
        {
            int i = j;
            GameObject newLevelButton = Instantiate(LevelButton) as GameObject;
            RectTransform rtrans = newLevelButton.GetComponent<RectTransform>();
            TextMeshProUGUI text = newLevelButton.GetComponentInChildren<TextMeshProUGUI>();
            text.text = Levels[i];

            Button button = newLevelButton.GetComponent<Button>();
            button.onClick.AddListener(delegate {SceneTransitions.trans.Transition(Levels[i]);});

            rtrans.anchoredPosition = new Vector3(Screen.width/2 + spacing * (i - (Levels.Length-1)/2), Screen.height/2);

            newLevelButton.transform.parent = LevelsMenu.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

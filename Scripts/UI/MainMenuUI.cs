using System;
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
    float yspacing = 75;
    int row_size = 4;

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
            int row = i/row_size;
            int row_left = Math.Min(Levels.Length - row*4, row_size);
            float space = (i%row_left - (row_left-1)/2.0f);
            float yspace = (row - Levels.Length/row_size/2f);
            rtrans.anchoredPosition = new Vector3(
                Screen.width/2 + spacing * space, 
                Screen.height/2 - yspacing * yspace
                );

            newLevelButton.transform.SetParent(LevelsMenu.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenLevelMenu()
    {
        StartMenu.SetActive(false);
        LevelsMenu.SetActive(true);
    }
}

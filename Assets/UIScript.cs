using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        Button exitButton = GameObject.Find("ExitButton").GetComponent<Button>();
        exitButton.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PlayGame()
    {
        
    }

    void QuitGame()
    {
        Application.Quit(0);
    }
}

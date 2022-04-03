using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        playButton.onClick.AddListener(PlayGame);

        Button exitButton = GameObject.Find("ExitButton").GetComponent<Button>();
        exitButton.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PlayGame()
    {
        // SceneManager.UnloadSceneAsync("MainMenu");
        SceneManager.LoadScene("SampleScene");
    }

    void QuitGame()
    {
        Application.Quit(0);
    }
}

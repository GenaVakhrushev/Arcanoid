using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtons : Singleton<LevelButtons>
{
    [SerializeField] private GameObject nextLevelButton;

    public void Pause()
    {
        GameManager.Pause();
    }

    public void Resume()
    {
        GameManager.Resume();
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        Resume();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void DiableNextLevelButton()
    {
        Instance.nextLevelButton.SetActive(false);
    }
}

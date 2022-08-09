using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Doozy.Runtime.Nody;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int startHP = 3;

    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private FlowGraph flowGraph;

    private static int bricksCount = 0;

    private void Start()
    {
        HP = startHP;

        BricksCount = FindObjectsOfType<Brick>().Length;

        if (SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings)
        {
            LevelButtons.DiableNextLevelButton();
        }

        Resume();
    }

    public static int HP
    {
        get
        {
            return int.Parse(Instance.hpText.text);
        }

        set
        {
            if(value <= 0)
            {
                Lose();
                return;
            }

            Instance.hpText.text = value.ToString();
        }
    }

    public static int BricksCount
    {
        get
        {
            return bricksCount;
        }

        set
        {
            if(value <= 0)
            {
                Win();
            }

            bricksCount = value;
        }
    }

    private static void Win()
    {
        Pause();

        Instance.flowGraph.SetActiveNodeByNodeName("Win");
    }

    private static void Lose()
    {
        Pause();

        Instance.flowGraph.SetActiveNodeByNodeName("Lose");
    }

    public static void Pause()
    {
        Time.timeScale = 0;
    }

    public static void Resume()
    {
        Time.timeScale = 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    private TextMeshProUGUI label;
    private int num = -1;

    private void Start()
    {
        label = GetComponentInChildren<TextMeshProUGUI>();
        num = transform.GetSiblingIndex() + 1;
        label.text = num.ToString();
    }

    private void OnDrawGizmos()
    {
        if(num < 0)
        {
            Start();
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(num);
    }
}
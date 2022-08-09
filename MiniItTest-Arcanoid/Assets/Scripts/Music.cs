using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private void Start()
    {
        if(FindObjectsOfType<Music>().Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SetSoundsOnOff(bool isOn)
    {
        AudioListener.volume = isOn ? 1 : 0;
    }
}

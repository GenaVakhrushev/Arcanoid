using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBorders : MonoBehaviour
{
    void Start()
    {
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        Vector2 screenRightTopPoint = Camera.main.ScreenToWorldPoint(screenSize);
        List<Vector2> colliderPoints = new List<Vector2>();
        
        for (int i = 0; i < 5; i++)
        {
            colliderPoints.Add(new Vector2(screenRightTopPoint.x * Mathf.Pow(-1, i / 2), screenRightTopPoint.y * Mathf.Pow(-1, (i + 1) / 2)));
        }
        GetComponent<EdgeCollider2D>().SetPoints(colliderPoints);
    }
}

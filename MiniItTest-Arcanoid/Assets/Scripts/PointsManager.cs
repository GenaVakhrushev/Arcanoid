using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManager : Singleton<PointsManager>
{
    private static int points;

    [SerializeField] private TextMeshProUGUI pointsText;

    public static void AddPoints(int count)
    {
        points += count;

        Instance.pointsText.text = points.ToString();
    }
}

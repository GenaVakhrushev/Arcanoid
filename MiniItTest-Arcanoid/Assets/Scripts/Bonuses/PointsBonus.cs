using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsBonus : Bonus
{
    [SerializeField] private int pointsCount = 0;

    [SerializeField] private TextMeshPro text;

    private void Start()
    {
        text.text = pointsCount.ToString();
    }

    public override void Collect()
    {
        base.Collect();

        PointsManager.AddPoints(pointsCount);
    }

    private void OnDrawGizmos()
    {
        Start();
    }
}

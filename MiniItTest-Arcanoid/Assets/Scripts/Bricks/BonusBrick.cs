using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BonusBrick : Brick
{
    [SerializeField, Range(0, 100)] private float bonusSpawnChancePercent = 10;
    [SerializeField] private BonusRatio[] bonusRatios;

    public BonusRatio[] BonusRatios => bonusRatios;

    protected override void Break()
    {
        base.Break();

        if(Random.value * 100 <= bonusSpawnChancePercent)
        {
            SpawnBonus();
        }
    }

    private void SpawnBonus()
    {
        float totalSum = 0;

        for (int i = 0; i < bonusRatios.Length; i++)
        {
            totalSum += bonusRatios[i].RatioPart;
        }

        float random = Random.Range(0, totalSum);
        float currentSum = bonusRatios[0].RatioPart;

        for (int i = 0; i < bonusRatios.Length; i++)
        {
            if (random < currentSum)
            {
                Instantiate(bonusRatios[i].Bonus, transform.position, Quaternion.identity);
                return;
            }
            else
            {
                currentSum += bonusRatios[i].RatioPart;
            }
        }
    }
}


[System.Serializable]
public class BonusRatio
{
    public GameObject Bonus;
    public float RatioPart;

    [ReadOnly] public float ChancePercent;
}

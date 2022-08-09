using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurationalBonusesManager : MonoBehaviour
{
    private static List<DurationalBonus> activeBonuses;

    private void Start()
    {
        activeBonuses = new List<DurationalBonus>();
    }

    public static void AddBonus(DurationalBonus bonus)
    {
        for (int i = 0; i < activeBonuses.Count; i++)
        {
            if (activeBonuses[i].GetType() == bonus.GetType())
            {
                activeBonuses[i].EndAffect();
                i--;
            }
        }

        activeBonuses.Add(bonus);
        DurationalBonusDisplay.AddBonus(bonus);
    }

    public static void RemoveBonus(DurationalBonus bonus)
    {
        activeBonuses.Remove(bonus);
        DurationalBonusDisplay.RemoveBonus(bonus);
    }
}

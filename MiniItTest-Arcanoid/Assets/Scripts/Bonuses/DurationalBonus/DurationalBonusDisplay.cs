using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurationalBonusDisplay : Singleton<DurationalBonusDisplay>
{
    private static Dictionary<DurationalBonus, BonusCard> cards;

    [SerializeField] private GameObject bonusCardPrefab;
    public static GameObject BonusCardPrefab => Instance.bonusCardPrefab;

    private void Start()
    {
        cards = new Dictionary<DurationalBonus, BonusCard>();
    }

    public static void AddBonus(DurationalBonus bonus)
    {
        BonusCard bonusCard = BonusCard.Create(bonus);

        cards.Add(bonus, bonusCard);
    }

    public static void RemoveBonus(DurationalBonus bonus)
    {
        BonusCard bonusCard = cards[bonus];
        
        bonusCard.Remove();
        cards.Remove(bonus);
    }
}

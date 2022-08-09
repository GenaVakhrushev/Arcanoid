using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusCard : MonoBehaviour
{
    private float duration = 0;
    private float remainingTime = 0;

    [SerializeField] private Image progress;
    [SerializeField] private Image image;

    private void Update()
    {
        remainingTime -= Time.deltaTime;

        progress.fillAmount = remainingTime / duration;
        progress.color = Color.Lerp(Color.red, Color.green, progress.fillAmount);
    }

    public static BonusCard Create(DurationalBonus bonus)
    {
        GameObject prefabClone = Instantiate(DurationalBonusDisplay.BonusCardPrefab, DurationalBonusDisplay.Instance.transform);
        BonusCard bonusCard = prefabClone.GetComponent<BonusCard>();

        bonusCard.image.sprite = bonus.Sprite;
        bonusCard.duration = bonus.Duration;
        bonusCard.remainingTime= bonus.Duration;

        return bonusCard;
    }

    public void Remove()
    {
        Destroy(gameObject);
    }
}

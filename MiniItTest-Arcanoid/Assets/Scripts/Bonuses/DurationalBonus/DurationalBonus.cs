using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DurationalBonus : Bonus
{
    [SerializeField] private float duration = 10f;

    private SpriteRenderer spriteRenderer;

    public Sprite Sprite => spriteRenderer.sprite;
    public float Duration => duration;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public override void Collect()
    {
        SFX.Play(BonusSound, 0.1f);

        spriteRenderer.transform.gameObject.SetActive(false);
        falling = false;

        StartCoroutine(Affect());
        DurationalBonusesManager.AddBonus(this);
    }

    private IEnumerator Affect()
    {
        yield return new WaitForSeconds(duration);

        EndAffect();
    }

    public virtual void EndAffect()
    {
        DurationalBonusesManager.RemoveBonus(this);

        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] private int hitsToBreak = 1;
    [SerializeField] private int pointsForBreak = 100;

    protected int currentHitsCount = 0;

    [SerializeField] private AudioClip HitSound;
    [SerializeField] private AudioClip BreakSound;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void Hit()
    {
        currentHitsCount++;

        if (currentHitsCount == hitsToBreak)
        {
            Break();
        }

        SFX.Play(HitSound);

        spriteRenderer.material.color -= new Color(0, 0, 0, 1f / hitsToBreak);
    }

    protected virtual void Break()
    {
        PointsManager.AddPoints(pointsForBreak);

        SFX.Play(BreakSound);

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        GameManager.BricksCount--;
    }
}

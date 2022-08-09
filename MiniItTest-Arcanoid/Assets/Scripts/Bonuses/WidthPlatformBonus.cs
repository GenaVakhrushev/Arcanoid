using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WidthPlatformBonus : DurationalBonus
{
    [SerializeField] private float width = 1.5f;

    public override void Collect()
    {
        base.Collect();

        Platform.Instance.SpriteRenderer.transform.localScale = new Vector3(width, 1, 1);
    }

    public override void EndAffect()
    {
        base.EndAffect();
        
        Platform.Instance.SpriteRenderer.transform.localScale = new Vector3(1, 1, 1);
    }
}

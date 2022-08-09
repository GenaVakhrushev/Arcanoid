using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    protected bool falling = true;

    [SerializeField] private float fallingSpeed = 1f;

    [SerializeField] protected AudioClip BonusSound;

    private void FixedUpdate()
    {
        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }

        if (falling)
        {
            transform.Translate(Vector2.down * fallingSpeed * Time.deltaTime);
        }
    }

    public virtual void Collect()
    {
        SFX.Play(BonusSound, 0.1f);
        Destroy(gameObject);
    }
}

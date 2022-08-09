using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : Singleton<Platform>
{
    private Vector3 destination;

    [SerializeField] private float Speed = 15f;

    private Ball currentBall;
    public Ball CurrentBall => currentBall;

    private SpriteRenderer spriteRenderer;
    public SpriteRenderer SpriteRenderer => spriteRenderer;

    [SerializeField] private AudioClip hitSound;
    public AudioClip HitSound => hitSound;

    private void Start()
    {
        destination = transform.position;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        transform.Translate((destination - transform.position) * Speed * Time.deltaTime, Space.World);
    }

    public void SetDestination(Vector3 newDestination)
    {
        destination = newDestination;
    }

    public void SetCurrentBall(Ball ball)
    {
        ball.transform.SetParent(gameObject.transform);

        ball.SetInteractable(false);

        currentBall = ball;
    }

    public void ResetCurrentBall()
    {
        currentBall.transform.parent = null;

        currentBall.SetInteractable(true);

        currentBall = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bonus bonus = collision.transform.GetComponentInParent<Bonus>();

        if (bonus)
        {
            bonus.Collect();
        }
    }
}

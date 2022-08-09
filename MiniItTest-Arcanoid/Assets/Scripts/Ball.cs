using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum BallState
{
    OnPlatform = 0,
    Flying = 1,
}

public class Ball : MonoBehaviour
{
    private BallState state = BallState.OnPlatform;

    private Platform platform;

    private LineRenderer lineRenderer;
    private new Rigidbody2D rigidbody;

    [SerializeField] private float LaunchPower = 20f;

    [SerializeField] private AudioClip JumpSound;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        platform = GameObject.FindGameObjectWithTag("Player").GetComponent<Platform>();
    }

    public void DrawLine(Vector2 aimPos)
    {
        if (state != BallState.OnPlatform)
        {
            return;
        }

        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, aimPos);
    }

    public void Launch(Vector2 aimPos)
    {
        if (state != BallState.OnPlatform)
        {
            return;
        }

        lineRenderer.enabled = false;

        rigidbody.AddForce((aimPos - (Vector2)transform.position).normalized * LaunchPower);

        platform.ResetCurrentBall();

        state = BallState.Flying;
    }

    public void SetInteractable(bool value)
    {
        rigidbody.simulated = value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BallsManager.RemoveBall();

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Brick brick = collision.transform.GetComponentInParent<Brick>();

        if (brick)
        {
            brick.Hit();

            return;
        }

        Platform platform = collision.transform.GetComponentInParent<Platform>();

        if (platform)
        {
            float velocityLen = rigidbody.velocity.magnitude;

            rigidbody.velocity = (transform.position - platform.transform.position).normalized * velocityLen;

            SFX.Play(platform.HitSound);

            return;
        }

        SFX.Play(JumpSound);
    }
}

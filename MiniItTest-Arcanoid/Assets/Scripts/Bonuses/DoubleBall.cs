using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBall : Bonus
{
    public override void Collect()
    {
        base.Collect();

        Ball ball = Platform.Instance.CurrentBall;

        if (ball != null)
        {
            ball.Launch(Vector2.up);
        }

        BallsManager.SpawnBall();
    }
}

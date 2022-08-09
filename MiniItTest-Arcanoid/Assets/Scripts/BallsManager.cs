using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsManager : Singleton<BallsManager>
{
    private static int ballsConut = 1;

    private static Platform platform;

    [SerializeField] private GameObject BallPrefab;

    private void Start()
    {
        platform = Platform.Instance;
        platform.SetCurrentBall(GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>());
    }

    public static void AddBall()
    {
        ballsConut++;
    }

    public static void RemoveBall()
    {
        ballsConut--;

        if(ballsConut == 0)
        {
            SpawnBall();

            GameManager.HP--;
        }
    }

    public static void SpawnBall()
    {
        Ball ball = Instantiate(Instance.BallPrefab, platform.transform.position + new Vector3(0, 0.275f, 0), Quaternion.identity).GetComponent<Ball>();
        
        ballsConut++;

        platform.SetCurrentBall(ball);
    }
}

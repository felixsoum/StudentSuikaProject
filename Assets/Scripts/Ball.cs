using UnityEngine;

public class Ball : MonoBehaviour
{
    public int ballIndex;

    public int ballScore;

    bool isFusioning;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isFusioning)
        {
            Destroy(gameObject);
            return;
        }

        var otherBall = collision.gameObject.GetComponent<Ball>();
        if (otherBall != null)
        {
            Debug.Log($"Ball {gameObject.name} collide with ball {collision.gameObject.name}");

            if (ballIndex == otherBall.ballIndex)
            {
                Debug.Log("Same ball collision, now FUSION!");

                FindAnyObjectByType<Score>().AddScore(ballScore);

                isFusioning = true;
                otherBall.isFusioning = true;

                Vector3 middlePoint = (transform.position + otherBall.transform.position) / 2f;

                FindAnyObjectByType<Player>().SpawnBall(ballIndex + 1, middlePoint);
                Destroy(gameObject);
                return;
            }
        }
    }
}

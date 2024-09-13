using UnityEngine;

public class Ball : MonoBehaviour
{
    public int ballIndex;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var otherBall = collision.gameObject.GetComponent<Ball>();
        if (otherBall != null)
        {
            Debug.Log($"Ball {gameObject.name} collide with ball {collision.gameObject.name}");

            if (ballIndex == otherBall.ballIndex)
            {
                Debug.Log("Same ball collision, now FUSION!");
            }
        }
    }
}

using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] Animator gameoverAnimator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameoverAnimator.SetTrigger("Jimmy");
    }
}

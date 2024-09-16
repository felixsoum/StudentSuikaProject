using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    int score;

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "SCORE: " + score;
    }
}

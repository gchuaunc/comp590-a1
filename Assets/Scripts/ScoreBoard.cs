using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    private int score;
    [SerializeField] private TextMeshPro scoreText;

    public static ScoreBoard instance;

    void Awake() {
        if (instance != null) {
            Debug.LogWarning("More than one ScoreBoard found in scene, this one will be disabled");
            gameObject.SetActive(false);
            return;
        }
        instance = this;
        score = 0;
    }

    public void IncreaseScore(int amount) {
        score += amount;
        scoreText.text = score.ToString();
    }
}

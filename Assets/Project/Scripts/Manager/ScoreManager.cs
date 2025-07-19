using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [Header(" ScoreText")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI orbText;

    [Header(" Scoring")]
    [SerializeField] private Transform player;
    [SerializeField] private float distanceMultiplier = 1f;
    [SerializeField] private int orbPoints = 10;

    [SerializeField] private float startZ;
    [SerializeField] private int collectedOrbs = 0;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);

        }
        else
        {
            Instance = this;
        }
    }
    void Update()
    {
        if (!GameManager.Instance.GetIsGameRunning()) return;

        float distanceScore = (player.position.z - startZ) * distanceMultiplier;
        int totalScore = Mathf.RoundToInt(distanceScore) + (collectedOrbs * orbPoints);
        scoreText.text = "" + totalScore;
    }
    public void AddOrb()
    {
        collectedOrbs++;
        orbText.text = "" + collectedOrbs;
    }

}

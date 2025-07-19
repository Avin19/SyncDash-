using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header(" Speed Controls ")]
    [SerializeField] private float gameSpeed = 5f;
    [SerializeField] private float speedIncresaseRate = 0.1f;
    [SerializeField] private float maxSpeed = 20f;

    private bool isGamedRuninng = true;

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
        if (!isGamedRuninng) return;

        gameSpeed += speedIncresaseRate * Time.deltaTime;
        gameSpeed = Mathf.Min(gameSpeed, maxSpeed);

    }

    public float GetGameSpeed()
    {
        return gameSpeed;
    }
}

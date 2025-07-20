using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header(" Speed Controls ")]
    [SerializeField] private float gameSpeed = 5f;
    [SerializeField] private float speedIncresaseRate = 0.1f;
    [SerializeField] private float maxSpeed = 20f;

    private bool isGamedRuninng;
    [Header("Motion blur Effect ")]
    [SerializeField] private VolumeProfile volumeProfile;
    [SerializeField] private float blurMaxIntensity = 0.5f;
    [SerializeField] private float blurStartSpeed = 5f;
    private MotionBlur motionBlur;
    [SerializeField] private Transform player;

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
    void Start()
    {
        volumeProfile.TryGet<MotionBlur>(out motionBlur);
    }
    void Update()
    {
        if (!isGamedRuninng) return;

        gameSpeed += speedIncresaseRate * Time.deltaTime;
        gameSpeed = Mathf.Min(gameSpeed, maxSpeed);
        if (motionBlur != null)
        {
            float t = Mathf.InverseLerp(blurStartSpeed, maxSpeed, gameSpeed);
            motionBlur.intensity.value = Mathf.Lerp(0f, blurMaxIntensity, t);
        }

    }

    public float GetGameSpeed()
    {
        return gameSpeed;
    }

    public bool GetIsGameRunning()
    {
        return isGamedRuninng;
    }
    public void SetIsGameRuning(bool _isGamedRuninng)
    {
        isGamedRuninng = _isGamedRuninng;
    }

    public Transform GetPlayerPosition()
    {
        return player;
    }
}

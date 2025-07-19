using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private GameManager instance;

    [Header(" Speed Controls ")]
    [SerializeField] private float _gameSpeed = 5f;
    [SerializeField] private float _speedIncresaseRate = 0.1f;
    [SerializeField] private float _maxSpeed = 20f;
}

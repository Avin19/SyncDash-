using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance { get; private set; }

    [Header("Pools")]
    [SerializeField] private ObjectPool groundTilePool;
    [SerializeField] private ObjectPool obstaclePool;
    [SerializeField] private ObjectPool orbPool;

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
    public GameObject GetGroundTile() => groundTilePool.Get();
    public GameObject GetObstacle() => obstaclePool.Get();
    public GameObject GetOrb() => orbPool.Get();

    public void ReturnGround(GameObject obj) => groundTilePool.ReturnToPool(obj);
    public void ReturnObstacle(GameObject obj) => obstaclePool.ReturnToPool(obj);
    public void ReturnOrb(GameObject obj) => orbPool.ReturnToPool(obj);
}

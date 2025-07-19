using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Transform[] obstaclePoints;
    [SerializeField] private GameObject pfObstaclePrefab;
    [SerializeField] private GameObject pfOrbPrefab;

    void Start()
    {
        int spawnChance = Random.Range(0, 100);
        if (spawnChance < 50)
        {
            int index = Random.Range(0, obstaclePoints.Length);
            Instantiate(pfObstaclePrefab, obstaclePoints[index].position, Quaternion.identity, transform);
        }
        if (spawnChance > 60)
        {
            int orbIndex = Random.Range(0, obstaclePoints.Length);
            Instantiate(pfOrbPrefab, obstaclePoints[orbIndex].position + Vector3.up * 1.5f, Quaternion.identity, transform);
        }
    }
}

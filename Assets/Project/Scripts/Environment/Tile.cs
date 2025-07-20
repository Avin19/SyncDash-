
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Transform[] obstaclePoints;

    [SerializeField] private float returnOffset = 30f;
    [Range(0, 100)][SerializeField] private int obstacleSpawnChance = 60;
    [Range(0, 100)][SerializeField] private int orbSpawnChance = 40;


    void OnEnable()
    {
        SpawnContents();

    }

    private void SpawnContents()
    {
        foreach (Transform point in obstaclePoints)
        {
            // Random chance to spawn an obstacle
            if (Random.Range(0, 100) < obstacleSpawnChance)
            {
                GameObject obstacle = PoolManager.Instance.GetObstacle();
                obstacle.transform.position = point.position;
                obstacle.transform.rotation = point.rotation;
                obstacle.transform.SetParent(transform);
            }

            // Random chance to spawn an orb
            else if (Random.Range(0, 100) < orbSpawnChance)
            {
                GameObject orb = PoolManager.Instance.GetOrb();
                orb.transform.position = point.position + Vector3.up * 1f;
                orb.transform.rotation = Quaternion.identity;
                orb.transform.SetParent(transform);
            }
        }
    }

    void Update()
    {
        if (transform.position.z + returnOffset < GameManager.Instance.GetPlayerPosition().position.z)
        {
            ResetTile();
            PoolManager.Instance.ReturnGround(gameObject);
        }
    }
    public void ResetTile()
    {
        // Return any children (obstacles or orbs) to their pools
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Obstacle"))
            {

                PoolManager.Instance.ReturnObstacle(child.gameObject);
            }

            else if (child.CompareTag("Orb"))
                PoolManager.Instance.ReturnOrb(child.gameObject);
        }
    }
}

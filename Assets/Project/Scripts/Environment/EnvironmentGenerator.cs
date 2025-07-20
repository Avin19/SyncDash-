using System.Collections.Generic;
using UnityEngine;

public class EnvironmentGenerator : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject pfgroundTile;
    [SerializeField] private float tileLength = 10f;
    [SerializeField] private int initialTiles = 5;
    [SerializeField] private float spawnZ = 0f;



    void Start()
    {
        for (int i = 0; i < initialTiles; i++)
        {
            SpawnTile();
        }
    }
    void Update()
    {
        if (!GameManager.Instance.GetIsGameRunning()) return;

        if (player.position.z > spawnZ - (tileLength * initialTiles))
        {
            SpawnTile();
        }
    }

    private void SpawnTile()
    {
        Vector3 newTilePosition = new Vector3(0f, -0.53f, 1f * spawnZ);
        GameObject tile = PoolManager.Instance.GetGroundTile();
        tile.transform.position = newTilePosition;
        tile.SetActive(true);

        spawnZ += tileLength;

    }
}

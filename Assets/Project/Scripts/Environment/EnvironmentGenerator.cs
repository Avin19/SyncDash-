using System.Collections.Generic;
using UnityEngine;

public class EnvironmentGenerator : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject pfgroundTile;
    [SerializeField] private float tileLength = 10f;
    [SerializeField] private int initialTiles = 5;
    [SerializeField] private float spawnZ = 0f;

    private Queue<GameObject> _tileQueue = new Queue<GameObject>();

    void Start()
    {
        for (int i = 0; i < initialTiles; i++)
        {
            SpawnTile();
        }
    }
    void Update()
    {
        if (player.position.z > spawnZ - (tileLength * initialTiles))
        {
            SpawnTile();
        }
    }

    private void SpawnTile()
    {
        GameObject tile = Instantiate(pfgroundTile, new Vector3(0f, -0.53f, 1f * spawnZ), Quaternion.identity);

        _tileQueue.Enqueue(tile);
        spawnZ += tileLength;

        if (_tileQueue.Count > initialTiles + 2)
        {
            GameObject _oldTile = _tileQueue.Dequeue();
            Destroy(_oldTile);
        }


    }
}

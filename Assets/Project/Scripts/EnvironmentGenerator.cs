using System;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentGenerator : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _pfgroundTile;
    [SerializeField] private float _tileLength = 10f;
    [SerializeField] private int _initialTiles = 5;
    [SerializeField] private float _spawnZ = 0f;

    private Queue<GameObject> _tileQueue = new Queue<GameObject>();

    void Start()
    {
        for (int i = 0; i < _initialTiles; i++)
        {
            SpawnTile();
        }
    }
    void Update()
    {
        if (_player.position.z > _spawnZ - (_tileLength * _initialTiles))
        {
            SpawnTile();
        }
    }

    private void SpawnTile()
    {
        GameObject tile = Instantiate(_pfgroundTile, new Vector3(0f, -0.53f, 1f * _spawnZ), Quaternion.identity);

        _tileQueue.Enqueue(tile);
        _spawnZ += _tileLength;

        if (_tileQueue.Count > _initialTiles + 2)
        {
            GameObject _oldTile = _tileQueue.Dequeue();
            Destroy(_oldTile);
        }


    }
}

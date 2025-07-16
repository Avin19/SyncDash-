using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Player;
using UnityEngine;

public class SyncManager : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private GhostController _ghost;

    [SerializeField] private float _delay = 0.15f;

    private Queue<PlayerState> _stateQueue = new Queue<PlayerState>();

    void Update()
    {
        _stateQueue.Enqueue(new PlayerState
        {
            position = _player.transform.position,
            jumped = _player._jump,
            timestamp = Time.time,
        });
        while (_stateQueue.Count > 0 && Time.time - _stateQueue.Peek().timestamp > _delay)
        {
            PlayerState _state = _stateQueue.Dequeue();
            _ghost.ReceiveState(_state);
        }
    }
}

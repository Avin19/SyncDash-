using System.Collections.Generic;
using UnityEngine;

public class SyncManager : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private GhostController _ghost;

    [SerializeField] private float _delay = 0.15f;

    private Queue<PlayerState> _stateQueue = new Queue<PlayerState>();

    void Update()
    {
        if (!GameManager.Instance.GetIsGameRunning()) return;
        _stateQueue.Enqueue(new PlayerState
        {
            position = _player.transform.position,
            jumped = _player.jump,
            timestamp = Time.time,
        });
        while (_stateQueue.Count > 0 && Time.time - _stateQueue.Peek().timestamp > _delay)
        {
            PlayerState _state = _stateQueue.Dequeue();
            _ghost.ReceiveState(_state);
        }
    }
}

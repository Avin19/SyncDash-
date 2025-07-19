using System;
using UnityEngine;


public class GhostController : MonoBehaviour
{
    [SerializeField] private float smoothTime = 0.1f;
    private Vector3 velocity;

    public void ReceiveState(PlayerState state)
    {
        transform.position = Vector3.SmoothDamp(transform.position, state.position, ref velocity, smoothTime);
    }
}

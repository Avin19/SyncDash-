using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed = 5f;

    void LateUpdate()
    {
        if (!_target) return;

        Vector3 _desiredPosition = _target.position + _offset;
        transform.position = Vector3.Lerp(transform.position, _desiredPosition, _speed * Time.deltaTime);

    }
}

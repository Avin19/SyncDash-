
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 7f;

    [SerializeField] private Rigidbody rb;

    public bool _jump = false;

    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0) && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);

            _jump = true;
        }
        else
        {
            _jump = false;
        }
    }

}
[System.Serializable]
public struct PlayerState
{
    public Vector3 position;
    public bool jumped;
    public float timestamp;
}
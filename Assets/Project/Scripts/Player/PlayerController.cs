
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private float fallMultiplier = 3f;
    [SerializeField] private float lowJumpMultiplier = 6f;
    private bool isGrounded = true;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private ParticleSystem particleSystem;

    public bool jump = false;

    void Update()
    {
        if (!GameManager.Instance.GetIsGameRunning()) return;
        transform.Translate(Vector3.forward * GameManager.Instance.GetGameSpeed() * Time.deltaTime);

        if (Input.GetMouseButtonDown(0) && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            jump = true;
            AudioManager.Instance.PlayOneShot(jumpClip);
        }
        else
        {
            jump = false;
        }

        Fall();
    }

    private void Fall()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1f) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetMouseButton(0))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1f) * Time.deltaTime;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Orb"))
        {
            particleSystem.Play();
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
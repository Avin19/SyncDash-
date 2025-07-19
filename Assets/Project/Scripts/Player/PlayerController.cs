
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float jumpForce = 7f;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private AudioClip jumpClip;

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
    }

}
[System.Serializable]
public struct PlayerState
{
    public Vector3 position;
    public bool jumped;
    public float timestamp;
}
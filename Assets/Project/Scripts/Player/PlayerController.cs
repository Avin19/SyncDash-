
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 7f;

    [SerializeField] private Rigidbody rb;

    public bool jump = false;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0) && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            jump = true;
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
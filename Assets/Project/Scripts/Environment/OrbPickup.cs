using UnityEngine;

public class OrbPickup : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    private float returnOffset = 5f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.AddOrb();
            AudioManager.Instance.PlayOneShot(audioClip);
            PoolManager.Instance.ReturnOrb(gameObject);
        }
    }
    void Update()
    {
        if (transform.position.z + returnOffset < GameManager.Instance.GetPlayerPosition().position.z)
        {
            PoolManager.Instance.ReturnOrb(gameObject);
        }
    }
}

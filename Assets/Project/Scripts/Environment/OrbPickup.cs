using UnityEngine;

public class OrbPickup : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.AddOrb();
            AudioManager.Instance.PlayOneShot(audioClip);

            Destroy(gameObject);
        }
    }
}

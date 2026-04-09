using UnityEngine;

namespace Team8{
public class MushroomPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerRandomScaler scaler = other.GetComponent<PlayerRandomScaler>();
        if (scaler != null)
        {
            scaler.ApplyRandomGrowth();
        }

        gameObject.SetActive(false);
        // 필요하면 Destroy(gameObject);
    }
}
}
using UnityEngine;

public class ExperiencePickup : MonoBehaviour
{
    [SerializeField] private int amount;
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.TryGetComponent<Player>(out var Player))
        {
            Player.AddExperience(amount);
            Destroy(gameObject);
        }
    }
}
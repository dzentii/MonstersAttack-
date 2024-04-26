using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float moveSpeed;

    private void Start() 
    {
        target = GameObject.FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        var direction = (target.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
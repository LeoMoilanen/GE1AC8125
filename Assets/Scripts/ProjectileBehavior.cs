using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    [SerializeField] private string projectileType;

    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            HealthSystemForDummies healthSystem = collision.gameObject.GetComponent<HealthSystemForDummies>();
            healthSystem.DecreaseCurrentHealthBy(damage);

        }    
        
        if (projectileType == "bullet")
        {
            Destroy(gameObject);
        }

        if (projectileType == "arrow")
        {
            Destroy(GetComponent<Rigidbody2D>());
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I made this script with the help of this tutorial: https://www.youtube.com/watch?v=XHrWtLZtzy8&ab_channel=KetraGames
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float rotationSpeed;

    private Rigidbody2D enemyRigidbody;
    public Transform player;
    private Vector2 targetDirection;

    private void Awake()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        player = go.transform;
    }

    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        targetDirection = player.transform.position - transform.position;
    }

    private void RotateTowardsTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, -Vector3.forward);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        enemyRigidbody.SetRotation(rotation);
    }

    private void SetVelocity()
    {
         enemyRigidbody.velocity = transform.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            HealthSystemForDummies healthSystem = collision.gameObject.GetComponent<HealthSystemForDummies>();
            healthSystem.PlayerDead();
        }

        if (collision.gameObject.tag == "Wall")
        {
            Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
        }
    }
}

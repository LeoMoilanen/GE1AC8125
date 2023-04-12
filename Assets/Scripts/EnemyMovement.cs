using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I made this script with the help of this tutorial: https://www.youtube.com/watch?v=XHrWtLZtzy8&ab_channel=KetraGames
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float speedValue;
    [SerializeField] private float rotationSpeed;
    private bool isStopped;

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
        if (!isStopped)
        {
            speedValue = speed;
        }
        else
        {
            speedValue = -5;
        }
        enemyRigidbody.velocity = transform.up * speedValue;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            isStopped = true;
            StartCoroutine(StopEffectTime());
        }

        if (collision.transform.CompareTag("Chrono bubble"))
        {
            speed *= 0.5f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Chrono bubble"))
        {
            speed *= 2;
        }
    }

    IEnumerator StopEffectTime()
    {
        yield return new WaitForSeconds(0.1f);
        isStopped = false;
    }
}

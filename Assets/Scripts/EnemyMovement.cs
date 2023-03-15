using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float rotationSpeed;

    private Rigidbody2D enemyRigidbody;
    public GameObject player;
    private Vector2 targetDirection;

    private void Awake()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        //_playerAwarenessController = GetComponent<PlayerAwarenessController>();
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
        /*if (targetDirection == Vector2.zero)
        {
            return;
        }*/

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, -Vector3.forward);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        enemyRigidbody.SetRotation(rotation);

        //Debug.Log(rotation.eulerAngles);
        //Debug.DrawLine(transform.position, transform.position + targetRotation * Vector3.up, Color.red);
    }

    private void SetVelocity()
    {
        /*if (targetDirection == Vector2.zero)
        {
            enemyRigidbody.velocity = Vector2.zero;
        }
        else*/
        
            enemyRigidbody.velocity = transform.up * speed;
        
    }
}

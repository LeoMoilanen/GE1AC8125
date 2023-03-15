using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] private string projectileType;

    private void OnCollisionEnter2D(Collision2D collision)
    {
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

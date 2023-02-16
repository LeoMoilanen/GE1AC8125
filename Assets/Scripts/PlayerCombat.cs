using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public GameObject arrowPrefab;

    public float bulletForce = 20f;
    public bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && canShoot)
        {
            Shoot();
            StartCoroutine(Firerate());
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(arrowPrefab, attackPoint.position, attackPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(attackPoint.up * bulletForce, ForceMode2D.Impulse);
        canShoot = false;
        
    }

    IEnumerator Firerate()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Finished a Coroutine at timestamp : " + Time.time);
        canShoot = true;
    }
}

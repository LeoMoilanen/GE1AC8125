using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform attackPoint;
    public GameObject arrowPrefab;
    public GameObject bulletPrefab;

    [SerializeField] private float bulletForce = 20f;
    [SerializeField] private float shootDelay = 0.3f;
    [SerializeField] private string currentWeapon = "Repeater crossbow";
    public bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            currentWeapon = "Repeater crossbow";
        }

        if (Input.GetKeyDown("2"))
        {
            currentWeapon = "Musket";
        }

        if (currentWeapon == "Repeater crossbow")
        {
            shootDelay = 0.3f;
            bulletForce = 20f;
        }

        if (currentWeapon == "Musket")
        {
            shootDelay = 2.0f;
            bulletForce = 60f;
        }

        if (Input.GetMouseButton(0) && canShoot && currentWeapon == "Repeater crossbow")
        {
            Shoot();
            StartCoroutine(Firerate());
        }

        if (Input.GetMouseButtonDown(0) && canShoot && currentWeapon == "Musket")
        {
            Shoot();
            StartCoroutine(Firerate());
        }

    }

    private void Shoot()
    {
        if (currentWeapon == "Repeater crossbow")
        {
            GameObject bullet = Instantiate(arrowPrefab, attackPoint.position, attackPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(attackPoint.up * bulletForce, ForceMode2D.Impulse);
            canShoot = false;
        }

        if (currentWeapon == "Musket")
        {
            GameObject bullet = Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(attackPoint.up * bulletForce, ForceMode2D.Impulse);
            canShoot = false;
        }

    }

    IEnumerator Firerate()
    {
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }
}

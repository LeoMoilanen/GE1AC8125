using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public GameObject arrowPrefab;
    public GameObject bulletPrefab;

    [SerializeField] private float bulletForce = 20f;
    [SerializeField] private float fireRate = 0.3f;
    [SerializeField] private string equippedWeapon = "Repeater crossbow";
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
            EquipRepeaterCrossbow();
        }

        if (Input.GetKeyDown("2"))
        {
            equippedWeapon = "Musket";
        }

        if (Input.GetMouseButton(0) && canShoot && equippedWeapon == "Repeater crossbow")
        {
            Shoot();
            StartCoroutine(RepeaterCrossbowFirerate());
        }

        if (Input.GetMouseButtonDown(0) && canShoot && equippedWeapon == "Musket")
        {
            Shoot();
            StartCoroutine(RepeaterCrossbowFirerate());
        }

    }

    private void EquipRepeaterCrossbow()
    {
        equippedWeapon = "Repeater crossbow";
        fireRate = 0.3f;
    }

    private void Shoot()
    {
        if (equippedWeapon == "Repeater crossbow")
        {
            GameObject bullet = Instantiate(arrowPrefab, attackPoint.position, attackPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(attackPoint.up * bulletForce, ForceMode2D.Impulse);
            canShoot = false;
        }

        if (equippedWeapon == "Musket")
        {
            GameObject bullet = Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(attackPoint.up * bulletForce, ForceMode2D.Impulse);
            canShoot = false;
        }

    }

    IEnumerator RepeaterCrossbowFirerate()
    {
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}

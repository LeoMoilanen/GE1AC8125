using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform attackPoint;
    public GameObject crossbowPrefab;
    public GameObject shotgunPrefab;

    private float bulletForce;
    private float coolDown;
    [SerializeField] private float crossbowCoolDown;
    [SerializeField] private float crosswbowBulletForce;
    [SerializeField] private float shotgunCoolDown;
    [SerializeField] private float shotgunBulletForce;
    [SerializeField] private string currentWeapon;

    private bool crossBowReady = true;
    private bool shotgunReady = true;

    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = "Crossbow";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            currentWeapon = "Crossbow";
        }

        if (Input.GetKeyDown("2"))
        {
            currentWeapon = "Shotgun";
        }

        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (currentWeapon == "Crossbow" && crossBowReady)
        {
            GameObject bullet = Instantiate(crossbowPrefab, attackPoint.position, attackPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(attackPoint.up * crosswbowBulletForce, ForceMode2D.Impulse);
            crossBowReady = false;
            StartCoroutine(CrossbowReload());
        }

        if (currentWeapon == "Shotgun" && shotgunReady)
        {
            GameObject bullet = Instantiate(shotgunPrefab, attackPoint.position, attackPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(attackPoint.up * shotgunBulletForce, ForceMode2D.Impulse);
            shotgunReady = false;
            StartCoroutine(ShotgunReload());
        }
    }

    IEnumerator CrossbowReload()
    {
        yield return new WaitForSeconds(crossbowCoolDown);
        crossBowReady = true;
    }

    IEnumerator ShotgunReload()
    {
        yield return new WaitForSeconds(shotgunCoolDown);
        shotgunReady = true;
    }
}

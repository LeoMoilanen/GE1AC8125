using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform attackPoint;
    public GameObject crossbowPrefab;
    public GameObject shotgunPrefab;
    public GameObject laserPrefab;
    public GameObject bubblePrefab;

    [SerializeField] private string currentWeapon;
    [SerializeField] private float crossbowCoolDown;
    [SerializeField] private float crosswbowBulletForce;
    [SerializeField] private float shotgunCoolDown;
    [SerializeField] private float shotgunBulletForce;
    [SerializeField] private float laserCoolDown;
    [SerializeField] private float laserBulletForce;
    [SerializeField] private float bubbleCoolDown;

    private bool crossBowReady = true;
    private bool shotgunReady = true;
    private bool laserReady = true;
    private bool bubbleReady = true;

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

        if (Input.GetKeyDown("3"))
        {
            currentWeapon = "Laser";
        }

        if (Input.GetKeyDown("4"))
        {
            currentWeapon = "Bubble";
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

        if (currentWeapon == "Laser" && laserReady)
        {
            GameObject bullet = Instantiate(laserPrefab, attackPoint.position, attackPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(attackPoint.up * laserBulletForce, ForceMode2D.Impulse);
            laserReady = false;
            StartCoroutine(LaserReload());
        }

        if (currentWeapon == "Bubble" && bubbleReady)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(bubblePrefab, new Vector3(cursorPos.x, cursorPos.y, -0.3f), Quaternion.identity);
            bubbleReady = false;
            StartCoroutine(BubbleReload());
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

    IEnumerator LaserReload()
    {
        yield return new WaitForSeconds(laserCoolDown);
        laserReady = true;
    }

    IEnumerator BubbleReload()
    {
        yield return new WaitForSeconds(bubbleCoolDown);
        bubbleReady = true;
    }
}

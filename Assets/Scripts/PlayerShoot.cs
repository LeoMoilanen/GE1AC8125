using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private GameObject crossbowPrefab;
    [SerializeField] private GameObject shotgunPrefab;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private GameObject bubblePrefab;

    [SerializeField] private Text textCrossbowCooldown;

    [SerializeField] private string currentWeapon;
    [SerializeField] private float crossbowCoolDown;
    [SerializeField] private float crosswbowBulletForce;
    [SerializeField] private float shotgunCoolDown;
    [SerializeField] private float shotgunBulletForce;
    [SerializeField] private float laserCoolDown;
    [SerializeField] private float laserBulletForce;
    [SerializeField] private float bubbleCoolDown;

    [SerializeField] private float crossbowCooldownTimer;

    private bool crossBowReady = true;
    private bool shotgunReady = true;
    private bool laserReady = true;
    private bool bubbleReady = true;

    // Start is called before the first frame update
    void Start()
    {
        textCrossbowCooldown.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ShootCrossBow();
        }

        if (Input.GetKeyDown("1"))
        {
            ShootShotgun();
        }

        if (Input.GetKeyDown("2"))
        {
            ShootLaser();
        }

        if (Input.GetKeyDown("3"))
        {
            ShootBubble();
        }

        if (!crossBowReady)
        {
            CrossbowReload();
        }
    }

    private void ShootCrossBow()
    {
        if (crossBowReady)
        {
            GameObject bullet = Instantiate(crossbowPrefab, attackPoint.position, attackPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(attackPoint.up * crosswbowBulletForce, ForceMode2D.Impulse);
            crossbowCooldownTimer = crossbowCoolDown;
            crossBowReady = false;
        }
    }

    private void ShootShotgun()
    {
        if (shotgunReady)
        {
            GameObject bullet = Instantiate(shotgunPrefab, attackPoint.position, attackPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(attackPoint.up * shotgunBulletForce, ForceMode2D.Impulse);
            shotgunReady = false;
            StartCoroutine(ShotgunReload());
        }
    }

    private void ShootLaser()
    {
        if (laserReady)
        {
            GameObject bullet = Instantiate(laserPrefab, attackPoint.position, attackPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(attackPoint.up * laserBulletForce, ForceMode2D.Impulse);
            laserReady = false;
            StartCoroutine(LaserReload());
        }
    }

    private void ShootBubble()
    {
        if (bubbleReady)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(bubblePrefab, new Vector3(cursorPos.x, cursorPos.y, -0.3f), Quaternion.identity);
            bubbleReady = false;
            StartCoroutine(BubbleReload());
        }
    }

    private void CrossbowReload()
    {
        Debug.Log("Crossbow is reloading");
        textCrossbowCooldown.gameObject.SetActive(true);
        crossbowCooldownTimer -= Time.deltaTime;
        
        if (crossbowCooldownTimer <= 0.0f)
        {
            crossBowReady = true;
            textCrossbowCooldown.gameObject.SetActive(false);
        }
        else
        {
            textCrossbowCooldown.text = crossbowCooldownTimer.ToString();
        }
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

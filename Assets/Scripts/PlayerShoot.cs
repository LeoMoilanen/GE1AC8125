using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// I made the shooting mechanics with the help of this tuotrial: https://www.youtube.com/watch?v=LNLVOjbrQj4&ab_channel=Brackeys
// I made the cooldown part with the help of this tutorial: https://www.youtube.com/watch?v=1fBKVWie8ew&ab_channel=DestinedToLearn
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private AudioSource boltSFX;
    [SerializeField] private AudioSource waveSFX;
    [SerializeField] private AudioSource laserSFX;
    [SerializeField] private AudioSource bubbleSFX;

    [SerializeField] private Transform attackPoint;
    [SerializeField] private GameObject crossbowPrefab;
    [SerializeField] private GameObject shotgunPrefab;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private GameObject bubblePrefab;

    [SerializeField] private Text textCrossbowCooldown;
    [SerializeField] private Text textShotgunCooldown;
    [SerializeField] private Text textLaserCooldown;
    [SerializeField] private Text textBubbleCooldown;

    [SerializeField] private string currentWeapon;
    [SerializeField] private float crossbowCoolDown;
    [SerializeField] private float crosswbowBulletForce;
    [SerializeField] private float shotgunCoolDown;
    [SerializeField] private float shotgunBulletForce;
    [SerializeField] private float laserCoolDown;
    [SerializeField] private float laserBulletForce;
    [SerializeField] private float bubbleCoolDown;

    private float crossbowCooldownTimer;
    private float shotgunCooldownTimer;
    private float laserCooldownTimer;
    private float bubbleCooldownTimer;

    private bool crossBowReady = true;
    private bool shotgunReady = true;
    private bool laserReady = true;
    private bool bubbleReady = true;

    // Start is called before the first frame update
    void Start()
    {
        textCrossbowCooldown.gameObject.SetActive(false);
        textShotgunCooldown.gameObject.SetActive(false);
        textLaserCooldown.gameObject.SetActive(false);
        textBubbleCooldown.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ShootCrossBow();
        }

        if (Input.GetKeyDown("e"))
        {
            ShootShotgun();
        }

        if (Input.GetKeyDown("q"))
        {
            ShootLaser();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ShootBubble();
        }

        if (!crossBowReady)
        {
            CrossbowReload();
        }

        if (!shotgunReady)
        {
            ShotgunReload();
        }

        if (!laserReady)
        {
            LaserReload();
        }

        if (!bubbleReady)
        {
            BubbleReload();
        }
    }

    private void ShootCrossBow()
    {
        if (crossBowReady)
        {
            boltSFX.Play();
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
            waveSFX.Play();
            GameObject bullet = Instantiate(shotgunPrefab, attackPoint.position, attackPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(attackPoint.up * shotgunBulletForce, ForceMode2D.Impulse);
            shotgunCooldownTimer = shotgunCoolDown;
            shotgunReady = false;
        }
    }

    private void ShootLaser()
    {
        if (laserReady)
        {
            laserSFX.Play();
            GameObject bullet = Instantiate(laserPrefab, attackPoint.position, attackPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(attackPoint.up * laserBulletForce, ForceMode2D.Impulse);
            laserCooldownTimer = laserCoolDown;
            laserReady = false;
        }
    }

    private void ShootBubble()
    {
        if (bubbleReady)
        {
            bubbleSFX.Play();
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(bubblePrefab, new Vector3(cursorPos.x, cursorPos.y, -0.3f), Quaternion.identity);
            bubbleCooldownTimer = bubbleCoolDown;
            bubbleReady = false;
        }
    }

    private void CrossbowReload()
    {
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

    private void ShotgunReload()
    {
        textShotgunCooldown.gameObject.SetActive(true);
        shotgunCooldownTimer -= Time.deltaTime;

        if (shotgunCooldownTimer <= 0.0f)
        {
            shotgunReady = true;
            textShotgunCooldown.gameObject.SetActive(false);
        }
        else
        {
            textShotgunCooldown.text = shotgunCooldownTimer.ToString();
        }
    }

    private void LaserReload()
    {
        textLaserCooldown.gameObject.SetActive(true);
        laserCooldownTimer -= Time.deltaTime;

        if (laserCooldownTimer <= 0.0f)
        {
            laserReady = true;
            textLaserCooldown.gameObject.SetActive(false);
        }
        else
        {
            textLaserCooldown.text = laserCooldownTimer.ToString();
        }
    }

    private void BubbleReload()
    {
        textBubbleCooldown.gameObject.SetActive(true);
        bubbleCooldownTimer -= Time.deltaTime;

        if (bubbleCooldownTimer <= 0.0f)
        {
            bubbleReady = true;
            textBubbleCooldown.gameObject.SetActive(false);
        }
        else
        {
            textBubbleCooldown.text = bubbleCooldownTimer.ToString();
        }
    }
}

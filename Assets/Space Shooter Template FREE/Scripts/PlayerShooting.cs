using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//guns objects in 'Player's' hierarchy
[System.Serializable]
public class Guns
{
    public GameObject rightGun, leftGun, centralGun;
    [HideInInspector] public ParticleSystem leftGunVFX, rightGunVFX, centralGunVFX;
}

public class PlayerShooting : MonoBehaviour
{
    [Tooltip("shooting frequency. the higher the more frequent")]
    public float fireRate = 10f;

    [Tooltip("projectile prefab")]
    public GameObject projectileObject;

    // time for a new shot
    [HideInInspector] public float nextFire = 0f;

    [Tooltip("current weapon power")]
    [Range(1, 4)]
    public int weaponPower = 1;

    public Guns guns;

    public bool shootingIsActive = true;
    [HideInInspector] public int maxweaponPower = 4;

    public static PlayerShooting instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        // receiving shooting visual effects components (nếu có)
        if (guns.leftGun != null) guns.leftGunVFX = guns.leftGun.GetComponent<ParticleSystem>();
        if (guns.rightGun != null) guns.rightGunVFX = guns.rightGun.GetComponent<ParticleSystem>();
        if (guns.centralGun != null) guns.centralGunVFX = guns.centralGun.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (!shootingIsActive) return;
        if (projectileObject == null) return;

        // Click chuột trái => bắn 1 lần ngay lập tức
        if (Input.GetMouseButtonDown(0))
        {
            MakeAShot();
            nextFire = Time.time + 1f / fireRate;
        }

        // Giữ chuột trái => bắn liên tục theo fireRate
        if (Input.GetMouseButton(0) && Time.time >= nextFire)
        {
            MakeAShot();
            nextFire = Time.time + 1f / fireRate;
        }
    }

    // method for a shot
    void MakeAShot()
    {
        switch (weaponPower)
        {
            case 1:
                CreateLazerShot(projectileObject, guns.centralGun.transform.position, Vector3.zero);
                if (guns.centralGunVFX != null) guns.centralGunVFX.Play();
                break;

            case 2:
                CreateLazerShot(projectileObject, guns.rightGun.transform.position, Vector3.zero);
                if (guns.rightGunVFX != null) guns.rightGunVFX.Play();

                CreateLazerShot(projectileObject, guns.leftGun.transform.position, Vector3.zero);
                if (guns.leftGunVFX != null) guns.leftGunVFX.Play();
                break;

            case 3:
                CreateLazerShot(projectileObject, guns.centralGun.transform.position, Vector3.zero);
                if (guns.centralGunVFX != null) guns.centralGunVFX.Play();

                CreateLazerShot(projectileObject, guns.rightGun.transform.position, new Vector3(0, 0, -5));
                if (guns.rightGunVFX != null) guns.rightGunVFX.Play();

                CreateLazerShot(projectileObject, guns.leftGun.transform.position, new Vector3(0, 0, 5));
                if (guns.leftGunVFX != null) guns.leftGunVFX.Play();
                break;

            case 4:
                CreateLazerShot(projectileObject, guns.centralGun.transform.position, Vector3.zero);
                if (guns.centralGunVFX != null) guns.centralGunVFX.Play();

                CreateLazerShot(projectileObject, guns.rightGun.transform.position, new Vector3(0, 0, -5));
                if (guns.rightGunVFX != null) guns.rightGunVFX.Play();

                CreateLazerShot(projectileObject, guns.leftGun.transform.position, new Vector3(0, 0, 5));
                if (guns.leftGunVFX != null) guns.leftGunVFX.Play();

                CreateLazerShot(projectileObject, guns.leftGun.transform.position, new Vector3(0, 0, 15));
                CreateLazerShot(projectileObject, guns.rightGun.transform.position, new Vector3(0, 0, -15));
                break;
        }
    }

    void CreateLazerShot(GameObject lazer, Vector3 pos, Vector3 rot)
    {
        Instantiate(lazer, pos, Quaternion.Euler(rot));
    }
}

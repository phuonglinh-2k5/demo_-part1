using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
=======

>>>>>>> 6cfbf4a239524dbe365ec44c9510a4081ca346d7
//guns objects in 'Player's' hierarchy
[System.Serializable]
public class Guns
{
    public GameObject rightGun, leftGun, centralGun;
<<<<<<< HEAD
    [HideInInspector] public ParticleSystem leftGunVFX, rightGunVFX, centralGunVFX;
}

public class PlayerShooting : MonoBehaviour
{
    [Tooltip("shooting frequency. the higher the more frequent")]
    public float fireRate = 10f;
=======
    [HideInInspector] public ParticleSystem leftGunVFX, rightGunVFX, centralGunVFX; 
}

public class PlayerShooting : MonoBehaviour {

    [Tooltip("shooting frequency. the higher the more frequent")]
    public float fireRate;
>>>>>>> 6cfbf4a239524dbe365ec44c9510a4081ca346d7

    [Tooltip("projectile prefab")]
    public GameObject projectileObject;

<<<<<<< HEAD
    // time for a new shot
    [HideInInspector] public float nextFire = 0f;

    [Tooltip("current weapon power")]
    [Range(1, 4)]
    public int weaponPower = 1;

    public Guns guns;

    public bool shootingIsActive = true;
    [HideInInspector] public int maxweaponPower = 4;

=======
    //time for a new shot
    [HideInInspector] public float nextFire;


    [Tooltip("current weapon power")]
    [Range(1, 4)]       //change it if you wish
    public int weaponPower = 1; 

    public Guns guns;
    bool shootingIsActive = true; 
    [HideInInspector] public int maxweaponPower = 4; 
>>>>>>> 6cfbf4a239524dbe365ec44c9510a4081ca346d7
    public static PlayerShooting instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
<<<<<<< HEAD
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        // receiving shooting visual effects components (nếu có)
        if (guns.leftGun != null) guns.leftGunVFX = guns.leftGun.GetComponent<ParticleSystem>();
        if (guns.rightGun != null) guns.rightGunVFX = guns.rightGun.GetComponent<ParticleSystem>();
        if (guns.centralGun != null) guns.centralGunVFX = guns.centralGun.GetComponent<ParticleSystem>();
=======
    }
    private void Start()
    {
        //receiving shooting visual effects components
        guns.leftGunVFX = guns.leftGun.GetComponent<ParticleSystem>();
        guns.rightGunVFX = guns.rightGun.GetComponent<ParticleSystem>();
        guns.centralGunVFX = guns.centralGun.GetComponent<ParticleSystem>();
>>>>>>> 6cfbf4a239524dbe365ec44c9510a4081ca346d7
    }

    private void Update()
    {
<<<<<<< HEAD
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

=======
        if (shootingIsActive)
        {
            if (Time.time > nextFire)
            {
                MakeAShot();                                                         
                nextFire = Time.time + 1 / fireRate;
            }
        }
    }

    //method for a shot
    void MakeAShot() 
    {
        switch (weaponPower) // according to weapon power 'pooling' the defined anount of projectiles, on the defined position, in the defined rotation
        {
            case 1:
                CreateLazerShot(projectileObject, guns.centralGun.transform.position, Vector3.zero);
                guns.centralGunVFX.Play();
                break;
            case 2:
                CreateLazerShot(projectileObject, guns.rightGun.transform.position, Vector3.zero);
                guns.leftGunVFX.Play();
                CreateLazerShot(projectileObject, guns.leftGun.transform.position, Vector3.zero);
                guns.rightGunVFX.Play();
                break;
            case 3:
                CreateLazerShot(projectileObject, guns.centralGun.transform.position, Vector3.zero);
                CreateLazerShot(projectileObject, guns.rightGun.transform.position, new Vector3(0, 0, -5));
                guns.leftGunVFX.Play();
                CreateLazerShot(projectileObject, guns.leftGun.transform.position, new Vector3(0, 0, 5));
                guns.rightGunVFX.Play();
                break;
            case 4:
                CreateLazerShot(projectileObject, guns.centralGun.transform.position, Vector3.zero);
                CreateLazerShot(projectileObject, guns.rightGun.transform.position, new Vector3(0, 0, -5));
                guns.leftGunVFX.Play();
                CreateLazerShot(projectileObject, guns.leftGun.transform.position, new Vector3(0, 0, 5));
                guns.rightGunVFX.Play();
>>>>>>> 6cfbf4a239524dbe365ec44c9510a4081ca346d7
                CreateLazerShot(projectileObject, guns.leftGun.transform.position, new Vector3(0, 0, 15));
                CreateLazerShot(projectileObject, guns.rightGun.transform.position, new Vector3(0, 0, -15));
                break;
        }
    }

<<<<<<< HEAD
    void CreateLazerShot(GameObject lazer, Vector3 pos, Vector3 rot)
=======
    void CreateLazerShot(GameObject lazer, Vector3 pos, Vector3 rot) //translating 'pooled' lazer shot to the defined position in the defined rotation
>>>>>>> 6cfbf4a239524dbe365ec44c9510a4081ca346d7
    {
        Instantiate(lazer, pos, Quaternion.Euler(rot));
    }
}

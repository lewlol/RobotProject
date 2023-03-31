using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Weapon weaponData; //Scriptable Object Holding all the Weapon's Data

    public GameObject bullet; //Bullet Prefab

    bool canShoot = true;
    bool canRemoveHeat = true;
    float heat;

    PlayerBattery pb;

    private void Start()
    {
        pb = GetComponent<PlayerBattery>();
    }
    private void Update()
    {
        //Detect Whether the Gun is Automatic or Not
        if (weaponData.isAuto)//is True
        {
            if (Input.GetButton("Fire1"))
            {
                Shoot();
            }
        }
        if (!weaponData.isAuto)//is False
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }

        //Take Away Heat
        if(heat > 0 && canRemoveHeat)
        {
            heat -= Time.deltaTime;
        }
    }

    //Shooting Function
    public void Shoot()
    {
        //Check the Player can shoot
        if (canShoot)
        {
            GameObject bul = Instantiate(bullet, transform.position, Quaternion.identity);
            bul.GetComponent<Rigidbody>().AddForce(transform.forward * weaponData.bulletSpeed, ForceMode.Impulse);
            Destroy(bul, weaponData.bulletLifetime);

            //Copy Weapon Data to Bullet
            bul.GetComponent<BulletScript>().weaponData = weaponData;

            //Add Heat to Weapon and Remove Battery Cost from Battery
            heat += weaponData.batteryCost;
            pb.RemoveBattery(weaponData.batteryCost);

            //Check Heat Count
            if(heat >= weaponData.maxHeat)
            {
                StartCoroutine(Overheated(weaponData.cooldownTime));
                return; //Return to Stop the Shoot Cooldown Coroutine which breaks the Overheated one
            }

            StartCoroutine(ShootCooldown(weaponData.attackSpeed));
        }
    }

    //Shooting Cooldown
    public IEnumerator ShootCooldown(float delay)
    {
        canRemoveHeat = false;
        canShoot = false;
        yield return new WaitForSeconds(delay);
        canRemoveHeat = true;
        canShoot = true;
    }

    //Overheat Cooldown
    public IEnumerator Overheated(float cooldownTime)
    {
        canShoot = false;
        yield return new WaitForSeconds(cooldownTime);
        canShoot = true;
        heat = 0;
    }
}

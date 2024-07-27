using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShotingComponent : MonoBehaviour
{

    [SerializeField] GameObject bulletPrefab;

    [SerializeField] private float velocity;
    [SerializeField] private float damage;

    [SerializeField] private bool isPlayer;


    [SerializeField] private float fireRate;
    private float elapsedTime;



    [SerializeField] private float enemyMinFireRate;   
    [SerializeField] private float enemyMaxFireRate;   

    private float enemyfireRate;
    private float enemyElapsedTime;

    private bool shooting = false;

    [SerializeField] AudioClip shootClip;

    [SerializeField] float audioVolume;


    private void Start()
    {
        if(!isPlayer)
        {
            enemyfireRate = Random.Range(enemyMinFireRate, enemyMaxFireRate);    
        }
    }
    private void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        SFXManager.instance.playSFXClip(shootClip, transform, 1f + audioVolume);

        var bulletCmp = bullet.GetComponent<BulletComponent>();

        bulletCmp.setDamage(damage);
        bulletCmp.setDir(isPlayer ? Vector2.up : Vector2.down);
        bulletCmp.setOwnerPlayer(isPlayer);
        bulletCmp.setVelocity(velocity);


        if (!isPlayer)
        {
            enemyfireRate = Random.Range(enemyMinFireRate, enemyMaxFireRate);
        }

    }

    private void Update()
    {
        if (isPlayer)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime > fireRate && shooting)
            {
                elapsedTime = 0;
                ShootBullet();
            }
        }
        else
        {
            enemyElapsedTime += Time.deltaTime;

            if (enemyElapsedTime > enemyfireRate )
            {
                enemyElapsedTime = 0;
                ShootBullet();
            }
        }
    }
    public void startShooting()
    {
        shooting = true;    
    }
    public void stopShooting()
    {
        shooting = false;
    }
   
}

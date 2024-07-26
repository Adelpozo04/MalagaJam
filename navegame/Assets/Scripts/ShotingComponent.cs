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
    [SerializeField] private float elapsedTime;

    private bool shooting = false;
    private void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        var bulletCmp = bullet.GetComponent<BulletComponent>();

        bulletCmp.setDamage(damage);
        bulletCmp.setDir(isPlayer ? Vector2.up : Vector2.down);
        bulletCmp.setOwnerPlayer(isPlayer);
        bulletCmp.setVelocity(velocity);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        
        if(elapsedTime > fireRate && shooting)
        {
            elapsedTime = 0;
            ShootBullet();
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

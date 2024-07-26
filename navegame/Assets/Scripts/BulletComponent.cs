using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    private float velocity;
    private Vector2 direction;
    private float damage;

    private bool ownerPlayer;

    private Rigidbody2D myRigidbody2D;

    public void setVelocity(float newVelocity)
    {
        velocity = newVelocity;
    }

    public void setDir(Vector2 newDir)
    {
        direction = newDir.normalized;
    }

    public void setDamage(float newDamage) 
    {
        damage = newDamage; 
    }

    public void setOwnerPlayer(bool newOwnerPlayer)
    {
        ownerPlayer = newOwnerPlayer; 
    }
    public bool getOwnerPlayer () { return ownerPlayer; }   

    private void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();    
        myRigidbody2D.velocity = direction*velocity;    
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null)
        {
            var bulletCmp = collision.gameObject.GetComponent<BulletComponent>();

            //si chocamos con otra bala de distinto dueño
            if (bulletCmp != null && bulletCmp.getOwnerPlayer()!= ownerPlayer)
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
                return;
            }    

            var lifeCmp = collision.gameObject.GetComponent<LifeComponent>();   

            if(lifeCmp != null)
            {



            }


        }

    }

}

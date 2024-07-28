using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    [SerializeField] private float timeAlive = 10f;
    private float elapsedTime = 0;

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

        elapsedTime = 0;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;   

        if (elapsedTime > timeAlive)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            var bulletCmp = collision.gameObject.GetComponent<BulletComponent>();

            //si chocamos con otra bala de distinto due�o
            if (bulletCmp != null && bulletCmp.getOwnerPlayer() != ownerPlayer)
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
                return;
            }

            var lifeCmp = collision.gameObject.GetComponent<LifeComponent>();

            //si chocamos contra un objeto de otro grupo(player/enemigo)

            if (lifeCmp != null && ownerPlayer)
            {
                lifeCmp.reciveDamage(damage);
                Destroy(gameObject);
            }

            var shipCmp = collision.gameObject.GetComponent<ShipComponent>();
            if(shipCmp != null && !ownerPlayer)
            {
                shipCmp.GotHit();
                Destroy(gameObject);
            }

            var shpmng = collision.GetComponent<ShipManager>();
            if(shpmng != null && !ownerPlayer)
            {
                //shpmng.sufferDamage(30);
            }
        }
    }


}

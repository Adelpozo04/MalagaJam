using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocarNave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
          
            var shipCmp = collision.gameObject.GetComponent<ShipComponent>();
            if (shipCmp != null )
            {
                shipCmp.GotHit();
                Destroy(gameObject);
            }

            var shpmng = collision.GetComponent<ShipManager>();
            if (shpmng != null )
            {
                shpmng.sufferDamage(30);
            }
        }
    }
}

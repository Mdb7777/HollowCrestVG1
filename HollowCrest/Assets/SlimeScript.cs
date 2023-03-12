using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            FindObjectOfType<PlayerMovement>().TakeDamage();
        }
        if (collider.tag == "Weapon")
        {
            Destroy(gameObject);
        }
        
    }
}

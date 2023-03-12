using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        
            FindObjectOfType<PlayerMovement>().TakeDamage();
            
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaScript : MonoBehaviour
{
    private int ManaRef;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            ManaRef = FindObjectOfType<PlayerMovement>().GetMana();

            if (ManaRef < 100)
            {
                FindObjectOfType<PlayerMovement>().CollectMana();
                Destroy(gameObject);
            }
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionScript : MonoBehaviour
{
    private int HealthRef;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider)
    {
        HealthRef = FindObjectOfType<PlayerMovement>().GetHealth();

        if (HealthRef < 100)
        {
            FindObjectOfType<PlayerMovement>().CollectHealth();
            Destroy(gameObject);
        }
    }

}

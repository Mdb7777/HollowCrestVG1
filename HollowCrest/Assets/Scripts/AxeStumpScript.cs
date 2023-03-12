using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeStumpScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
  
        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.tag == "Player")
            {
                spriteRenderer.sprite = newSprite;
                FindObjectOfType<PlayerMovement>().ObtainAxe();
            }
        }
   
}

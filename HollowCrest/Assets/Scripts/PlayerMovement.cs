using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D playerbody;
    int jumpAmount = 16;
 

    // Start is called before the first frame update
    void Start()
    {
        playerbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        float dirX = Input.GetAxisRaw("Horizontal");
        
        playerbody.velocity = new Vector2(dirX * 7f, playerbody.velocity.y);

        
        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 7f);
        }
        
    }
    
}

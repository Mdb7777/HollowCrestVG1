using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D playerbody;
    int jumpAmount = 16;
    float inputHorizontal;
    float inputVertical;
    public float speed ;
    public float jumpPower;

 

    // Start is called before the first frame update
    void Start()
    {
        playerbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        
        if (inputHorizontal != 0)
        {
            playerbody.AddForce(new Vector2(inputHorizontal * speed, 0f));
        }
        
        playerbody.velocity = new Vector2(dirX * speed, playerbody.velocity.y);

        if (dirX > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        if (dirX < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
      


        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpPower);
        }
        
    }
    
}

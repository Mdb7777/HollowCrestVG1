using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float Speed = 4;
    public Vector3 LaunchOffset;
    public bool Thrown;
    public PlayerMovement Player;
    // Start is called before the first frame update
    void Start()
    {
       Player = FindObjectOfType<PlayerMovement>();
       if (Thrown)
        {
            if (Player.Right == true)
            {
                var direction = transform.right + Vector3.up;
                GetComponent<Rigidbody2D>().AddForce(direction * Speed, ForceMode2D.Impulse);
                gameObject.transform.localScale = new Vector3(.6f, .6f, .6f);
            }
            if (Player.Right == false)
            {
                var direction = -transform.right + Vector3.up;
                GetComponent<Rigidbody2D>().AddForce(direction * Speed, ForceMode2D.Impulse);
                gameObject.transform.localScale = new Vector3(-.6f, .6f, .6f);
            }
        }
        transform.Translate(LaunchOffset);
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Thrown)
        {
            
            
                transform.position += transform.right * Speed * Time.deltaTime;
            
            
        }
    }
    
}

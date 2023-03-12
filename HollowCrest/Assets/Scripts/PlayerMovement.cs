using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    Rigidbody2D playerbody;
    int jumpAmount = 0;
    float inputHorizontal;
    float inputVertical;
    public float speed ;
    public float jumpPower;
    public ProjectileBehaviour LaunchProjectilePrefab;
    public Transform RightLaunchOffset;
    public Transform LeftLaunchOffset;
    public bool Right;
    private bool doubleJump;
    public int Mana;
    public int Health;
    public bool AxeObtained;





    // Start is called before the first frame update
    void Start()
    {
        playerbody = GetComponent<Rigidbody2D>();
        Mana = 100;
        Health = 100;
        AxeObtained = false;
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
            gameObject.transform.localScale = new Vector3(.6f, .6f, .6f);
            Right = true;
        }
        if (dirX < 0)
        {
            gameObject.transform.localScale = new Vector3(-0.6f, 0.6f, 0.6f);
            Right = false;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (AxeObtained == true)
            {
                if (Mana > 0)
                {
                    if (Right == true)
                    {
                        Instantiate(LaunchProjectilePrefab, RightLaunchOffset.position, transform.rotation);
                        Mana = Mana - 10;
                    }
                    if (Right == false)
                    {
                        Instantiate(LaunchProjectilePrefab, LeftLaunchOffset.position, transform.rotation);
                        Mana = Mana - 10;
                    }
                    Debug.Log(Mana);
                }
            }
        }


        if (Input.GetButtonDown("Jump"))
        {
            if (jumpAmount < 2)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpPower);
                jumpAmount = jumpAmount + 1;
            }
            
        }
        

        

        
    }
    public int GetMana()
    {
        return Mana;
    }
    public int GetHealth()
    {
        return Health;
    }
    public void CollectMana()
    {
        if (Mana < 100)
        {
            Mana = 100;
        }
    }
    public void CollectHealth()
    {
        if (Health < 100)
        {
            Health = 100;
        }
    }
    public void TakeDamage()
    {
        Health -= 10;
        Debug.Log(Health);
    }
    public void ObtainAxe()
    {
        AxeObtained = true;
    }
    
}

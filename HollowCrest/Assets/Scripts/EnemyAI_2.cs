using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState2
{
    Wander,
    Follow,
    Die,
};

public class EnemyAI_2 : MonoBehaviour
{
    GameObject player;
    public EnemyState2 currState = EnemyState2.Wander;
    public Transform target;
    Rigidbody2D myRigidbody;

    public float range = 2f;
    public float moveSpeed = 2f;
    public float moveSpeedV = 0f;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {

        switch (currState)
        {
            case (EnemyState2.Wander):
                Wander();
                break;
            case (EnemyState2.Follow):
                Follow();
                break;
            case (EnemyState2.Die):
                // Die();
                break;
        }

        if (IsPlayerInRange(range) && currState != EnemyState2.Die)
        {
            currState = EnemyState2.Follow;
        }
        else if (!IsPlayerInRange(range) && currState != EnemyState2.Die)
        {
            currState = EnemyState2.Wander;
        }
    }

    private bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= range;
    }

    bool isFacingRight()
    {
        return transform.localScale.x > 0;
    }
    bool isFacingLeft()
    {
        return transform.localScale.x < 0;
    }

    void Wander()
    {
        {
            if (isFacingRight())
            {
                myRigidbody.velocity = new Vector2(moveSpeed, 0f);
            }
            else
            {
                myRigidbody.velocity = new Vector2(-moveSpeed, 0f);
            }
        }

    }

    void OnTriggerExit2D(Collider2D collision) //this is to flip the sprite when it reaches the end of its path - a box 2d collider trigger
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), 1f);

    }

    void Follow()
    {
        if (isFacingRight())
        {
            myRigidbody.velocity = new Vector2(-moveSpeed, 0f);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), moveSpeed * Time.deltaTime);

        }
        
    }
}

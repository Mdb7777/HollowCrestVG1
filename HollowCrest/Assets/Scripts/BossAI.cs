using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    Stand, 
    Follow,
    Die,
    Attack,
    RainAttack,
};

public class BossAI : MonoBehaviour
{
    public GameObject player;
    public BossState currState = BossState.Follow;
    public Transform target;
    Rigidbody2D myRigidbody;

    public float range = 10f;
    public float attackRange = 1f;
    public float moveSpeed = 2f;

    public int health;
    public int damage;
    //barrier variable;

    public bool flip;
    Vector3 scale;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 scale = transform.localScale;

        switch (currState)
        {
            case (BossState.Follow):
                Follow();
                break;
            case (BossState.Die):
                // Die();
                break;
            case (BossState.Attack):
                Attack();
                break;
            case (BossState.RainAttack):
                RainAttack();
                break;
        }

        if (IsPlayerInRange(range) && currState != BossState.Die)
        {
            currState = BossState.Follow;
        }
        if (IsPlayerInRange(attackRange) && currState != BossState.Die)
        {
            currState = BossState.Attack;
        }

        transform.localScale = scale;
    }

    private bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= range;
    }

    bool isFacingRight()
    {
        return transform.localScale.x > 0;
    }

    void OnTriggerExit2D(Collider2D collision) //this is to flip the sprite when it reaches the end of its path - a box 2d collider trigger
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), 1f);

    }

    void Follow()
    {
        /*if (isFacingRight())
        {
            myRigidbody.velocity = new Vector2(-moveSpeed, 0f);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), moveSpeed * Time.deltaTime);

        }*/
        if(player.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
            transform.Translate(x: moveSpeed * Time.deltaTime, y: 0, z: 0);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
            transform.Translate(x:moveSpeed * Time.deltaTime * -1, y: 0, z: 0);
        }
    }

    void Die()
    {
        
    }

    void Attack()
    {

    }

    void RainAttack()
    {

    }
}

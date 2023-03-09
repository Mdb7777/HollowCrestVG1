using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public float Speed = 4;
    public bool Thrown;
    public Vector3 LaunchOffset;
    // Start is called before the first frame update
    void Start()
    {
        if (Thrown)
        {
            var direction = transform.right + Vector3.up;
            GetComponent<Rigidbody2D>().AddForce(direction * Speed, ForceMode2D.Impulse);
        }
        transform.Translate(LaunchOffset);
        Destroy(gameObject, 5);
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Thrown)
        {
            transform.position += -transform.right * Speed * Time.deltaTime;
        }
    }
}

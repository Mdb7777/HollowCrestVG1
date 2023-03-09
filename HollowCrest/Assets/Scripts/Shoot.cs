using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            Destroy(bullet, 1.0f);
            
        }
        if (Input.GetButtonDown("Fire2"))
        {
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            Destroy(bullet, 0.2f);
        }
    }

    
}
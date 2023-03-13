using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingScript : MonoBehaviour
{
    public PlayerMovement Player;
    // Start is called before the first frame update
  
    
    void Start()
    {
        Player = FindObjectOfType<PlayerMovement>();
       
            if (Player.Right == true)
            {
                
                gameObject.transform.localScale = new Vector3(.5f, .5f, .5f);
            }
            if (Player.Right == false)
            {
                
                gameObject.transform.localScale = new Vector3(-.5f, .5f, .5f);
            }
        StartCoroutine(waiter());
    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(.2f);
        Destroy(gameObject);
    }
}

    // Update is called once per frame
    
        
 


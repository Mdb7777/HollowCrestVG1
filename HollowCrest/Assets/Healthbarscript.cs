using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Healthbarscript : MonoBehaviour
{
    private const float MAX_HEALTH = 100f;
    
    public float health;

    private Image healthBar;

    public PlayerMovement Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<PlayerMovement>();
        healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        health = Player.GetHealth();
        
        healthBar.fillAmount = health / MAX_HEALTH;
    }
}

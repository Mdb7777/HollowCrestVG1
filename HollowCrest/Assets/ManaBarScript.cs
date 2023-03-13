using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManaBarScript : MonoBehaviour
{
    private const float MAX_Mana = 100f;

    public float mana;

    private Image manaBar;

    public PlayerMovement Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<PlayerMovement>();
        manaBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        mana = Player.GetMana();

        manaBar.fillAmount = mana / MAX_Mana;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour
{
    public Text playerHP;
    private float playerCurrentHealth;
    private float playerMaximumHealth;

    void Update(){
        playerCurrentHealth = GameObject.Find("Player").GetComponent<HealthSystem>().health;
        playerMaximumHealth = GameObject.Find("Player").GetComponent<HealthSystem>().maxHealth;
        if (playerCurrentHealth > 0)
            playerHP.text = "Health: " + playerCurrentHealth.ToString() + "/" + playerMaximumHealth.ToString();
        else
            playerHP.text = "Death :(";
    }  
}

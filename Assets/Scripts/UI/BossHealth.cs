using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public Text bossHP;
    private float bossCurrentHealth;
    private float bossMaximumHealth;

    void Update()
    {
        if (GameObject.Find("EnemyBoss") != null){
            bossCurrentHealth = GameObject.Find("EnemyBoss").GetComponent<HealthSystem>().health;
            bossMaximumHealth = GameObject.Find("EnemyBoss").GetComponent<HealthSystem>().maxHealth;
            bossHP.text = "Health: " + bossCurrentHealth.ToString() + "/" + bossMaximumHealth.ToString();
        }
        else
            bossHP.text = "GG";
    }
}

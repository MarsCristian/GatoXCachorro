using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float health, maxHealth = 3f;

    public GameEvent playerHurt;
    public GameEvent enemyHurt;
    public GameEvent enemyDeath;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        // Damage event
        if (this.transform.tag == "Enemies")
        {
            enemyHurt.Raise();
        } else
        {
            playerHurt.Raise();
        }

        if (health <= 0)
        {
            // Death event
            if (this.transform.tag == "Enemies")
            {
                enemyDeath.Raise();
                if (gameObject.transform.GetChild(0).childCount > 0)
                    gameObject.transform.GetChild(0).GetChild(0).parent = null;
                Destroy(gameObject);
            }
            else
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(0);
        }
    }   
}
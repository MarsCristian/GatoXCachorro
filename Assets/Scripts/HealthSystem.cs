using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float health, maxHealth = 3f;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
            if (this.transform.tag == "Enemies"){
                if (gameObject.transform.GetChild(0).childCount > 0)
                    gameObject.transform.GetChild(0).GetChild(0).parent = null;
                Destroy(gameObject);
            }
            else
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(0);
    }   
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    public float punchDelay = 1f;
    private float punchTimer = 0f;

    public LayerMask enemies;
    public float attackRange;
    public GameEvent knifeHit;
    public GameEvent knifeSwish;

    void Update()
    {
        if(GetComponent<WeaponManager>().maxAmmoMan == 0 && Input.GetMouseButton(0) && punchTimer <= 0f){
            bool hit_enemy = false;
            Collider2D[] col = Physics2D.OverlapCircleAll(this.gameObject.transform.GetChild(0).position, attackRange, enemies);
            for (int i = 0; i < col.Length; i++){
                col[0].gameObject.TryGetComponent<HealthSystem>(out HealthSystem enemyComponent);
                if (enemyComponent != null)
                {
                    enemyComponent.TakeDamage(5);
                    hit_enemy = true;
                }
            }
            // Sounds
            if (hit_enemy)
            {
                knifeHit.Raise();
            } else
            {
                knifeSwish.Raise();
            }

            punchTimer = punchDelay;
        }
        else
            punchTimer -= Time.deltaTime;
        if(punchTimer >= 0.2f)
            this.GetComponentInChildren<SpriteRenderer>().enabled = true;
        else
            this.GetComponentInChildren<SpriteRenderer>().enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveEnemy : MonoBehaviour
{
    public float bulletSpeed;
    public LayerMask walls;

    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * bulletSpeed);

        Destroy(gameObject, 3f);

        Collider2D[] col = Physics2D.OverlapCircleAll(this.gameObject.transform.position, this.GetComponent<CircleCollider2D>().radius, walls);
        if (col.Length > 0){
            Destroy(gameObject);
            col[0].gameObject.TryGetComponent<HealthSystem>(out HealthSystem playerComponent);
            if (playerComponent != null)
                playerComponent.TakeDamage(1);
        }
    }

    /*public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.TryGetComponent<HealthSystem>(out HealthSystem enemyComponent);
            enemyComponent.TakeDamage(1);
            Destroy(gameObject);
        }
    }*/
}

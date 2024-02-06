using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float bulletSpeed;
    public LayerMask walls;

    public AudioClip audioBody;
    public AudioClip audioWall;
    public AudioSource audioSource;

    private bool already_hit = false;

    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * bulletSpeed);

        Destroy(gameObject, 3f);
        if (!already_hit)
        {
            Collider2D[] col = Physics2D.OverlapCircleAll(this.gameObject.transform.position, this.GetComponent<CircleCollider2D>().radius, walls);
            if (col.Length > 0)
            {
                bulletSpeed = 0f;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                col[0].gameObject.TryGetComponent<HealthSystem>(out HealthSystem enemyComponent);
                if (enemyComponent != null)
                {
                    enemyComponent.TakeDamage(1);
                    audioSource.PlayOneShot(audioBody);
                }
                else
                {
                    audioSource.PlayOneShot(audioWall);
                }
                Destroy(gameObject, 2f);
                already_hit = true;
            }
        }
    }

    /*public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {
            Destroy(gameObject);
            collision.gameObject.TryGetComponent<HealthSystem>(out HealthSystem enemyComponent);
            enemyComponent.TakeDamage(1);
        }
    }*/
}

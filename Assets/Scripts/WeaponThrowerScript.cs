using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponThrowerScript : MonoBehaviour
{
    public float weaponThrowSpeed;
    public float weaponThrowRotation;
    private Transform weaponHolding;
    public LayerMask walls;

    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * weaponThrowSpeed);
        weaponHolding = this.gameObject.transform.GetChild(0);
        weaponHolding.Rotate(0, 0, weaponThrowRotation * Time.deltaTime);

        Collider2D[] col = Physics2D.OverlapCircleAll(this.gameObject.transform.position, this.GetComponent<CircleCollider2D>().radius, walls);
        if (col.Length > 0){
            if (col[0].gameObject.transform.tag == "Obstacles"){
            weaponHolding.parent = null;
            Destroy(gameObject);
            }
            /*else {
                col[0].gameObject.TryGetComponent<HealthSystem>(out HealthSystem enemyComponent);
                enemyComponent.TakeDamage(5);
            }*/
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {
            collision.gameObject.TryGetComponent<HealthSystem>(out HealthSystem enemyComponent);
            enemyComponent.TakeDamage(5);
            
            /*weaponHolding.parent = null;
            Destroy(gameObject);*/
            
        }
        /*else if (collision.gameObject.tag == "Obstacles"){
            weaponHolding.parent = null;
            Destroy(gameObject);
        }*/
    }
}

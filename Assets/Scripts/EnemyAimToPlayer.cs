using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAimToPlayer : MonoBehaviour
{
    void Update()
    {
        Vector3 playerPosition = GameObject.Find("Player").GetComponent<Transform>().position;
        Vector2 playerDirection = new Vector2(playerPosition.x - this.transform.position.x, playerPosition.y - this.transform.position.y);
        transform.up = playerDirection;

        if (playerPosition.x > this.transform.position.x)
            this.transform.parent.localScale = new Vector3(-1f, 1f, 1f);
        else
            this.transform.parent.localScale = new Vector3(1f, 1f, 1f);
    }
}

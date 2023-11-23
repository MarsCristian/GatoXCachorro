using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeesPlayer : MonoBehaviour
{
    public bool sees = false;

    public void OnTriggerStay2D(Collider2D collision){
        if(collision.gameObject.tag == "Player")
            sees = true;
        else{
            sees = false;
        }
    }
}

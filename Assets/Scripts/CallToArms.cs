using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CallToArms : MonoBehaviour
{
    private bool alertIsTrue;

    void Start(){
        this.GetComponent<AIDestinationSetter>().target = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update(){
        alertIsTrue = GameObject.Find("Player").GetComponent<PlayerMovement>().alert;

        if (alertIsTrue){
            this.GetComponent<AIDestinationSetter>().enabled = true;
            this.GetComponent<AIPath>().enabled = true;
            this.GetComponentInChildren<EnemyAimToPlayer>().enabled = true;
        }
        else{
            this.GetComponent<AIDestinationSetter>().enabled = false;
            this.GetComponent<AIPath>().enabled = false;
            this.GetComponentInChildren<EnemyAimToPlayer>().enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairMovement : MonoBehaviour
{
    public string toPlace;

    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.name == "Player"){
            GameObject.Find("Player").GetComponent<Transform>().position = GameObject.Find(toPlace).GetComponent<Transform>().GetChild(0).transform.position;
        }
    }
}

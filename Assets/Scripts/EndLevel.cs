using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public GameObject exit;
    private int startingEnemies;
    private PlayerMovement alert;

    void Start(){
        startingEnemies = this.transform.childCount;
        alert = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if(startingEnemies > this.transform.childCount){
            alert.alert = true;
            if(this.transform.childCount == 0)
                exit.SetActive(true);
        }
    }
}
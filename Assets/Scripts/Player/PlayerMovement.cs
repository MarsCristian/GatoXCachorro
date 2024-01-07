using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4f;            
    public float input_x = 0, input_y = 0;
    public float normalMove = 1;
    private Rigidbody2D rb;

    public bool alert;
    private bool alertRaised;
    public GameEvent combatStarted;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start(){
        alert = false;
        alertRaised = false;
    }

    void Update()
    {
        input_x = Input.GetAxisRaw("Horizontal");
        input_y = Input.GetAxisRaw("Vertical");
        if (input_x != 0 && input_y != 0)
            normalMove = 0.7071067812f;
        else
            normalMove = 1f;

        if(alert && !alertRaised)
        {
            alertRaised = true;
            combatStarted.Raise();
        }
        if(!alert &&  alertRaised)
        {
            alertRaised = false;
            combatStarted.Raise();
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(input_x * moveSpeed * normalMove, input_y * moveSpeed * normalMove, 0);
    }

    void OnTriggerStay2D(Collider2D sensorCollision){
        if (sensorCollision.gameObject.tag == "Sensors"){
            alert = true;
        }
    }
}

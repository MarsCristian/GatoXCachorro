using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public Animator animator;

    private Vector3 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
        animator.speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Como não temos rigidbody, vamos calcular a velocidade na mão
        Vector3 currPos = transform.position;
        var velocity = (currPos - lastPos);
        // Muda a velocidade de reprodução da animação com base na velocidade
        animator.speed = velocity.magnitude * 10;
        lastPos = currPos;
        if (velocity.magnitude > 0f) 
        {
            Debug.Log(velocity);
        }
       
    }
}

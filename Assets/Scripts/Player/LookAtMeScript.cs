using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMeScript : MonoBehaviour
{
    private Transform thisIsPlayer;
    public float playerPositionWeight;
    public float mousePositionWeight;

    void Start()
    {
        thisIsPlayer = GameObject.Find("Player").GetComponent<Transform>();
    }
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        this.transform.position = new Vector2((thisIsPlayer.position.x * playerPositionWeight + mousePosition.x * mousePositionWeight)/(playerPositionWeight + mousePositionWeight), (thisIsPlayer.position.y * playerPositionWeight + mousePosition.y * mousePositionWeight)/(playerPositionWeight + mousePositionWeight));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int toLevel;

    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.name == "Player")
            SceneManager.LoadSceneAsync(toLevel);
    }
}

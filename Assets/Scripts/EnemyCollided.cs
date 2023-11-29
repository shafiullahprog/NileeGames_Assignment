using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollided : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            gameManager.GameOver();
        }
    }
}

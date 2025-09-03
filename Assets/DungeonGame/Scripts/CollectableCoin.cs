using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCoin : MonoBehaviour
{
   
    private bool isCollected = false;
   void OnTriggerEnter2D(Collider2D other)
    {
        if (isCollected) return;
        if (other.CompareTag("Player"))
        {
            isCollected = true;
            // Assuming GameManager has a method to add points
            GameManager gameManager = FindAnyObjectByType<GameManager>();
            if (gameManager != null)
            {
                gameManager.AddPoints(1f); // Add 1 point for each coin collected
            }
            Destroy(gameObject); // Destroy the coin after collection
        }
    }
}

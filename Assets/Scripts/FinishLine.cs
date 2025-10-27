using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private gameManager gameManager;
    void OnTriggerEnter2D(Collider2D other)
    {
        // Only care about collisions with Logos
        if (other.CompareTag("Logo"))
        {
            Logos logo = other.GetComponent<Logos>();

            // Only trigger game over if the logo has already landed/collided
            if (logo != null && logo.logoState == LogoState.Collision)
            {
                Debug.Log("Game Over Triggered!");

                // Set Game Over State
                gameManager.gameManagerInstance.gameState = GameState.GameOver;

                // ✅ Destroy all logos immediately
                gameManager.gameManagerInstance.DestroyAllLogos();
            }
        }
    }
}

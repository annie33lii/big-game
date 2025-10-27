using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopLine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //game over when logo collides with the top line
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Logo")
        {
            if (collider.gameObject.GetComponent<Logos>().logoState == LogoState.Collision)
            {
                gameManager.gameManagerInstance.gameState = GameState.GameOver;
            }
        }
    }
}

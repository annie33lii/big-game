using Unity.VisualScripting;
using UnityEngine;

public enum LogoType
{
    mit = 0,
    caltech = 1,
    cornell = 2,
    upenn = 3,
    harvard = 4,
    berkley = 5,
    stanford = 6,

}

public enum LogoState
{
    Ready = 0,
    StandBy = 1,
    Dropping = 2,
    Collision = 3,
}



public class Logos : MonoBehaviour
{
    public LogoType logoType = LogoType.mit;
    private bool isMoved = false;
    public LogoState logoState = LogoState.Ready;
    public float limit_x = 2.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {  
        if (gameManager.gameManagerInstance.gameState == GameState.StandBy && logoState == LogoState.StandBy)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isMoved = true;
            }

            // Mouse button released
            if (Input.GetMouseButtonUp(0) && isMoved)
            {
                isMoved = false;
                this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.5f;
                logoState = LogoState.Dropping;
                gameManager.gameManagerInstance.gameState = GameState.InProgress; 
                gameManager.gameManagerInstance.InvokeCreateLogo(0.5f);


            }
            if (isMoved)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                this.gameObject.GetComponent<Transform>().position = new Vector3(mousePosition.x, this.gameObject.GetComponent<Transform>().position.y, this.gameObject.GetComponent<Transform>().position.z);
            }
        }

        // Limit the logo's horizontal position within screen bounds
        if (this.transform.position.x > limit_x)
        {
            this.transform.position = new Vector3(limit_x, this.transform.position.y, this.transform.position.z);
        }
        if (this.transform.position.x < -limit_x)
        {
            this.transform.position = new Vector3(-limit_x, this.transform.position.y, this.transform.position.z);
            
        }

    }


    //Collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag == "Floor")
        {
            gameManager.gameManagerInstance.gameState = GameState.StandBy;
            logoState = LogoState.Collision;
        }
        if (collision.gameObject.tag == "Logo")
        {
            gameManager.gameManagerInstance.gameState = GameState.StandBy;
            logoState = LogoState.Collision;
        }
    }
}
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
public class Logos : MonoBehaviour
{
    public LogoType logoType = LogoType.mit;

    private bool isMoved = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMoved = true;
        }
        if (Input.GetMouseButtonUp(0) && isMoved)
        {
            isMoved = false;
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.5f;

            gameManager.gameManagerInstance.InvokeCreateLogo(0.5f);


        }
        if (isMoved)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.gameObject.GetComponent<Transform>().position = new Vector3(mousePosition.x, this.gameObject.GetComponent<Transform>().position.y, this.gameObject.GetComponent<Transform>().position.z);
        }

    }
}
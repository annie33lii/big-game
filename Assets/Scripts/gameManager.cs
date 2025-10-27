using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Ready = 0,
    StandBy = 1,
    InProgress = 2,
    GameOver = 3,
}

public class gameManager : MonoBehaviour
{
    public GameObject[] logoList;
    public GameObject RefreshPoint;
    public GameObject startBtn;

    public static gameManager gameManagerInstance;

    public GameState gameState = GameState.Ready;

    public GameObject gameOver;

    void Awake()
    {
        gameManagerInstance = this;
    }

    void Start()
    {
        gameOver.SetActive(false);
    }
    void Update()
    {

    }

    public void StartGame()
    {
        Debug.Log("Game Started");
        CreateLogo();
        gameState = GameState.StandBy; 
        startBtn.SetActive(false);
    }

    public void InvokeCreateLogo(float invokeTime)
    {
        Invoke("CreateLogo", invokeTime);
    }

    public void CreateLogo()
    {
        int index = Random.Range(0, 3);
        if (logoList.Length >= index && logoList[index] != null)
        {
            GameObject logoObj = logoList[index];
            var currentLogo = Instantiate(logoObj, RefreshPoint.transform.position, logoObj.transform.rotation);
            currentLogo.GetComponent<Logos>().logoState = LogoState.StandBy;
        }
    }

    public void CombineNewLogo(LogoType currentLogoType, Vector3 currentPosition, Vector3 collisionPosition)
    {
        Vector3 centerPosition = (currentPosition + collisionPosition) / 2;

        int index = (int)currentLogoType + 1;
        GameObject ComebineLogoObj = logoList[index];

        var newLogo = Instantiate(ComebineLogoObj, centerPosition, ComebineLogoObj.transform.rotation);
        newLogo.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
        newLogo.GetComponent<Logos>().logoState = LogoState.Collision;
    }

    public void DestroyAllLogos()
    {
        GameObject[] logos = GameObject.FindGameObjectsWithTag("Logo");

        foreach (GameObject logo in logos)
        {
            Destroy(logo);
        }

        Debug.Log("All logos destroyed!");
        gameOver.SetActive(true);
    }
}
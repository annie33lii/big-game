using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Ready = 0,
    StandBy = 0,
    InProgress = 0,
    GameOver = 0,
    CalculateScore = 4,
}

public class gameManager : MonoBehaviour
{
    public GameObject[] logoList;
    public GameObject RefreshPoint;
    public GameObject startBtn;

    public static gameManager gameManagerInstance;

    //public Vector3 combineScale = new Vector3(0, 0, 0);

    public GameState gameState = GameState.Ready;

    void Awake()
    {
        gameManagerInstance = this;
    }

    void Start()
    {
        
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

    // Combine new logo
    public void CombineNewLogo(LogoType currentLogoType, Vector3 currentPos, Vector3 collisionPos)
    {
        Vector3 centerPos = (currentPos + collisionPos) / 2;
        int index = (int)currentLogoType + 1;
        GameObject combineLogoObj = logoList[index];
        var combineLogo = Instantiate(combineLogoObj, centerPos, combineLogoObj.transform.rotation);
        combineLogo.GetComponent<Rigidbody2D>().gravityScale = 1.5f;
        combineLogo.GetComponent<Logos>().logoState = LogoState.Collision;
        //combineLogo.transform.localScale = combineScale;
    }
}
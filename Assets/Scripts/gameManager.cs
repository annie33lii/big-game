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
}
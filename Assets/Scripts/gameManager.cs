using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject[] logoList;
    public GameObject RefreshPoint;
    public GameObject startBtn;

    public static gameManager gameManagerInstance;
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
            Instantiate(logoObj, RefreshPoint.transform.position, logoObj.transform.rotation);
        }
    }
}
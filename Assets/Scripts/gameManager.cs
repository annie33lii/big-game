using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject[] LogoList;
    public GameObject RefreshPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void StartGame()
    {
        Debug.Log("Game Started!");
        int index = Random.Range(0, LogoList.Length);
        GameObject logo = LogoList[index];
        Instantiate(logo, RefreshPoint.transform.position, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

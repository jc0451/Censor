using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    private Stamper Stampstate;

    GameObject LeftArticle;
    GameObject RightArticle;

    public bool LeftSelected = false;
    public bool RightSelected = false;

    private void Start()
    {
        Stampstate = GameObject.Find("Stamper").GetComponent<Stamper>();

        LeftArticle = GameObject.FindGameObjectWithTag("Left Text");
        RightArticle = GameObject.FindGameObjectWithTag("Right Text");
    }
    private void Update()
    {
        
    }

    public void RightSelect()
    {
        if (Stampstate.StampSelected == false)
        {
            RightSelected = true;
            LeftSelected = false;
        }
    }
    public void LeftSelect()
    {
        if (Stampstate.StampSelected == false)
        {
            LeftSelected = true;
            RightSelected = false;
        }
    }
}

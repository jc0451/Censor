using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    private Stamper Stampstate;

    private void Start()
    {
        Stampstate = GameObject.Find("Stamper").GetComponent<Stamper>();
    }
    private void Update()
    {
        
    }
}

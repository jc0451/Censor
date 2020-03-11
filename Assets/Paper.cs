using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    GameObject stamper;
    public GameObject toPublish;

    void Start()
    {
        stamper = GameObject.Find("Stamper");
    }

    void Update()
    {
        
    }


    private void OnMouseOver()
    {
        if (stamper.GetComponent<Stamper>().StampSelected == true && Input.GetMouseButtonDown(0))
        {
            stamper.GetComponent<Stamper>().HasStamped();
            toPublish.SetActive(true);
        }
    }
}

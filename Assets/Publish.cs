using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Publish : MonoBehaviour
{
    private Stamper Stampstate;
    public string choice;
    public float targetTime = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        Stampstate = GameObject.Find("Stamper").GetComponent<Stamper>();
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;

        //if (Stampstate.StampSelected == true)
        {
            if (targetTime <= 0.0f)
            {
                timerEnded();
            }
            if (targetTime <= 3.0f)
            {
                SendMessageUpwards("Sent");
            }
        }
    }
    void timerEnded()
    {
        SceneManager.LoadScene(choice);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class end : MonoBehaviour
{

    public GameObject imgo;
    public Image img;

    // Start is called before the first frame update
    void Start()
    {
        Sent();
        GameObject objs = GameObject.FindGameObjectWithTag("ambient");
        objs.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void Sent()
    {
        StartCoroutine(FadeImage(true));
    }
    IEnumerator FadeImage(bool fadeAway)
    {

        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }


}

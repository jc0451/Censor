using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    private Stamper Stampstate;
    Vector2 mousePos;
    Vector2 shredderPos;
    Vector3 articleSize;
    Vector3 shredderSize;

    GameObject leftArticle;
    GameObject rightArticle;
    Collider2D shredder;

    public ParticleSystem particles;
    bool hasPlayed = false;

    public bool leftSelected = false;
    public bool rightSelected = false;
    public bool shredderSelected = false;

    public AudioSource audioData1;
    public AudioSource audioData2;

    private void Start()
    {
       
        shredder = GameObject.Find("Shredder").GetComponent<Collider2D>();
        leftArticle = GameObject.FindGameObjectWithTag("Left Text");
        rightArticle = GameObject.FindGameObjectWithTag("Right Text");
        Stampstate = GameObject.Find("Stamper").GetComponent<Stamper>();
        articleSize = leftArticle.transform.localScale;
        shredderSize = gameObject.transform.localScale;
    }
    private void Update()
    {
        if (leftSelected == false)
        {
            leftArticle.transform.localScale = articleSize;
        }
        if (rightSelected == false)
        {
            rightArticle.transform.localScale = articleSize;
        }
        if (shredderSelected == false)
        {
            gameObject.transform.localScale = shredderSize;
        }

        if (Stampstate.StampSelected == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.tag == "Left Text")
                    {
                        LeftSelect();
                        audioData2.Play(0);
                        Debug.Log("Left Paper selected");
                        leftArticle.transform.localScale = articleSize * 1.05f;
                    }
                    else if (hit.collider.gameObject.tag == "Right Text")
                    {
                        RightSelect();
                        audioData2.Play(0);
                        Debug.Log("Right Paper selected");
                        rightArticle.transform.localScale = articleSize * 1.05f;
                    }
                    else if (hit.collider.gameObject.tag == "Shredder")
                    {
                        gameObject.transform.localScale = shredderSize * 1.05f;
                        Debug.Log("Shredder selected");
                        shredderSelected = true;
                        if (leftSelected == true)
                        {
                            
                            leftArticle.SetActive(false);
                            Stampstate.HasShredded();
                            shredder.enabled = false;
                            PlayParticles();
                        }
                        else if (rightSelected == true)
                        {
                            
                            rightArticle.SetActive(false);
                            Stampstate.HasShredded();
                            shredder.enabled = false;
                            PlayParticles();
                        }
                    }
                }
                else
                {
                    Debug.Log("Nothing selected");
                    shredderSelected = false;
                    rightSelected = false;
                    leftSelected = false;
                }
            }
        }
    }

    public void RightSelect()
    {
        if (Stampstate.StampSelected == false)
        {
            rightSelected = true;
            leftSelected = false;
        }
    }
    public void LeftSelect()
    {
        if (Stampstate.StampSelected == false)
        {
            leftSelected = true;
            rightSelected = false;
        }
    }

    public void PlayParticles()
    {
        if (!hasPlayed)
        {
            audioData1.Play(0);
            particles.Play();
            hasPlayed = true;
        }
    }
}

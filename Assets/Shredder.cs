using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    private Stamper Stampstate;
    Vector2 mousePos;
    Vector2 shredderPos;

    GameObject leftArticle;
    GameObject rightArticle;
    Collider2D shredder;

    public ParticleSystem particles;
    bool hasPlayed = false;

    public bool leftSelected = false;
    public bool rightSelected = false;
    private float timer = 5.0f;

    private void Start()
    {
        shredder = GameObject.Find("Shredder").GetComponent<Collider2D>();
        leftArticle = GameObject.FindGameObjectWithTag("Left Text");
        rightArticle = GameObject.FindGameObjectWithTag("Right Text");
        Stampstate = GameObject.Find("Stamper").GetComponent<Stamper>();
    }
    private void Update()
    {
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
                        Debug.Log("Left Paper selected");
                    }
                    else if (hit.collider.gameObject.tag == "Right Text")
                    {
                        RightSelect();
                        Debug.Log("Right Paper selected");
                    }
                    else if (hit.collider.gameObject.tag == "Shredder")
                    {
                        Debug.Log("Shredder selected");
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
            particles.Play();
            hasPlayed = true;
        }
    }
}

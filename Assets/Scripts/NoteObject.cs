﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;
    public GameObject noteHolder;
    public NotePool notePool;
    // public NotePool notePool = noteHolder.NotePool;

    // Start is called before the first frame update
    void Start()
    {
        noteHolder = GameObject.Find("NoteHolder");
        notePool = noteHolder.GetComponent<NotePool>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if(canBePressed)
            {
                
                gameObject.SetActive(false);
                //GameManager.instance.NoteHit();
                // notePool.ReturnObject(gameObject);
                if(Mathf.Abs(transform.position.y) > 0.25)
                {
                    // Debug.Log("Hit");
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation); 
                }
                else if(Mathf.Abs(transform.position.y) > 0.05)
                {
                    // Debug.Log("Good");
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);  
                }
                else
                {
                    // Debug.Log("Perfect");
                    GameManager.instance.PerfectHit(); 
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation); 
                }
                

                notePool.ReturnObject(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(gameObject.activeSelf)
        {
            if(other.tag == "Activator")
            {
                canBePressed = false;
                GameManager.instance.NoteMissed();
                Instantiate(missEffect, transform.position, missEffect.transform.rotation); 
                notePool.ReturnObject(gameObject);
            }
        }
    }
}

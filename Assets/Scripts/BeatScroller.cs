using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{

    public float beatTemp;
    public bool hasStarted;
    public GameObject noteHolder;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        beatTemp = beatTemp / 60f;
        hasStarted = false;
        gameManager.totalNotes = FindObjectsOfType<NoteObject>().Length;
        noteHolder.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(hasStarted)
        {
            if(!noteHolder.activeInHierarchy){
                noteHolder.SetActive(true);
            }
            transform.position -= new Vector3(0f, beatTemp * Time.deltaTime, 0f);
        }           
    }
}

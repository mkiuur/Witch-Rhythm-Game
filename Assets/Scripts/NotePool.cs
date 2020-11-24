using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePool : MonoBehaviour
{

    public GameObject objectToPool;

    public List<GameObject> pool = new List<GameObject>();

    public int startAmount;

    public GameObject lastNote;
    
    public GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < startAmount; i++)
        {
            pool.Add(Instantiate(objectToPool));
            pool[i].SetActive(false);
            pool[i].transform.parent = transform;
        }
        lastNote = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject SpawnObject((int,float) note) 
    {
        GameObject ret;
        GM.totalNotes++;

        if(pool.Count > 0)
        {
            ret = pool[0];
            pool.RemoveAt(0);
        }       
        else
        {
            ret = Instantiate(objectToPool);
            ret.transform.parent = transform;
        }
        var noteObject = ret.GetComponent<NoteObject>();
        int direction = note.Item1;
        float rest = note.Item2;
        float xTransform = 0f;
        float yTransform = 10f;
        float rotation = 0f;
        switch(direction)
        {
            case 0:
                xTransform = -1.5f;
                rotation = 180f;
                noteObject.keyToPress = KeyCode.LeftArrow;
                break;
            case 1:
                xTransform = -0.5f;
                rotation = 90f;
                noteObject.keyToPress = KeyCode.UpArrow;
                break;
            case 2:
                xTransform = 0.5f;
                rotation = -90f;
                noteObject.keyToPress = KeyCode.DownArrow;
                break;
            case 3:
                xTransform = 1.5f;
                rotation = 0f;
                noteObject.keyToPress = KeyCode.RightArrow;
                break;
        }
        if(lastNote!=null)
        {
            yTransform = lastNote.transform.position.y + rest;
        }
        noteObject.canBePressed = false;
        ret.transform.position = new Vector3(xTransform,yTransform,0);
        ret.transform.rotation = Quaternion.Euler(0,0,rotation); 
        ret.SetActive(true);
        lastNote = ret;
        return ret;
    }

    public void ReturnObject(GameObject objectToReturn)
    {
        pool.Add(objectToReturn);
        objectToReturn.SetActive(false);
    }
}


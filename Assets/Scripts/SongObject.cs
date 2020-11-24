using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongObject : MonoBehaviour
{

    // Direction [left, up, down, right] -> [0,1,2,3]
    // Rest until next note -> rest multiplier e.g. 0.5f -> semitone
    public List<(int,float)> song = new List<(int,float)>{};

    public NotePool notePool;
    public GameManager GM;
    public List<int> directions = new List<int>() {0,1,2,3};
    public List<float> rests = new List<float>() {0.5f,1.0f};

    // Start is called before the first frame update
    void Start()
    {
        
        // song.Add((3,1.0f));
        // song.Add((2,1.0f));
        // song.Add((1,1.0f));
        // song.Add((0,1.0f));
        // song.Add((3,0.5f));
        // song.Add((2,0.5f));
        // song.Add((1,0.5f));
        // song.Add((0,0.5f));
    }

    // Update is called once per frame
    void Update()
    {
        int direction = directions[Random.Range(0, directions.Count)];
        float rest = rests[Random.Range(0, rests.Count)];
        song.Add((direction,rest));

        if(song.Count > 0)
        {
            if(notePool.pool.Count > 0)
            {
                var note = song[0];
                song.RemoveAt(0);
                notePool.SpawnObject(note);
            }
        }
    }
}

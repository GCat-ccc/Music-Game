using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatSpeed;
    public bool hasStart = false;

    // Start is called before the first frame update
    void Start()
    {
        beatSpeed = beatSpeed / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStart)
        {
            if(Input.anyKeyDown)
            {
                hasStart = true;
            }
        }
        else
        {
            transform.position += new Vector3(0f, beatSpeed * Time.deltaTime, 0f); 
        }
    }
}

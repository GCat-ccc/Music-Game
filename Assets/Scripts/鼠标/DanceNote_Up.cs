using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceNote_Up : DanceNote
{
    private void Update()
    {
        transform.position -= Vector3.up * noteSpeed * Time.deltaTime;
    }
}

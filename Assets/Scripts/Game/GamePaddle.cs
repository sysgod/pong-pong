using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePaddle : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
       
            Vector3 pos = Input.mousePosition;
          
            pos = Camera.main.ScreenToWorldPoint(pos);
            pos.y = transform.position.y;
            pos.z = 0;
            transform.position = pos;
    }
}

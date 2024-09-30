using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private Vector2 dir = Vector2.right;
   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && dir != Vector2.down)
        { 
            dir = Vector2.up; 
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && dir != Vector2.up)
        {
            dir = Vector2.down;
        }
        else if (Input.GetKeyDown (KeyCode.LeftArrow) && dir != Vector2.right)
        {
            dir = Vector2.left; 
        }
        else if ( Input.GetKeyDown (KeyCode.RightArrow) && dir != Vector2.left)
        {
            dir = Vector2.right; 
        } 
    }
    private void FixedUpdate()
    {
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + dir.x,
            Mathf.Round(this.transform.position.y) + dir.y,
            0);
    }
}

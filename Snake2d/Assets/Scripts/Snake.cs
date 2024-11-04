using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private Vector2 dir = Vector2.right;

    private List<Transform> _segments = new List<Transform>();

    public Transform Tail;

    private void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform);
    }

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
        for(int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[ i - 1 ].position;
        }
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + dir.x,
            Mathf.Round(this.transform.position.y) + dir.y,
            0);
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.Tail);
        segment.position = _segments[_segments.Count - 1].position;
        
        _segments.Add(segment);
    }

    private void ResetState()
    {
        for(int i=1; i< _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }
        
        _segments.Clear();
        _segments.Add(this.transform);

        this.transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            Grow();
        }
        else if (collision.tag == "Obstacle")
        {
            ResetState();
        }
    }
}

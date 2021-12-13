using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRepeating : MonoBehaviour
{
    private BoxCollider2D lineCollider;
    private Rigidbody2D lineRigidbody;
    private float lineHorizontalLength;
    
    void Start()
    {
        //get component
        lineRigidbody = GetComponent<Rigidbody2D>();
        lineCollider = GetComponent<BoxCollider2D>();
        lineHorizontalLength = lineCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -lineHorizontalLength * 2.2f)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        Vector2 lineOffSet = new Vector2(lineHorizontalLength * 5f, 0);
        transform.position = (Vector2)transform.position + lineOffSet;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10.0f;

    public Animator run;

    // Private Methods

    void Start()
    {
        run = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            run.Play("blue_run");
        }
        else if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            run.Play("New State");
        }
    }

    private void Move()
    {
        // get a change in direction
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        // calculate a new x position
        var newXPos = transform.position.x + deltaX;

        transform.position = new Vector2(newXPos, transform.position.y);
    }
}

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
        Run();
        
    }

    bool AnimatorIsPlaying(){
        return run.GetCurrentAnimatorStateInfo(0).length >
        run.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    private void Run()
    {
        // Run animation
        
        // if pressing 'Q' kick
        if(Input.GetKey("q"))
        {
            run.Play("blue_kick");
        }

        // if pressing 'A' run left animation
        if(Input.GetAxis("Horizontal") < 0 && !Input.GetKey("q"))
        {
            run.Play("blue_run_left");
        }

        // else if pressing 'D' run right animation
        else if(Input.GetAxis("Horizontal") > 0 && !Input.GetKey("q"))
        {
            run.Play("blue_run");
        }
        // not going right or left, back to idle state. 
        // with normalised time so the other animation play through
        else if(run.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8)
        {
            run.Play("New State");
        }
        
    }

    private void Move()
    {
        // get a change in direction
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        //var errorr = Input.GetAxis("Horizontal");
        //Debug.Log(errorr);

        // calculate a new x position (character position + moveSpeed)
        var newXPos = transform.position.x + deltaX;

        transform.position = new Vector2(newXPos, transform.position.y);
    }
}

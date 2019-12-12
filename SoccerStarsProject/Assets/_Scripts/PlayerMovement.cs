using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10.0f;
    public EnemyCount counts;

    public Animator run;
    public bool direction = true;
    public Rigidbody2D Temporary_RigidBody;

    public GameObject player;
    
    public GameObject health;
    BoxCollider2D m_Collider;
    float scaleX, scaleY, offsetX, offsetY;

    
    private Sprite sprite;

    private int count = 0;
    //public bool moveRight = false;

    // Private Methods

    void Start()
    {
        m_Collider = GetComponent<BoxCollider2D>();

        scaleX = 65.0f;
        scaleY = 100.0f;
        offsetX = 0.0f;
        offsetY = 0.0f;
        run = GetComponent<Animator>();
        Temporary_RigidBody = player.GetComponent<Rigidbody2D>();
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
            if(direction == true)
            {
                run.Play("blue_kick");
            }
            else
            {
                run.Play("blue_kick_left");
            }
        }
       

        // if pressing 'A' run left animation
        if(Input.GetAxis("Horizontal") < 0 )
        {
            direction = false;
            run.Play("blue_run_left");
            if(Input.GetKey("r"))
            {
                moveSpeed = 15.0f;
            }
            else if(!Input.GetKey("r"))
            {
                moveSpeed = 10.0f;
            }
            if(Input.GetKey("q"))
            {
                run.Play("blue_kick_left");
            }
        }

        if(Input.GetKeyDown("space") && player.transform.position.y < 1)
        {
            Temporary_RigidBody.AddForce(transform.up * 900);
        }

        // else if pressing 'D' run right animation
        else if(Input.GetAxis("Horizontal") > 0)
        {
            direction = true;
            run.Play("blue_run");
            if(Input.GetKey("r"))
            {
                moveSpeed = 15.0f;
            }
            else if(!Input.GetKey("r"))
            {
                moveSpeed = 10.0f;
            }
            if(Input.GetKey("q"))
            {
                run.Play("blue_kick");
            }
        }
        // if pressing Left Shift play crouch animation
        else if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            
            scaleX = 65.0f;
            scaleY = 50.0f;
            offsetX = 0.0f;
            offsetY = -25.0f;

            m_Collider.size = new Vector3(scaleX, scaleY);
            m_Collider.offset = new Vector3(offsetX, offsetY);
            run.Play("blue_crouch");
        }

        // not going right or left, back to idle state. 
        // with normalised time so the other animation play through
        else if(run.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8)
        {
            scaleX = 65.0f;
            scaleY = 100.0f;
            offsetX = 0.0f;
            offsetY = 0.0f;
            
            m_Collider.size = new Vector3(scaleX, scaleY);
            m_Collider.offset = new Vector3(offsetX, offsetY);
            run.Play("blue_idle");
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
    //Health
    void OnCollisionEnter2D(Collision2D col) {
        //Debug.Log("working???");
        if(col.gameObject.name == "bullet(Clone)"){
            //Debug.Log("Definatly working 8)");
            Destroy(col.gameObject);
            
            Sprite enemySprites = Resources.Load<Sprite>("greyHeart");
            Debug.Log(enemySprites.name);
            Transform heart = health.transform.Find("heart (2)");
            if(count==0){
                heart = health.transform.Find("heart (2)");
            }
            else if(count==1){
                heart = health.transform.Find("heart (1)");
            }
            else if(count==2){
                heart = health.transform.Find("heart");
                SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
            }
            count++;
            SpriteRenderer sr = heart.GetComponent<SpriteRenderer>();
            sr.sprite = enemySprites;
        }
    }
}
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
 
public class ShootEnemy : MonoBehaviour
{
    //Drag in the Bullet Emitter from the Component Inspector.
    public GameObject Bullet_Emitter;
 
    //Drag in the Bullet Prefab from the Component Inspector.
    public GameObject Bullet;
    private Rigidbody2D temp;

    Rigidbody2D Temporary_RigidBody;
    
    GameObject Temporary_Bullet_Handler;
    SpriteRenderer Temporary_Sprite_Renderer;
 
    //Enter the Speed of the Bullet from the Component Inspector.
    public float Bullet_Forward_Force;


    //public GameObject boss = GameObject.Find("boss");
    public ChaseEnemy bossScript;
    private bool newDirection = false;

    void Start(){
    }
       
    // Update is called once per frame
    void Update ()
    {
        bossScript = transform.GetComponent<ChaseEnemy>();
        //bossScript.moveRight = false;
        if (bossScript.moveRight == true && newDirection == false){
            //Bullet_Emitter.transform.position = Vector3.MoveTowards;
            Bullet_Emitter.transform.position = new Vector3(Bullet_Emitter.transform.position.x +1, Bullet_Emitter.transform.position.y, Bullet_Emitter.transform.position.z);
            newDirection = true;
        }
        else if (bossScript.moveRight == false && newDirection == true){
            //Bullet_Emitter.transform.position = Vector3.MoveTowards;
            Bullet_Emitter.transform.position = new Vector3(Bullet_Emitter.transform.position.x, Bullet_Emitter.transform.position.y, Bullet_Emitter.transform.position.z);
            newDirection = false;
        }

        if (Temporary_Bullet_Handler == null)
        {
            //The Bullet instantiation happens here.
            Temporary_Bullet_Handler = Instantiate(Bullet,Bullet_Emitter.transform.position,Bullet_Emitter.transform.rotation) as GameObject;
            //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
            //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
            Temporary_Bullet_Handler.transform.Rotate(Vector3.left);
 
            //Retrieve the Rigidbody component from the instantiated Bullet and control it.
            
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody2D>();
            Temporary_Sprite_Renderer = Temporary_Bullet_Handler.GetComponent<SpriteRenderer>();
 
            //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
            if(newDirection == false){
                Temporary_RigidBody.AddForce(-transform.right * Bullet_Forward_Force);
                Temporary_Sprite_Renderer.flipX=false;
            }
            else if(newDirection == true){
                Temporary_RigidBody.AddForce(transform.right * Bullet_Forward_Force);
                Temporary_Sprite_Renderer.flipX=true;
            }

            temp = Temporary_RigidBody;
            Destroy(Temporary_Bullet_Handler, 2f);
        }
    }
    
}
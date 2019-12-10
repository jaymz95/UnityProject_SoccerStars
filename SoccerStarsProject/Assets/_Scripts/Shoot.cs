using UnityEngine;
using System.Collections;
 
public class Shoot : MonoBehaviour
{
    //Drag in the Bullet Emitter from the Component Inspector.
    public GameObject Bullet_Emitter;

    
    public GameObject player;
 
    //Drag in the Bullet Prefab from the Component Inspector.
    public GameObject Bullet;
    private Rigidbody2D temp;

    Rigidbody2D Temporary_RigidBody;
    
    GameObject Temporary_Bullet_Handler;
 
    //Enter the Speed of the Bullet from the Component Inspector.
    public float Bullet_Forward_Force;
       
    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown("space") && Temporary_Bullet_Handler == null)
        {
            //The Bullet instantiation happens here.
            Temporary_Bullet_Handler = Instantiate(Bullet,Bullet_Emitter.transform.position,Bullet_Emitter.transform.rotation) as GameObject;
            //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
            //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
            Temporary_Bullet_Handler.transform.Rotate(Vector3.left);
 
            //Retrieve the Rigidbody component from the instantiated Bullet and control it.
            
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody2D>();
 
            //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
            Temporary_RigidBody.AddForce(-transform.right * Bullet_Forward_Force);

            temp = Temporary_RigidBody;
            /*if(Temporary_RigidBody.position.x < player.transform.position.x)
            {
                Destroy(Temporary_Bullet_Handler, 0.0f);
            }*/
            //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
            Destroy(Temporary_Bullet_Handler, 2f);
        }
        /*if(temp != null && temp.position.x-0.5 < player.transform.position.x && temp.position.y < player.transform.position.y)
        {
            Destroy(Temporary_Bullet_Handler);
        }*/
    }
    
}
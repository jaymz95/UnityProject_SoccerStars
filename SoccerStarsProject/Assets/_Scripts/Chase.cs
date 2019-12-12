using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed;
    public float increaseSpeed;
    Transform currentPatrolPoint;
    int currentPatrolIndex;
    public Transform target;
    public float chaseRange;
    public Animator run;
    
    public bool moveRight = false;
    // Start is called before the first frame update
    void Start()
    {
        currentPatrolIndex = 0;
        //currentPatrolPoint = patrolPoints [currentPatrolIndex];
        run = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position,target.position);
        if(distanceToTarget < chaseRange) {

            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2 (targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards (transform.rotation, q, 0);
            
            // if player is to the left of emeny, run left animation
            if(target.position.x+2 < transform.position.x )
            {
                moveRight = false;
                run.Play("boss_run_left");
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }

            // if player is to the right of emeny, run right animation
            else if(target.position.x-2 > transform.position.x){
                
                moveRight = true;
                run.Play("boss_run");
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            }
        }

    }
    void OnCollisionEnter2D(Collision2D col) {
        //Debug.Log("working???");
        if(col.gameObject.name == "Football(Clone)"){
            //Debug.Log("Definatly working 8)");
            Destroy(col.gameObject);
            Destroy(this.gameObject);
            
        }
    }
}

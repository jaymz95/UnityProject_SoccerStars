using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemy : MonoBehaviour
{
       public Transform[] patrolPoints;
    public float speed;
    Transform currentPatrolPoint;
    int currentPatrolIndex;
    public Transform target;
    public float chaseRange;
    public Animator run;


    // Start is called before the first frame update
    void Start()
    {
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints [currentPatrolIndex];
        run = GetComponent<Animator>();
        //run.Play("boss_run_left");
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
            // if pressing 'A' run left animation
            if(target.position.x+2 < transform.position.x )
            {
                run.Play("enemy_run_left");
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }

            // else if pressing 'D' run right animation
            else if(target.position.x-2 > transform.position.x)
            {
                run.Play("enemy_run");
                transform.Translate(Vector3.right * Time.deltaTime * speed);
                
            }
        }
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // == fields ==
    [SerializeField]
    private EnemyMovement enemyPrefab;  // what to spawn

    [SerializeField]
    private float delayTime = 0.5f;

    [SerializeField]
    private float intervalRate = 0.3f;

    private EnemyMovement enemy;
    private GameObject ChildGameObject;
    private int index = 0;
    private bool nextSpawn = false;

    private GameObject enemyParent;
    private GameObject player;
    private GameObject sPoints;

    private IList<SpawnPoints> spawnPoints;

    private Stack<SpawnPoints> spawnStack;

    // Start is called before the first frame update
    void Start()
    {
        // get the EnemyParent object
        
        sPoints = GameObject.Find("SpawnPoints");
        player = GameObject.Find("player");
        enemyParent = GameObject.Find("EnemyParent");
        if (!enemyParent)
        {
            enemyParent = new GameObject("EnemyParent");
        }

        spawnPoints = GetComponentsInChildren<SpawnPoints>();
        // now start spawning
        SpawnEnemiesRepeating();
    }

    private void SpawnEnemiesRepeating()
    {
        // use InvokeRepeating to call a spawn method to spawn one enemy
        // create the stack to spawn from

        //spawnStack = ShuffleList.CreateShuffledStack(spawnPoints);
        ChildGameObject = sPoints.transform.GetChild (0).gameObject;

        // call the spawn method every n seconds   
        InvokeRepeating("Spawns", delayTime, intervalRate);
    }

    private void Spawns()    // create one enemy
    {
        // create a new enemy, put it at the spawn point
        //var randomIndex = UnityEngine.Random.Range(0, spawnPoints.Count);
        //var currPoint = spawnPoints[randomIndex];
        // if the stack is empty, refill
        /*if( spawnStack.Count == 0)
        {
            spawnStack = ShuffleList.CreateShuffledStack(spawnPoints);
            //spawnStack = spawnPoints;
        }*/

        // select the next from the stack (randomised)
        var currPoint = spawnPoints[index];
        
        /*if(nextSpawn == true){
            index++;
            ChildGameObject = sPoints.transform.GetChild (index).gameObject;
            nextSpawn = false;
        }*/
        
        Debug.Log("player: " + player.transform.position.x);
        Debug.Log("SpawnPoint: " + ChildGameObject.transform.position.x);

        if(player.transform.position.x < ChildGameObject.transform.position.x+5 && 
            player.transform.position.x > ChildGameObject.transform.position.x-Random.Range(0, 15) && 
            nextSpawn == false){
            enemy = Instantiate(enemyPrefab, enemyParent.transform);
            enemy.transform.position = currPoint.transform.position;

            index++;
            if (sPoints.transform.GetChild (index).gameObject != null){
                ChildGameObject = sPoints.transform.GetChild (index).gameObject;   
            }
            else{
                nextSpawn = true;
            }

        }
        //EnemyMovement enemy = Instantiate(enemyPrefab, enemyParent.transform);
        // set the enemy at the spawn point
        //enemy.transform.position = currPoint.transform.position;

    }
}

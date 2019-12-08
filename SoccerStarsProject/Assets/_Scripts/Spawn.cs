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

    private GameObject enemyParent;

    private IList<SpawnPoints> spawnPoints;

    private Stack<SpawnPoints> spawnStack;

    // Start is called before the first frame update
    void Start()
    {
        // get the EnemyParent object
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

        spawnStack = ShuffleList.CreateShuffledStack(spawnPoints);

        // call the spawn method every n seconds   
        InvokeRepeating("Spawns", delayTime, intervalRate);
    }

    private void Spawns()    // create one enemy
    {
        Debug.Log("Text: ");
        // create a new enemy, put it at the spawn point
        //var randomIndex = UnityEngine.Random.Range(0, spawnPoints.Count);
        //var currPoint = spawnPoints[randomIndex];
        // if the stack is empty, refill
        if( spawnStack.Count == 0)
        {
            spawnStack = ShuffleList.CreateShuffledStack(spawnPoints);
            //spawnStack = spawnPoints;
        }
        // select the next from the stack (randomised)
        var currPoint = spawnStack.Pop();
        var enemy = Instantiate(enemyPrefab, enemyParent.transform);
        // set the enemy at the spawn point
        enemy.transform.position = currPoint.transform.position;

    }
}

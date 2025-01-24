using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SpawnScript : MonoBehaviour
{
    [SerializeField] public GameObject playerSeekPrefab;
    [SerializeField] public GameObject objectivePrefab;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
            SpawnSeek();
        }
        
    }

    public void SpawnSeek()
    {

        GameObject objectiveInst = Instantiate(objectivePrefab, new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(-4.5f, 4.5f), 0f), Quaternion.identity, transform);
        GameObject playerInst = Instantiate(playerSeekPrefab, new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(-4.5f, 4.5f), 0f), Quaternion.identity, transform);
        

        
    }
}







//GameObject enemyInst = Instantiate(enemyPrefab, new Vector3(8.5f, Random.Range(-5.5f, 3.5f), 0f), Quaternion.identity, transform);
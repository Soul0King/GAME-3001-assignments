using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SpawnScript : MonoBehaviour
{
    [SerializeField] public GameObject playerSeekPrefab;
    [SerializeField] public GameObject playerFleePrefab;
    [SerializeField] public GameObject playerArrivePrefab;
    [SerializeField] public GameObject playerAvoidPrefab;
    [SerializeField] public GameObject objectivePrefab;
    [SerializeField] public GameObject obstaclePrefab;
    [SerializeField] public UnityEngine.Transform startMaker;
    [SerializeField] public UnityEngine.Transform endMaker;

    

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
            SpawnSeek();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            
            SpawnFlee();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            
            SpawnArrive();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            
            SpawnAvoid();
        }
        
    }

    public void SpawnSeek()
    {
        GameObject objectiveInst = Instantiate(objectivePrefab, new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(-4.5f, 4.5f), 0f), Quaternion.identity, transform);
        GameObject playerSeekInst = Instantiate(playerSeekPrefab, new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(-4.5f, 4.5f), 0f), Quaternion.identity, transform);
    }

    public void SpawnFlee()
    {
        GameObject obstacleInst = Instantiate(obstaclePrefab, new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(-4.5f, 4.5f), 0f), Quaternion.identity, transform);
        GameObject playerFleeInst = Instantiate(playerFleePrefab, new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(-4.5f, 4.5f), 0f), Quaternion.identity, transform);
    }

    public void SpawnArrive()
    {
        GameObject objectiveInst = Instantiate(objectivePrefab, new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(-4.5f, 4.5f), 0f), Quaternion.identity, transform);
        GameObject playerArriveInst = Instantiate(playerArrivePrefab, new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(-4.5f, 4.5f), 0f), Quaternion.identity, transform);
    }

    public void SpawnAvoid()
    {
        GameObject objectiveInst = Instantiate(objectivePrefab, new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(-4.5f, 4.5f), 0f), Quaternion.identity, transform);
        GameObject playerAvoidInst = Instantiate(playerAvoidPrefab, new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(-4.5f, 4.5f), 0f), Quaternion.identity, transform);


        Vector3 objectLine = (endMaker.transform.position - startMaker.transform.position);
        float distance = objectLine.magnitude;
        objectLine = objectLine.normalized;

        GameObject obstacleInst = Instantiate(obstaclePrefab, new Vector3(objectLine.x, objectLine.y, 0f), Quaternion.identity, transform);
    }
    //(Vector3.Distance(startMaker.position, endMaker.position) / 2f)

    //Vector3.Lerp(startMaker.position, endMaker.position, 2f)
}







//GameObject enemyInst = Instantiate(enemyPrefab, new Vector3(8.5f, Random.Range(-5.5f, 3.5f), 0f), Quaternion.identity, transform);
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SpawnScript;

public class Objective : SpawnScript
{
    [SerializeField]
    public Transform m_target;

    public Vector3 TargetPosition
    {
        get { return m_target.position; }
        set { m_target.position = value; }
    }
    // Start is called before the first frame update
    public void Start()
    {
        if (m_target != null)
        {

            //TargetPosition = m_target.position;
            TargetPosition = m_target.position;
            Debug.Log("Starting Agent...");
            Debug.Log("aaa" + TargetPosition);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha0))
        {
            Destroy(gameObject);
        }
    }



}
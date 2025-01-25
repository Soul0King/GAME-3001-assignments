using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;


public class AvoidMovement : Objective
{

    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] public GameObject player;
    [SerializeField] private Transform targetObject;
    private Vector3 TargetPosition1 = Vector3.zero;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

        //base.Start();
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("start look" + TargetPosition);

    }

    // Update is called once per frame
    void Update()
    {
        TargetPosition = GameObject.Find("Objective Parent(Clone)").transform.position;
        TargetPosition1 = GameObject.Find("Obstacle Parent(Clone)").transform.position;
        if (TargetPosition != (null)) 
        {
            
            if (Vector3.Distance(TargetPosition1, transform.position) > 2)
            {
                SeekForward();
            }

            if (Vector3.Distance(TargetPosition1, transform.position) < 2)
            {
                Avoid();
            }
            

        }
        //targetPosition = targetObject.position;
        //targetPosition.z = 0f;

        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha0))
        {
            Destroy(gameObject);
        }
    }

    private void SeekForward() //  a seek with rotation to target but onlu moving along forward vector
    {

        //calculate direction to target
        Vector2 direction = (TargetPosition - transform.position).normalized;
        // calculate the angle to rotate towards the target
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90.0f;

        ////smoothly rotate towards the target
        //float angleDifference = Mathf.DeltaAngle(targetAngle, transform.eulerAngles.z);
        //float rotationStep = rotationSpeed * Time.deltaTime;
        //float rotationAmount = Mathf.Clamp(angleDifference, -rotationStep, rotationStep);
        //transform.Rotate(Vector3.forward, rotationStep);

        //transform.LookAt(targetPosition, Vector3.down);
        LookAt2D(TargetPosition);
        Debug.Log("looking at" + TargetPosition);


        //move along the forward vector using rigidbody2D
        rb.velocity = transform.up * movementSpeed;

        //transform.Translate(transform.up * movementSpeed);

    }

    private void Avoid() //  a seek with rotation to target but onlu moving along forward vector
    {

        //calculate direction to target
        Vector2 direction = (TargetPosition1 - transform.position).normalized;
        // calculate the angle to rotate towards the target
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90.0f;

        ////smoothly rotate towards the target
        //float angleDifference = Mathf.DeltaAngle(targetAngle, transform.eulerAngles.z);
        //float rotationStep = rotationSpeed * Time.deltaTime;
        //float rotationAmount = Mathf.Clamp(angleDifference, -rotationStep, rotationStep);
        //transform.Rotate(Vector3.forward, rotationStep);

        //transform.LookAt(targetPosition, Vector3.down);
        LookAt2D1(TargetPosition1);
        Debug.Log("looking at" + TargetPosition1);


        //move along the forward vector using rigidbody2D
        rb.velocity = transform.up * movementSpeed;

        //transform.Translate(transform.up * movementSpeed);

    }

    void LookAt2D(Vector3 target)
    {
        Vector3 lookDirection = target - transform.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis((angle - 90), Vector3.forward);
    }
    
    void LookAt2D1(Vector3 target)
    {
        Vector3 lookDirection = target - transform.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis((angle + 90), Vector3.forward);
    }
}

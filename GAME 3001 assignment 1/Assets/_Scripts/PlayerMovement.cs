using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AgentMovement : Objective
{

    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (TargetPosition != null)
        {
            //Seek();
            SeekForward();
        }

    }

    private void SeekForward() //  a seek with rotation to target but onlu moving along forward vector
    {

        //calculate direction to target
        Vector2 direction = (TargetPosition - transform.position).normalized;
        // calculate the angle to rotate towards the target
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90.0f;

        //smoothly rotate towards the target
        float angleDifference = Mathf.DeltaAngle(targetAngle, transform.eulerAngles.z);
        float rotationStep = rotationSpeed * Time.deltaTime;
        float rotationAmount = Mathf.Clamp(angleDifference, -rotationStep, rotationStep);
        transform.Rotate(Vector3.forward, rotationAmount);

        //move along the forward vector using rigidbody2D
        //rb.velocity = transform.up * movementSpeed;

        transform.Translate(transform.up / movementSpeed);

    }
}

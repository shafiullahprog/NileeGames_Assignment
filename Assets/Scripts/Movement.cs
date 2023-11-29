using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed, jumpSpeed;
    [SerializeField] float sideSpeed, deathValue;
    Rigidbody playerRigidBody;
    GameManager gameManager;
    bool isPlayerGrounded;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ForwardMovement();
        LeftRightMovement();
        Jump();

        if(transform.position.y < deathValue)
        {
            gameManager.GameOver();
        }
    }

    public void ForwardMovement()
    {
        //playerRigidBody.velocity = Vector3.forward * speed;
        playerRigidBody.AddForce(0, 0, speed * Time.deltaTime);
    }

    public void LeftRightMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerRigidBody.AddForce(-sideSpeed * Time.deltaTime,0,0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerRigidBody.AddForce(sideSpeed * Time.deltaTime, 0, 0);
        }
    }


    public void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space)  && isPlayerGrounded)
        {
            playerRigidBody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            isPlayerGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isPlayerGrounded = true;
        }
    }

}

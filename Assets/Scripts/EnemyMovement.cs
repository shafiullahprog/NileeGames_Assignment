using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody enemyRigidBody;
    [SerializeField] float enemySpeed;

    private void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        enemyRigidBody.AddForce(0, 0, -enemySpeed * Time.deltaTime);
        //transform.position += Vector3.back * enemySpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Out");
        }
    }
}

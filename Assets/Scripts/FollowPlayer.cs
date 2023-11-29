using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;

    private void LateUpdate()
    {
        if (gameObject.tag == "Ground")
        {
            transform.position = new Vector3(0, 0, target.transform.position.z) + offset;
        }
        else
        {
            transform.position = target.transform.position + offset;
        }
    }

}

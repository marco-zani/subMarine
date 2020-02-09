using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Behaviour : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float speed;


    void FixedUpdate()
    {

        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, speed);
        transform.position = new Vector3(smoothPosition.x, smoothPosition.y, smoothPosition.z);
    }

   

}

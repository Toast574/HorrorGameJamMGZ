using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   // public Transform playertrans;
  //  void Update()
  //  {
   //     gameObject.transform.LookAt(playertrans.position);
  //  }


    public Transform target;
    public float speed = 5f; // Adjust this value for speed

    void Update()
    {
        if (target == null)
            return;

        Vector3 direction = target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed * Time.deltaTime);
    }
}


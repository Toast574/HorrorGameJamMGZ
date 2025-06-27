using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
   public Transform FirePoint;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Shooting();
        }
    }

    public void Shooting()
    {
        RaycastHit hit;

        if (Physics.Raycast(FirePoint.position, transform.TransformDirection(Vector3.forward), out hit, 100))
        {
            Debug.DrawRay(FirePoint.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            // Get the script from the hit object
            EnemyAi targetScript = hit.collider.gameObject.GetComponent<EnemyAi>();

            // Check if the script exists and call the function
            if (targetScript != null)
            {
                targetScript.TakeDamage(1); // Call the desired function on the hit object
            }
        }
    }
}

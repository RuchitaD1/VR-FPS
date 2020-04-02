using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 hitPoint = new Vector3(0, 1, 0);

    void Update()
    {
        // This statement checks to see if the primary Fire button has been pressed
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    // This function casts a ray to determine when/if a zombie has been hit
    // on a successful hit the value of z will be the name of the GameObject
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position,
        Camera.main.transform.forward, out hit))
        {
            
            hitPoint = hit.point;
            
            ZombieController z =
            hit.collider.GetComponent<ZombieController>();
            if (z != null)
                z.Die();

        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject zombiePrefab;
    Vector3 hitPoint = new Vector3(1, 1, 0);
    GameObject zombie;
    public GameObject Weapon;

    void Start() {

        zombie = Instantiate(zombiePrefab);
    }


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
                
        // We set the origin of the ray 
        // to gun barrel position so it 
        // doesn't start at the camera position
        
        RaycastHit hit;
        if (Physics.Raycast(Weapon.transform.position, Weapon.transform.forward, out hit))
        {
            
            hitPoint = hit.point;
            
            ZombieController z =
            hit.collider.GetComponent<ZombieController>();
            if (z != null)
            {
                z.Die();
                
            }

        }
    }

}

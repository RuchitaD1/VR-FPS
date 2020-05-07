using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public GameObject zombiePrefab;
    Vector3 hitPoint = new Vector3(1, 1, 0);
    GameObject zombie;
    public GameObject Weapon;
    public Camera gunCamera;
public Transform gunEnd;
private LineRenderer laserLine;
public float weaponRange = 50f; 
    void Start() {
        laserLine = GetComponent<LineRenderer>();

        zombie = Instantiate(zombiePrefab);
    }


    void Update()
    {
        // This statement checks to see if the primary Fire button has been pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
laserLine.enabled = true;
            Shoot();
        }
if (Input.GetKeyUp(KeyCode.R))
        {
            laserLine.enabled = false;
        }
//
    }

    // This function casts a ray to determine when/if a zombie has been hit
    // on a successful hit the value of z will be the name of the GameObject
    void Shoot()
    {
//laserLine.enabled = true;
    Vector3 rayOrigin = gunCamera.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));
    RaycastHit hit;

            // Set the start position for our visual effect for our laser to the position of gunEnd
            laserLine.SetPosition (0, gunEnd.position);
                
        // We set the origin of the ray 
        // to gun barrel position so it 
        // doesn't start at the camera position
        
        
        if (Physics.Raycast(rayOrigin, gunCamera.transform.forward, out hit, weaponRange))
        {
            
            hitPoint = hit.point;
            laserLine.SetPosition (1, hit.point);
            ZombieController z =
            hit.collider.GetComponent<ZombieController>();
            if (z != null)
            {
                z.Die();
                
            }

        }
else
            {
                // If we did not hit anything, set the end of the line to a position directly in front of the camera at the distance of weaponRange
                laserLine.SetPosition (1, rayOrigin + (gunCamera.transform.forward * weaponRange));
            }

    }

}

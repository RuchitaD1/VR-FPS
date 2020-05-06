using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage;
    // This variable determines 
    // how fast the weapon can shoot
    public float fireRate; 
    // This variable determines 
    // how far the bullet fly when fired
    public float fireLength; 
    // This variable determines 
    // how fast the weapon reload
    public float reloadTime; 
    // A reference to the 
    // weapon's gun barrel game object
    public Transform gunBarrel; 
    // Start is called before the first frame update
        public int currentBullets; 
    // The number of bullets 
    // this weapon CAN have
    public int maxBullets = 30; 

    void Start() {
        // We set the weapon to 
        // start with a full magazin
        currentBullets = maxBullets;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

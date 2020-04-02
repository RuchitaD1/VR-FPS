using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator _animator;
    private Rigidbody _rigidbody;
    private CapsuleCollider _collider;
    private GameObject _target;
    private GameObject _zombie;

    public float moveSpeed = 1.5f;
    private bool _isDead, _isAttacking;

    private void Awake()
    {
        // Awake occurs when a zombie is spawned. At that time we capture    prefab components
        // for use in movement, collision, attack and death
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();
        
       _zombie = GetComponent<GameObject>();

    }
    private void Update()
    {
        // During each frame we rotate the zombie toward the player. This   allows for player
        // movement during runtime
        _target = GameObject.FindGameObjectWithTag("Player");
        Vector3 targetPostition = new Vector3(
      _target.transform.position.x,
        0f, _target.transform.position.z);
        transform.LookAt(targetPostition);
    }

    private void FixedUpdate()
    {
        // In FixedUpdate we move the prefab, if it is alive and not   
       // attacking
      if (!_isDead && !_isAttacking)
        {
            _rigidbody.velocity = (_target.transform.position -
            transform.position).normalized * moveSpeed;
        }
    }
    public void Die()
    {
        // Once we have decided to kill off a zombie, we must set its local
        // variables to their default values.
        _rigidbody.velocity = Vector3.zero;
        _collider.enabled = false;
        _isDead = true;
        _animator.SetBool("Death", true);
        _animator.SetInteger("DeathAnimationIndex", Random.Range(0, 3));
        StartCoroutine(DestroyThis());
    }

    IEnumerator DestroyThis()
    {
    // Before destroying the prefab, we will wait until it's animation   
    //is complete
    // the value listed here is the length of the walk cycle
    yield return new WaitForSeconds(1.5f);
        Destroy(_zombie);
    }
}
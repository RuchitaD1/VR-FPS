using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    private void OnCollisionEnter(Collision other)
    {
        // This code will initiate an attack when the player GameObject intersects
        // with a zombie collider
        if (other.collider.tag == "Player" && !_isDead)
        {
            _isAttacking = true;
            _animator.SetBool("Attack", true);
            other.collider.GetComponent<PlayerHealth>().TakeDamage(10);
            if (other.collider.GetComponent<PlayerHealth>().PlayerDead())
            {
                StartCoroutine(PlayerDie());

            }


        }
    }

    IEnumerator PlayerDie()
    {

        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("terrain");

    }

    public void increaseSpeed()
	{
        moveSpeed += moveSpeed*0.25f;
	}






}

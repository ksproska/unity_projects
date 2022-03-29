using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float speed = 2f;
    private Rigidbody2D body;
    private Rigidbody2D throwable;
    public Animator animator;

    [SerializeField]
    public AudioSource runningSoundSource;
    public AudioSource throwingSoundSource;
    private int collisions;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        throwable = Resources.Load("Throwable", typeof(Rigidbody2D)) as Rigidbody2D;
        body.freezeRotation = true;
        runningSoundSource.enabled = true; //?????
    }

    private void OnCollisionEnter2D(Collision2D other) {
        collisions += 1;
    }

    private void OnCollisionExit2D(Collision2D other) {
        collisions -= 1;
    }
 
    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            body.velocity = new Vector2(speed, body.velocity.y);
        if (Input.GetKey(KeyCode.LeftArrow))
            body.velocity = new Vector2(-speed, body.velocity.y);
    }

    public void Jump(InputAction.CallbackContext context) {
        // Debug.Log(context.phase);
        if (context.performed && collisions > 0)
            body.AddForce(new Vector2(0, 1) * 400f);
    }
    
    public void Throw(InputAction.CallbackContext context) {
        // Debug.Log(context.phase);
        if (context.performed) {
            var throwed = Instantiate(throwable) as Rigidbody2D;
            animator.SetBool("Throws", true);
            StartCoroutine(changeAnimationNormal(0.5f));
            PlayThrowingSound();
        }
    }

    public void PlayThrowingSound() {
        throwingSoundSource.Play();
    }

    private void FliperCheck() {
        if (body.velocity.x < -0.01) {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (body.velocity.x > 0.01) {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void FixedUpdate()
    {
        FliperCheck();
        if(body.velocity.x == 0 && runningSoundSource.isPlaying) {
            runningSoundSource.Stop();
        }
        else if(body.velocity.x != 0 && !runningSoundSource.isPlaying)
        {
            runningSoundSource.Play();
        }
        animator.SetFloat("SpeedUp", body.velocity.y);
        animator.SetFloat("SpeedBack", Mathf.Abs(body.velocity.x));
    }

    IEnumerator changeAnimationNormal(float sec) {
        yield return new WaitForSeconds(sec);
        animator.SetBool("Throws", false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyHandler : MonoBehaviour
{
    private int hitTimes = 5;
    public Animator animator;
    private Rigidbody2D body;
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        body.freezeRotation = true;

    }

    void FixedUpdate()
    {
        if (body.velocity.x < -0.01)
         {
             transform.localRotation = Quaternion.Euler(0, 180, 0);
         }
         else if (body.velocity.x > 0.01)
         {
             transform.localRotation = Quaternion.Euler(0, 0, 0);
         }
         animator.SetFloat("SpeedBack", Mathf.Abs(body.velocity.x));
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Throwed") {
            hitTimes -= 1;
            // Debug.Log(hitTimes);
            animator.SetBool("IsHit", true);
            StartCoroutine(notHit(1f));
            if(hitTimes == 0) {
                animator.SetBool("IsHit", true);
                Destroy(gameObject, 1f);
            }
        }
    }

    IEnumerator notHit(float sec) {
        yield return new WaitForSeconds(sec);
        animator.SetBool("IsHit", false);
    }
}

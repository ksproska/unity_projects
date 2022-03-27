using System.Collections.Generic;
using UnityEngine;
using System.Collections;
// using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float speed = 2f;
    private Rigidbody2D body;
    private Rigidbody2D throwable;
    public Animator animator;

    // private void OnEnable() {
    //     gameplayActions.Enable();
    // }

    // private void OnDisable() {
    //     gameplayActions.Disable();
    // }
 
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        throwable = Resources.Load("Throwable", typeof(Rigidbody2D)) as Rigidbody2D;
        body.freezeRotation = true;
    }
 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            body.AddForce(new Vector2(0, 1) * 400f);
        if (Input.GetKey(KeyCode.RightArrow))
            body.velocity = new Vector2(speed, body.velocity.y);
        if (Input.GetKey(KeyCode.LeftArrow))
            body.velocity = new Vector2(-speed, body.velocity.y);
        if (Input.GetButtonDown("Fire1")) { //left ctrl
            var throwed = Instantiate(throwable) as Rigidbody2D;
            animator.SetBool("Throws", true);
            StartCoroutine(changeAnimationNormal(0.5f));
        }
        animator.SetFloat("SpeedUp", body.velocity.y);
        animator.SetFloat("SpeedBack", Mathf.Abs(body.velocity.x));
    }

    IEnumerator changeAnimationNormal(float sec) {
        yield return new WaitForSeconds(sec);
        animator.SetBool("Throws", false);
    }
}

using UnityEngine;
using System.Collections;

public class JumpAndRunController : MonoBehaviour
{
    public Animator Animator;
    public GameObject Armature;
    public Rigidbody Rigidbody;
    public float WalkSpeed;
    public float JumpHeight;
    public float MaxRotation;

    private float inputDelay = 0.1f;
    private bool isGrounded = false;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(horizontalInput) > inputDelay)
        {
            Armature.transform.rotation = Quaternion.Euler(270, 180 + MaxRotation * -horizontalInput, Armature.transform.rotation.y);
            transform.transform.Translate(new Vector3(-horizontalInput * WalkSpeed * Time.deltaTime, 0, 0));
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            StartCoroutine(Jump());
            Animator.SetTrigger("Jump");
        }
	}

    private IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.4f);
        Rigidbody.AddForce(Vector3.up * JumpHeight, ForceMode.VelocityChange);
        isGrounded = false;
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        isGrounded = true;
    }

}

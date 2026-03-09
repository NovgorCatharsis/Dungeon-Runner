using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float dashPower;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip potionSound;
    [SerializeField] private AudioClip crashSound;
    [SerializeField] private AudioClip dashSound;

    public event Action BarrierCollision;

    private Rigidbody rigidbody;
    private Vector3 movement;

    private float transformZ;
    private int position; //0 = left, 1 = middle, 2 = right

    private void Awake()
    {
        position = 1;
        rigidbody = GetComponent<Rigidbody>();
    }

    //public void FixedUpdate()
    //{
    //    transformZ = rigidbody.transform.position.z;
    //    //|| (position == 1 && transformZ <= -1.5f && transformZ >= -2.5f)
    //    if ((position == 0 && transformZ >= -2) || (position == 2 && transformZ <= -6))
    //    {
    //        rigidbody.linearVelocity = Vector3.zero;
    //    }
    //}


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Potion"))
        {
            AudioSource.PlayClipAtPoint(potionSound, transform.position, 1f);
            Destroy(collision.gameObject);
            GetComponent<Score>().UpdateUI(1);
        }
        else if (collision.gameObject.CompareTag("Barrier"))
        {
            AudioSource.PlayClipAtPoint(crashSound, transform.position, 1f);
            animator.SetTrigger("Fell");
            BarrierCollision?.Invoke();
        }
    }


    public void DashLeft()
    {
        if (position == 0) return;
        animator.SetTrigger("DashedLeft");

        AudioSource.PlayClipAtPoint(dashSound, transform.position, 0.6f);
        movement = new Vector3(0, 0, 1);
        //rigidbody.linearVelocity = movement * dashPower;
        rigidbody.AddForce(movement * dashPower);
        position -= 1;
    }

    public void DashRight()
    {
        if (position == 2) return;
        animator.SetTrigger("DashedRight");

        AudioSource.PlayClipAtPoint(dashSound, transform.position, 0.6f);
        movement = new Vector3(0, 0, -1);
        //rigidbody.linearVelocity = movement * dashPower;
        rigidbody.AddForce(movement * dashPower);
        position += 1;
    }
}


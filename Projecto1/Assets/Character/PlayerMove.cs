using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private Animator animator;
    private Rigidbody rb;
    public float Speed;
    Vector3 LookPos;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        SetupAnimator();
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);

        rb.AddForce((movement * Speed / Time.deltaTime)/5);

        animator.SetFloat("Forward", vertical);
        animator.SetFloat("Turn", horizontal);
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100))
        {
            LookPos = hit.point;
        }

        Vector3 lookDir = LookPos - transform.position;
        lookDir.y = 0;

        transform.LookAt(transform.position + lookDir, Vector3.up);

    }

    void SetupAnimator()
    {
        animator = GetComponent<Animator>();

        foreach (var childAnimator in GetComponentsInChildren<Animator>())
        {
            animator.avatar = childAnimator.avatar;
            Destroy(childAnimator);
            break;
        }
    }

}

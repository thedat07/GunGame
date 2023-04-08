using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public Animator animator;
    public float speed = 5f;
    public VariableJoystick m_VariableJoystick;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Store user input as a movement vector
        Vector3 m_Input = new Vector3(m_VariableJoystick.Horizontal, 0, m_VariableJoystick.Vertical);
        animator.SetFloat("Speed", m_Input.magnitude);
        transform.LookAt(CheckObject() + transform.position, Vector3.up);
        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * speed);
    }

    Vector3 CheckObject()
    {
        int maxColliders = 1;
        Collider[] hitColliders = new Collider[maxColliders];
        int numColliders = Physics.OverlapSphereNonAlloc(transform.position, 5, hitColliders, LayerMask.GetMask("Enemy"));
        if (numColliders != 0)
        {
            animator.SetBool("Attack", true);
            return hitColliders[0].transform.position - transform.position;
        }
        else
        {
            animator.SetBool("Attack", false);
            return new Vector3(m_VariableJoystick.Horizontal, 0, m_VariableJoystick.Vertical);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLazy : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 1f;

    private Vector2 fwd_rht = Vector2.zero;
    private bool jump = false;
    // Update is called once per frame 
    void Update()
    {
        fwd_rht.y = (EasyInput.GetInput("fwd") ? 1f : 0f) - (EasyInput.GetInput("bwd") ? 1f : 0f);
        fwd_rht.x = (EasyInput.GetInput("rht") ? 1f : 0f) - (EasyInput.GetInput("lft") ? 1f : 0f);

        if (EasyInput.GetInputDown("jmp"))
        {
            jump = true;
        }

    }

    private void FixedUpdate()
    {
        if (jump)
        {
            jump = false;
            rb.AddForce(new Vector3(0f, 5f, 0f), ForceMode.Impulse);
        }
        rb.AddForce(new Vector3(fwd_rht.x, 0f, fwd_rht.y).normalized * force);
    }
}

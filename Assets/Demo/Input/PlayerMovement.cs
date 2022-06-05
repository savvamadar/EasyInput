using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 1f;
    public int player = 0;


    // Update is called once per frame 

    private Vector2 fwd_rht = Vector2.zero;
    private bool jump = false;
    // Update is called once per frame 
    void Update()
    {
        fwd_rht.y = (EasyInput.Player(player).GetInput("fwd") ? EasyInput.Player(player).GetInputStrength("fwd") : 0f) - (EasyInput.Player(player).GetInput("bwd") ? EasyInput.Player(player).GetInputStrength("bwd") : 0f);
        fwd_rht.x = (EasyInput.Player(player).GetInput("rht") ? EasyInput.Player(player).GetInputStrength("rht") : 0f) - (EasyInput.Player(player).GetInput("lft") ? EasyInput.Player(player).GetInputStrength("lft") : 0f);

        if (EasyInput.Player(player).GetInputDown("jmp"))
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

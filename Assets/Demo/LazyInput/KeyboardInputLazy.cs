using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputLazy : MonoBehaviour
{
    public KeyCode forward;
    public KeyCode backward;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(forward))
        {
            EasyInput.SetInput("fwd", Time.deltaTime, 1f);
        }
        if (Input.GetKey(backward))
        {
            EasyInput.SetInput("bwd", Time.deltaTime, 1f);
        }
        if (Input.GetKey(left))
        {
            EasyInput.SetInput("lft", Time.deltaTime, 1f);
        }
        if (Input.GetKey(right))
        {
            EasyInput.SetInput("rht", Time.deltaTime, 1f);
        }
        if (Input.GetKey(jump))
        {
            //Debug.Log("jmp lazy");
            EasyInput.SetInput("jmp", Time.deltaTime, 1f);
        }
    }
}

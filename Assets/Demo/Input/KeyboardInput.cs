using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{

    public int player = 0;

    public KeyCode forward;
    public KeyCode backward;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    void Update()
    {
        if (Input.GetKey(forward))
        {
            EasyInput.Player(player).SetInput("fwd", Time.unscaledDeltaTime, Time.frameCount, 1f);
        }
        if (Input.GetKey(backward))
        {
            EasyInput.Player(player).SetInput("bwd", Time.unscaledDeltaTime, Time.frameCount, 1f);
        }
        if (Input.GetKey(left))
        {
            EasyInput.Player(player).SetInput("lft", Time.unscaledDeltaTime, Time.frameCount, 1f);
        }
        if (Input.GetKey(right))
        {
            EasyInput.Player(player).SetInput("rht", Time.unscaledDeltaTime, Time.frameCount, 1f);
        }
        if (Input.GetKey(jump))
        {
            EasyInput.Player(player).SetInput("jmp", Time.unscaledDeltaTime, Time.frameCount, 1f);
        }
    }
}

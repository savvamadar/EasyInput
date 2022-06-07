using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour
{
    private int xboxController = -1;
    public int player = 0;
    void Start()
    {
        for (int i = 0; i < Input.GetJoystickNames().Length; i++)
        {
            if (Input.GetJoystickNames()[i].ToLower().Contains("xbox"))
            {
                xboxController = i+1;
                return;
            }
        }

        Debug.Log("No xbox controller found");
    }

    void Update()
    {
        if(xboxController < 0)
        {
            return;
        }


        //Have to add Joy1Horizontal and Joy1Verical in Edit > Project Settings > Input Manager > Axes
        //horizontal
        float h = Input.GetAxis("Joy" + xboxController + "Horizontal");
        if(h < 0)
        {
            EasyInput.Player(player).SetInput("lft", Time.unscaledDeltaTime, Time.frameCount, Mathf.Abs(h));
        }
        else if(h > 0)
        {
            EasyInput.Player(player).SetInput("rht", Time.unscaledDeltaTime, Time.frameCount, h);
        }

        //vertical
        float v = Input.GetAxis("Joy" + xboxController + "Vertical");
        if (v < 0)
        {
            EasyInput.Player(player).SetInput("fwd", Time.unscaledDeltaTime, Time.frameCount, Mathf.Abs(v));
        }
        else if (v > 0)
        {
            EasyInput.Player(player).SetInput("bwd", Time.unscaledDeltaTime, Time.frameCount, v);
        }

        //jump
        if (Input.GetKey("joystick "+xboxController+" button 0"))
        {
            EasyInput.Player(player).SetInput("jmp", Time.unscaledDeltaTime, Time.frameCount, 1f);
        }
    }
}

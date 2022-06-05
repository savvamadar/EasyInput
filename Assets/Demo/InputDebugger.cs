using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDebugger : MonoBehaviour
{
    // Start is called before the first frame update
    public int player = 0;
    string[] key_strings = new string[] { "fwd", "bwd", "lft", "rht", "jmp" };

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < key_strings.Length; i++)
        {
            if (EasyInput.Player(player).GetInputDown(key_strings[i]))
            {
                Debug.Log("Player " + player + ") " + key_strings[i] + " - Pressed");
            }
            if (EasyInput.Player(player).GetInputUp(key_strings[i]))
            {
                Debug.Log("Player " + player + ") " + key_strings[i] + " - Released - Held for: " + EasyInput.Player(player).GetInputTime(key_strings[i]));
            }
        }
    }
}

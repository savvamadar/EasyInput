using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInput
{
    public float key_down_time = 0f;
    public float key_up_time = 0f;

    public int key_down = -1;
    public int key_up = -1;

    public float key_time = 0f;
    public float key_strength = 0f;

    public bool marked_for_release = false;

    public void adjust_input(float time, int frame, float strength)
    {
        if (time == 0f)
        {
            if (key_down >= 0)
            {
                key_down = -1;

                key_up = frame;
                key_up_time = Time.realtimeSinceStartup;

                key_time = 0f;
                key_strength = 0f;
                marked_for_release = true;
            }
        }
        else
        {
            if (key_time == 0f)
            {
                key_down = frame;
                key_down_time = Time.realtimeSinceStartup;
            }
            key_time += time;
            key_strength = strength;
            marked_for_release = false;
        }

    }
}

public class InputManager
{

    Dictionary<string, KeyInput> map = new Dictionary<string, KeyInput>();

    //Any script that touches any of the "SetInput" methods should go above "Default Time" but below "EasyInput"
    public void SetInput(string key, float deltaTime, int frame, float strength)
    {
        if (!map.ContainsKey(key))
        {
            map[key] = new KeyInput();
        }
        map[key].adjust_input(deltaTime, frame, strength);
    }

    public bool GetInputDown(string key)
    {
        if (!map.ContainsKey(key))
        {
            map[key] = new KeyInput();
        }
        return map[key].key_down == Time.frameCount;
    }

    public bool GetInputUp(string key)
    {
        if (!map.ContainsKey(key))
        {
            map[key] = new KeyInput();
        }
        return map[key].key_up == Time.frameCount;
    }

    public bool GetInput(string key)
    {
        if (!map.ContainsKey(key))
        {
            map[key] = new KeyInput();
        }
        return map[key].key_down >= 0;
    }

    public float GetInputStrength(string key)
    {
        if (!map.ContainsKey(key))
        {
            map[key] = new KeyInput();
        }
        return map[key].key_strength;
    }

    public float GetInputTime(string key)
    {
        if (!map.ContainsKey(key))
        {
            map[key] = new KeyInput();
        }
        return (map[key].key_down_time > map[key].key_up_time) ? (Time.realtimeSinceStartup - map[key].key_down_time) : (map[key].key_up_time - map[key].key_down_time);
    }

    public void ReleaseKeys()
    {
        foreach (var kv in map)
        {
            if (map[kv.Key].marked_for_release)
            {
                map[kv.Key].adjust_input(0, Time.frameCount, 0);
            }
        }
    }

    public void MarkKeys()
    {
        foreach (var kv in map)
        {
            if (map[kv.Key].key_time > 0f && map[kv.Key].key_up <= Time.frameCount)
            {
                map[kv.Key].marked_for_release = true;
            }
        }
    }

    public void ResetInputs()
    {
        foreach (var kv in map)
        {
            map[kv.Key].marked_for_release = true;
            map[kv.Key].adjust_input(0, Time.frameCount, 0);
        }
    }
}

//Remember to Edit > Project Settings > Script Execution Order
//and add EasyInput - make sure that it is above "Default Time"
//
//Any script that touches any of the "SetInput" methods should go above "Default Time" but below "EasyInput"
public class EasyInput : MonoBehaviour
{
    public static Dictionary<int, InputManager> _inputs = new Dictionary<int, InputManager>();

    public static EasyInput instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }


    public void Update()
    {
        foreach (var i in _inputs)
        {
            i.Value.ReleaseKeys();
            i.Value.MarkKeys();
        }
    }

    public static InputManager Player(int i)
    {
        if (!_inputs.ContainsKey(i))
        {
            _inputs[i] = new InputManager();
        }
        return _inputs[i];
    }

    public static bool GetInputDown(string key)
    {
        return Player(0).GetInputDown(key);
    }

    public static bool GetInputUp(string key)
    {
        return Player(0).GetInputUp(key);
    }

    public static bool GetInput(string key)
    {
        return Player(0).GetInput(key);
    }

    public static float GetInputTime(string key)
    {
        return Player(0).GetInputTime(key);
    }

    public static float GetInputStrength(string key)
    {
        return Player(0).GetInputStrength(key);
    }

    //Any script that touches any of the "SetInput" methods should go above "Default Time" but below "EasyInput"
    public static void SetInput(string key, float deltaTime, int frame, float strength)
    {
        Player(0).SetInput(key, deltaTime, frame, strength);
    }

    public static void ResetInputs()
    {
        Player(0).ResetInputs();
    }


}

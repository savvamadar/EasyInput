using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInput
{
    public bool key_down = false;
    public bool key_up = false;
    public float key_time = 0f;
    public float key_strength = 0f;
    public bool marked_for_release = false;

    public void adjust_input(float time, float strength)
    {
        if(time == 0)
        {
            if(key_up == true)
            {
                key_up = false;
                key_time = 0f;
                key_strength = 0f;
            }
            if (key_time > 0f)
            {
                key_up = true;
            }
        }
        else
        {
            if (key_time == 0f)
            {
                key_down = true;
            }
            else
            {
                key_down = false;
            }
            key_strength = strength;
            key_time += time;
            marked_for_release = false;
        }
    }
}

public class InputManager
{

    Dictionary<string, KeyInput> map = new Dictionary<string, KeyInput>();

    public void SetInput(string key, float deltaTime, float strength)
    {
        if (!map.ContainsKey(key))
        {
            map[key] = new KeyInput();
        }
        map[key].adjust_input(deltaTime, strength);
    }

    public bool GetInputDown(string key)
    {
        if (!map.ContainsKey(key))
        {
            map[key] = new KeyInput();
        }
        return map[key].key_down;
    }

    public bool GetInputUp(string key)
    {
        if (!map.ContainsKey(key))
        {
            map[key] = new KeyInput();
        }
        return map[key].key_up;
    }

    public bool GetInput(string key)
    {
        return (!GetInputUp(key)) && (GetInputTime(key) > 0f);
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
        return map[key].key_time;
    }

    public void ReleaseKeys()
    {
        foreach (var kv in map)
        {
            if (map[kv.Key].marked_for_release)
            {
                map[kv.Key].adjust_input(0, 0);
            }
        }
    }

    public void MarkKeys()
    {
        foreach(var kv in map)
        {
            if (map[kv.Key].key_time > 0f)
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
            map[kv.Key].adjust_input(0, 0);
        }
    }
}

public class EasyInput : MonoBehaviour
{
    public static List<InputManager> _inputs = new List<InputManager>();

    public static EasyInput instance;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(this);
        }
    }


    public void LateUpdate()
    {
        for (int i = 0; i < _inputs.Count; i++)
        {
            _inputs[i].ReleaseKeys();
            _inputs[i].MarkKeys();
        }
    }

    public static InputManager Player(int i)
    {
        while(i >= _inputs.Count)
        {
            _inputs.Add(new InputManager());
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

    public static void SetInput(string key, float deltaTime, float strength)
    {
        Player(0).SetInput(key, deltaTime, strength);
    }

    public static void ResetInputs()
    {
        Player(0).ResetInputs();
    }


}

using UnityEngine;

public static class MInput
{
    public static bool Input(this string name, string key) => name == key;

    /// <summary>
    /// Check if user is pressing, holding or releasing a key.
    /// </summary>
    public static bool HoldKey(KeyCode key) => UnityEngine.Input.GetKey(key);
    public static bool PressKey(KeyCode key) => UnityEngine.Input.GetKeyDown(key);
    public static bool ReleaseKey(KeyCode key) => UnityEngine.Input.GetKeyUp(key);

    /// <summary>
    /// Check if user is pressing, holding or releasing W, A, S, D or Up, Down, Left, Right arrows. 
    /// </summary>
    public static bool HoldMovingKey()
    {
        if (HoldKey(KeyCode.A) || HoldKey(KeyCode.S) || 
            HoldKey(KeyCode.D) || HoldKey(KeyCode.W)) return true;

        if (HoldKey(KeyCode.LeftArrow) || HoldKey(KeyCode.RightArrow) || 
            HoldKey(KeyCode.UpArrow) || HoldKey(KeyCode.DownArrow)) return true;

        return false;
    }
    public static bool PressMovingKey()
    {
        if (PressKey(KeyCode.A) || PressKey(KeyCode.S) ||
            PressKey(KeyCode.D) || PressKey(KeyCode.W)) return true;

        if (PressKey(KeyCode.LeftArrow) || PressKey(KeyCode.RightArrow) ||
            PressKey(KeyCode.UpArrow) || PressKey(KeyCode.DownArrow)) return true;

        return false;
    }
    public static bool ReleaseMovingKey()
    {
        if (ReleaseKey(KeyCode.A) || ReleaseKey(KeyCode.S) ||
            ReleaseKey(KeyCode.D) || ReleaseKey(KeyCode.W)) return true;

        if (ReleaseKey(KeyCode.LeftArrow) || ReleaseKey(KeyCode.RightArrow) ||
            ReleaseKey(KeyCode.UpArrow) || ReleaseKey(KeyCode.DownArrow)) return true;

        return false;
    }

    /// <summary>
    /// Check if user is pressing, holding or releasing mouse buttons.
    /// </summary>
    public static bool HoldMouse(int button = -1)
    {
        if (button == -1) return UnityEngine.Input.GetMouseButton(0) || UnityEngine.Input.GetMouseButton(1) || UnityEngine.Input.GetMouseButton(2);
        else return UnityEngine.Input.GetMouseButton(button);
    }
    public static bool PressMouse(int button = -1)
    {
        if (button == -1) return UnityEngine.Input.GetMouseButtonDown(0) || UnityEngine.Input.GetMouseButtonDown(1) || UnityEngine.Input.GetMouseButtonDown(2);
        else return UnityEngine.Input.GetMouseButtonDown(button);
    }
    public static bool ReleaseMouse(int button = -1)
    {
        if (button == -1) return UnityEngine.Input.GetMouseButtonUp(0) || UnityEngine.Input.GetMouseButtonUp(1) || UnityEngine.Input.GetMouseButtonUp(2);
        else return UnityEngine.Input.GetMouseButtonUp(button);
    }

    /// <summary>
    /// Check if user is pressing, holding or releasing space key.
    /// </summary>
    public static bool HoldSpace() => HoldKey(KeyCode.Space);
    public static bool PressSpace() => PressKey(KeyCode.Space);
    public static bool ReleaseSpace() => ReleaseKey(KeyCode.Space);
}
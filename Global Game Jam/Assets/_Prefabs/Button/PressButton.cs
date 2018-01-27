using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour {

    public string message;
    public int value;

	void OnMouseDown()
    {
        SendMessageUpwards(message, value);
    }
}

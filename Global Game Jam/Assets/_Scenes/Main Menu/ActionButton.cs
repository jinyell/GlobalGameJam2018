using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionButton : MonoBehaviour {

    public float rotateAmount = 20f;
    public float upScale = 1.2f;

    Vector3 scale;
    Vector3 rot; 
    public UnityEvent action;
    public bool parent = true;
    Transform t;

    void Start()
    {
        if (parent)
            t = transform.parent;
        else
            t = transform;
        scale = t.localScale;
        rot = t.localEulerAngles;
    }

	void OnMouseEnter()
    {
        t.localScale = scale * upScale;
        t.localEulerAngles = rot + new Vector3(0, 0, rotateAmount);
    }

    void OnMouseExit()
    {
        t.localScale = scale;
        t.localEulerAngles = rot;
    }

    void OnMouseDown()
    {
        action.Invoke();
    }
}

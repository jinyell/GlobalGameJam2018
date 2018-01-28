using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionButton : MonoBehaviour {

    public float rotateAmount = 20f;

    Vector3 rot; 
    public UnityEvent action;
    public bool parent = true;
    Transform t;

    public void HoverAnimate()
    {
        this.transform.localEulerAngles = rot + new Vector3(0, 0, rotateAmount);
    }

    public void GeneralState()
    {
        this.transform.localEulerAngles = rot;
    }

    void Start()
    {
        if (parent)
            t = transform.parent;
        else
            t = transform;
        rot = t.localEulerAngles;
    }

	void OnMouseEnter()
    {
        t.localEulerAngles = rot + new Vector3(0, 0, rotateAmount);
    }

    void OnMouseExit()
    {
        t.localEulerAngles = rot;
    }

    void OnMouseDown()
    {
        action.Invoke();
    }
}

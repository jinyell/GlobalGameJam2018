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

    void Start()
    {
        scale = transform.parent.localScale;
        rot = transform.parent.localEulerAngles;
    }

	void OnMouseEnter()
    {
        transform.parent.localScale = scale * upScale;
        transform.parent.localEulerAngles = rot + new Vector3(0, 0, rotateAmount);
    }

    void OnMouseExit()
    {
        transform.parent.localScale = scale;
        transform.parent.localEulerAngles = rot;
    }

    void OnMouseDown()
    {
        action.Invoke();
    }
}

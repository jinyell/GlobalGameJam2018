using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashingImage : MonoBehaviour {
    public float speed= 0.1f;
    float count = 0;
    public Color initial;
    public Color final;
    public float alpha = 1;
    Image i;

    void Start()
    {
        i = GetComponent<Image>();
    }

	void Update () {
        Color temp = Color.Lerp(initial, final, count);
        temp.a = alpha;
        i.color = temp;
        if(count > 1)
        {
            count = 0;
        }
        count += speed;
	}
}

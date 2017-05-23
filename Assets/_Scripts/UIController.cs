using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public List<Image> buttons;
    [Tooltip("Values in screen %")]
    public float sizeX, offset, sizeY;


    [Tooltip("1st button position")]
    public Vector2 startPosition;
	// Use this for initialization
	void Start () {
        buttons.AddRange( this.GetComponentsInChildren<Image>());
        sizeX *= 0.01f; //% to 1/100
        offset *= 0.01f; //% to 1/100
        sizeY *= 0.01f;
        configureUI();
    }
	
    void configureUI()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            float x = startPosition.x + (sizeX * i);
            buttons[i].GetComponent<RectTransform>().anchorMin = new Vector2((float)(x + (i > 0 ? offset : 0)), startPosition.y);
            buttons[i].GetComponent<RectTransform>().anchorMax = new Vector2((float)(x + sizeX), (float)sizeY);
        }
    }

}

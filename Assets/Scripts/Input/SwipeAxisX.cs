using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeAxisX : MonoBehaviour
{
    private float ScaleScreen;

    public delegate void Swipe(float value);
    public event Swipe EventClick;

	private void Start()
	{
        ScaleScreen = Screen.width / 8000f;
    }

	void Update()
    {
        if ( !Input.GetKeyDown(KeyCode.Mouse0) && Input.GetKey(KeyCode.Mouse0))
		{
            EventClick(Input.GetAxis("Mouse X") * ScaleScreen);
        }
    }
}

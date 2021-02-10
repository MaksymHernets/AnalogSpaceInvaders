using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text text;
    public Text value;

	private int _value;

	public void SetText(string name)
	{
		text.text = name;
	}

    public void Add(int Value)
	{
        _value += Value;
        value.text = _value.ToString();
	}

	public void Reset()
	{
		_value = 0;
		value.text = _value.ToString();
	}
}

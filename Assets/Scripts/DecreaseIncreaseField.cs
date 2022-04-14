using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DecreaseIncreaseField : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private int _minimumNumber;
    [SerializeField] private int _maximumNumber;
    [SerializeField] private int _starNumber;
    private int value;
    private void Awake()
    {
        value = _starNumber;
        _text.text = value.ToString();
    }
    public void Increase()
    {
        value = Convert.ToInt32(_text.text);
        if(value >= _maximumNumber)
            return;
        value++;
        _text.text = value.ToString();
    }

    public void Decrease()
    {
        value = Convert.ToInt32(_text.text);
        if (value <= _minimumNumber)
            return;
        value--;
        _text.text = value.ToString();
    }
}

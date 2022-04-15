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
    public int Value { get; private set; }
    private void Awake()
    {
        Value = _starNumber;
        _text.text = Value.ToString();
    }
    public void Increase()
    {
        Value = Convert.ToInt32(_text.text);
        if(Value >= _maximumNumber)
            return;
        Value++;
        _text.text = Value.ToString();
    }

    public void Decrease()
    {
        Value = Convert.ToInt32(_text.text);
        if (Value <= _minimumNumber)
            return;
        Value--;
        _text.text = Value.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReversedInputField : MonoBehaviour
{
    public List<char> symbolList;
    public TMP_InputField inputField;
    private int symbolCount = 0;

    public bool reversHebrew;
    void Start()
    {
        symbolList = new List<char>();
        inputField.onValueChanged.AddListener(OnInputFieldValueChanged);
        symbolCount = inputField.text.Length;
    }

    void OnInputFieldValueChanged(string newValue)
    {

        if (newValue.Length > symbolCount)
        {
            symbolList.Insert(0, newValue[newValue.Length - 1]); // Insert new symbol at the beginning of the list
        }
        else if (newValue.Length < symbolCount && symbolList.Count > 0)
        {
            symbolList.RemoveAt(0); // Remove the first symbol in the list
        }
        symbolCount = newValue.Length;
        if (reversHebrew)
        {
            inputField.text = string.Join("", symbolList); // Update inputField's text with symbols in the list
            Debug.Log("Number of symbols: " + symbolCount);
        }
    }
}
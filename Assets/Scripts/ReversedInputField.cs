using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReversedInputField : MonoBehaviour
{
    public List<char> symbolList;
    public TMP_InputField inputField;
    public int symbolCount = 0;

    public bool reversHebrew;

    public InputInfo inputinfo;


    void Start()
    {
        symbolList = new List<char>();
        inputField.onValueChanged.AddListener(OnInputFieldValueChanged);
        symbolCount = inputField.text.Length;

        inputinfo.inputFieldOption.onEndEdit.AddListener(ReversSymbolOrder);
    }

    public void ReversSymbolOrder(string value)
    {
        if (reversHebrew)
        {
        string word = new string(symbolList.ToArray());

        inputField.text = word;
        inputinfo.reversTriggerToHebrew = false;

        Debug.Log("here");
        }
    }

    void OnInputFieldValueChanged(string newValue)
    {
        symbolList.Clear();
        foreach (char c in inputinfo.showInputfieldText.ToCharArray())
        {
            symbolList.Add(c);
        }
        symbolList.Reverse();

    }
}
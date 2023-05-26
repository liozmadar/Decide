using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ListRename : MonoBehaviour
{
    [Header("List1")]
    public TextMeshProUGUI listButtonNameText1;
    public TMP_InputField listNameClickText1;

    public ListManager listManagerNumber;
    public int listNumber;


    //hebrew
    private const int HEBREW_START = 0x0590;
    private const int HEBREW_END = 0x05FF;

    //make the symbols of the inputfield to a list
    public List<char> symbolList;
    //and just show it on the inspector
    public string showInputfieldText;


    public bool reversHebrew;


    private void Start()
    {
        listManagerNumber = GetComponent<ListManager>();

        listNumber = listManagerNumber.listID;

        listNameClickText1.onValueChanged.AddListener(ActiveAddListeners);
        listNameClickText1.onValueChanged.AddListener(CheckLanguage);
        listNameClickText1.onValueChanged.AddListener(OnInputFieldValueChanged);
        listNameClickText1.onEndEdit.AddListener(ReversSymbolOrder);
        if (listNameClickText1 != null)
        {
            listNameClickText1.text = PlayerPrefs.GetString($"listButtonNameText{listManagerNumber.listID}").ToString();
        }
    }

    void ActiveAddListeners(string value)
    {
        UpdateListsName();
        // CheckLanguage();
    }

    //update the name on value change
    void UpdateListsName()
    {
        if (listNameClickText1 != null)
        {
            listButtonNameText1.text = listNameClickText1.text;
            PlayerPrefs.SetString($"listButtonNameText{listManagerNumber.listID}", listButtonNameText1.text);

            //show the inputfield playerpref text in the inspector
            showInputfieldText = PlayerPrefs.GetString($"listButtonNameText{listManagerNumber.listID}").ToString();
        }
    }

    //detect if the symbols are hebrew or not
    private void CheckLanguage(string text)
    {
        foreach (char c in text)
        {
            int code = (int)c;
            if (code >= HEBREW_START && code <= HEBREW_END)
            {
                reversHebrew = true;

                Debug.Log("Detected Hebrew language.");
                return;
            }
        }
        Debug.Log("Could not detect language.");
        reversHebrew = false;
    }

    //list of the symbols
    void OnInputFieldValueChanged(string newValue)
    {
        symbolList.Clear();
        foreach (char c in showInputfieldText.ToCharArray())
        {
            symbolList.Add(c);
        }
        symbolList.Reverse();
    }

    //revers the symbols order
    public void ReversSymbolOrder(string value)
    {
        if (reversHebrew)
        {
            string word = new string(symbolList.ToArray());

            listNameClickText1.text = word;
        }
    }
}

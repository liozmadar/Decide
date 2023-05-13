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
    [Header("List2")]
    public TextMeshProUGUI listButtonNameText2;
    public TMP_InputField listNameClickText2;
    [Header("List3")]
    public TextMeshProUGUI listButtonNameText3;
    public TMP_InputField listNameClickText3;


    //
    public Image imageColor;
    public TMP_InputField inputField;


    //
    private const int HEBREW_START = 0x0590;
    private const int HEBREW_END = 0x05FF;




    private void Start()
    {
        if (listNameClickText1 != null)
        {
            listNameClickText1.text = PlayerPrefs.GetString("listButtonNameText1").ToString();
            listNameClickText2.text = PlayerPrefs.GetString("listButtonNameText2").ToString();
            listNameClickText3.text = PlayerPrefs.GetString("listButtonNameText3").ToString();
        }

        inputField.onValueChanged.AddListener(CheckLanguage);

    }
    private void Update()
    {
        UpdateListsName();
    }


    //detect if the symbols are hebrew or not
    private void CheckLanguage(string text)
    {
        foreach (char c in text)
        {
            int code = (int)c;
            if (code >= HEBREW_START && code <= HEBREW_END)
            {
                Debug.Log("Detected Hebrew language.");
                imageColor.color = Color.green;
                return;
            }
        }

        Debug.Log("Could not detect language.");
        imageColor.color = Color.red;


    }
    //till here




    void UpdateListsName()
    {
        if (listNameClickText1 != null)
        {
            listButtonNameText1.text = listNameClickText1.text;
            PlayerPrefs.SetString("listButtonNameText1", listButtonNameText1.text);

            listButtonNameText2.text = listNameClickText2.text;
            PlayerPrefs.SetString("listButtonNameText2", listButtonNameText2.text);

            listButtonNameText3.text = listNameClickText3.text;
            PlayerPrefs.SetString("listButtonNameText3", listButtonNameText3.text);
        }
    }
}

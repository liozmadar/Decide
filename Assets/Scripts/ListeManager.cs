using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ListeManager : MonoBehaviour
{
    public int listID;
    [Header("List1")]
    public TextMeshProUGUI listButtonNameText1;
    public TMP_InputField listNameClickText1;
    [Header("List2")]
    public TextMeshProUGUI listButtonNameText2;
    public TMP_InputField listNameClickText2;
    [Header("List3")]
    public TextMeshProUGUI listButtonNameText3;
    public TMP_InputField listNameClickText3;

    private void Start()
    {
        if (listNameClickText1 != null)
        {
            listNameClickText1.text = PlayerPrefs.GetString("listButtonNameText1").ToString();
            listNameClickText2.text = PlayerPrefs.GetString("listButtonNameText2").ToString();
            listNameClickText3.text = PlayerPrefs.GetString("listButtonNameText3").ToString();
        }
    }
    private void Update()
    {
        UpdateListsName();
    }
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
    public void SelectList()
    {
        PlayerPrefs.SetInt("list", listID);
        SceneManager.LoadScene(0);
    }
}

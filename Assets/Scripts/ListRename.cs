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
    private void Start()
    {
        listManagerNumber = GetComponent<ListManager>();

        listNumber = listManagerNumber.listID;

        if (listNameClickText1 != null)
        {
            listNameClickText1.text = PlayerPrefs.GetString($"listButtonNameText{listManagerNumber.listID}").ToString();
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
           // PlayerPrefs.SetString("listButtonNameText1", listButtonNameText1.text);

            PlayerPrefs.SetString($"listButtonNameText{listManagerNumber.listID}", listButtonNameText1.text);

        }
    }
}

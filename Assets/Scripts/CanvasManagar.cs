using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManagar : MonoBehaviour
{
    public GameObject inputFieldOptionPref;
    public TextMeshProUGUI showTheChosenOne;

    public List<GameObject> allInputsInfo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HundredPercentDivided();
    }
    public void CreateInputFieldOption()
    {
        if (allInputsInfo.Count < 12)
        {
            //make new input field
            var NewInputField = Instantiate(inputFieldOptionPref, transform.position, Quaternion.identity);
            NewInputField.transform.SetParent(GameObject.FindGameObjectWithTag("InputsGrid").transform, false);
            //add the input to the list
            allInputsInfo.Add(NewInputField);
        }
    }
    public void ChooseRandomOption()
    {
        //choose random option from all the allInputsInfo
        int randomOptin = Random.Range(0, allInputsInfo.Count);
        var inputText = allInputsInfo[randomOptin].GetComponent<InputInfo>().inputFieldOption.text;
        showTheChosenOne.text = inputText;
    }
    void HundredPercentDivided()
    {
        //show the percentage chance for each option
        int hendred = 100 / allInputsInfo.Count;
        for (int i = 0; i < allInputsInfo.Count; i++)
        {
            allInputsInfo[i].GetComponent<InputInfo>().inputFieldPercentageText.text = hendred.ToString();
        }
    }
    public void RemoveUnputFieldOption()
    {
        //remove the last input from the list
        if (allInputsInfo.Count > 2)
        {
            int removeLast = allInputsInfo.Count - 1;
            Destroy(allInputsInfo[removeLast].gameObject);
            allInputsInfo.RemoveAt(removeLast);
        }
    }
}

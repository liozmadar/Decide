using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManagar : MonoBehaviour
{
    public GameObject inputFieldOptionPref;
    public InputField inputFieldOption;
    public TextMeshProUGUI showTheChosenOne;

    public List<GameObject> allInputsInfo;

    // Start is called before the first frame update
    void Start()
    {
        allInputsInfo.Add(GameObject.FindGameObjectWithTag("InputField"));
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void CreateInputFieldOption()
    {
        //make new input field
        var NewInputField = Instantiate(inputFieldOptionPref, transform.position, Quaternion.identity);
        NewInputField.transform.SetParent(GameObject.FindGameObjectWithTag("InputsGrid").transform, false);
        //add the input to the list
        allInputsInfo.Add(NewInputField);

       // var text = allInputsInfo[0].GetComponent<InputInfo>().inputFieldPercentageText.text;
       // Debug.Log(text);
    }
    public void ChooseRandomOption()
    {
        int randomOptin = Random.Range(0, allInputsInfo.Count);
        Debug.Log(randomOptin);

       // var InputText = allInputsInfo[randomOptin].GetComponent<InputInfo>().inputFieldPercentageText.text;
        var InputText = allInputsInfo[randomOptin].GetComponent<InputInfo>().inputFieldOption.text;
        showTheChosenOne.text = InputText;
    }
}

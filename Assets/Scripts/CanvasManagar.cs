using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManagar : MonoBehaviour
{
    public GameObject inputFieldOptionPref;
    public TextMeshProUGUI showTheChosenOne;
    public GameObject noMoreImage;
    public bool noMoreImageBool;

    public List<GameObject> allInputsInfo;
    public List<GameObject> allRemovedInputsInfo;
    private int inputsID = 2;

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
            //give the inputs IDs
            NewInputField.GetComponent<InputInfo>().ID = inputsID++;
        }
        else
        {
            if (!noMoreImageBool)
            {
                noMoreImage.SetActive(true);
                Invoke("CloseNoMoreImage", 2);
                noMoreImageBool = true;
            }
        }
    }
    void CloseNoMoreImage()
    {
        noMoreImage.SetActive(false);
        noMoreImageBool = false;
    }
    public void ChooseRandomOption()
    {
        //choose random option from all the allInputsInfo
        int randomOptin = Random.Range(0, allInputsInfo.Count);

        // int inputIndex = allInputsInfo.IndexOf(allInputsInfo[randomOptin]);

        int inputIdIndex = allInputsInfo[randomOptin].GetComponent<InputInfo>().ID;

        var inputText = allInputsInfo[randomOptin].GetComponent<InputInfo>().inputFieldOption.text;
        showTheChosenOne.text = inputText;

        if (allInputsInfo.Count >= 3)
        {
            Debug.Log("HERE2");
            //change the chosen option to red
            allInputsInfo[randomOptin].GetComponent<Image>().color = Color.red;
            allInputsInfo[randomOptin].GetComponent<InputInfo>().precentageParent.SetActive(false);

            //put the chosen in the removedInputs list
            allRemovedInputsInfo.Add(allInputsInfo[randomOptin]);
            allInputsInfo.Remove(allInputsInfo[randomOptin]);
        }
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

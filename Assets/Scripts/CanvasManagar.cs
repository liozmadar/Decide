using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CanvasManagar : MonoBehaviour
{
    public static CanvasManagar instance;
    public GameObject inputFieldOptionPref;
    public TextMeshProUGUI showTheChosenOne;
    public GameObject grid;
    public GameObject toggleRemovedInputsImage;
    public Image circleFilled;
    public bool circleFilledBool;
    public GameObject noMoreImage;
    public bool noMoreImageBool;

    [Header("Toggle remove or keep inputs")]
    public bool toggleRemovedOrKeepInputsBool;
    public TextMeshProUGUI ToggleOffOnRemoveInputs;
    public GameObject ButtonImageGreen;
    public GameObject ButtonImageRed;

    [Header("find Delete options")]
    public bool canDeleteNow;
    public Image removeInputsImage;

    [Header("Lists")]
    public List<GameObject> allInputsInfo;
    public List<GameObject> allRemovedInputsInfo;
    private int inputsID = -1;

    public int savedListCount;

    public int listID;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        savedListCount = PlayerPrefs.GetInt("SaveTheInputsCount");
        listID = PlayerPrefs.GetInt("list");
        Init();
    }
    // Update is called once per frame
    void Update()
    {
        HundredPercentDivided();

        CircleFilled();
    }

    void CircleFilled()
    {
        if (circleFilledBool)
        {
            //start slow
            if (circleFilled.fillAmount < 0.15)
            {
                circleFilled.fillAmount += 0.7f * Time.deltaTime;
            }
            //then fast
            else if (circleFilled.fillAmount < 0.85)
            {
                circleFilled.fillAmount += 2 * Time.deltaTime;
            }
            else
            {
                circleFilled.fillAmount += 0.7f * Time.deltaTime;
            }

            if (circleFilled.fillAmount >= 1)
            {
                RandomChosenAfterImageFilledDone();
                circleFilledBool = false;
            }


            /* circleFilled.fillAmount += 3 * Time.deltaTime;
             if (circleFilled.fillAmount == 1)
             {
                 RandomChosenAfterImageFilledDone();
                 circleFilledBool = false;
             }*/
        }
    }



    void SaveTheInputsCount()
    {
        PlayerPrefs.SetInt("SaveTheInputsCount", allInputsInfo.Count);
    }

    void Init()
    {
        int lastID = PlayerPrefs.GetInt($"lastID-{listID}");
        Debug.Log(lastID + "last ID");
        for (int i = 0; i <= 1000; i++)
        {
            string inputText = PlayerPrefs.GetString($"input-{i}-{listID}");
            if (inputText != "")
            {
                CreateInputFieldOption(inputText, i);
            }
        }
        if (allInputsInfo.Count == 1)
        {
            CreateInputFieldOptionButton();
        }
        else if (allInputsInfo.Count == 0)
        {
            CreateInputFieldOptionButton();
            CreateInputFieldOptionButton();
        }
        else
        {
            inputsID = allInputsInfo[allInputsInfo.Count - 1].GetComponent<InputInfo>().ID;
        }
    }
    public void CreateInputFieldOption(string text, int id)
    {
        //stop deleting on click here
        canDeleteNow = false;
        removeInputsImage.color = Color.white;

        if (allInputsInfo.Count < 12)
        {
            //make new input field
            inputsID++;
            var NewInputField = Instantiate(inputFieldOptionPref, transform.position, Quaternion.identity);
            NewInputField.transform.SetParent(GameObject.FindGameObjectWithTag("InputsGrid").transform, false);
            //add the input to the list
            allInputsInfo.Add(NewInputField);
            //give the inputs IDs
            NewInputField.GetComponent<InputInfo>().ID = id >= 0 ? id : inputsID;
            NewInputField.GetComponent<InputInfo>().inputFieldOption.text = text;

            PlayerPrefs.SetInt($"lastID-{listID}", inputsID);
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
    public void CreateInputFieldOptionButton()
    {
        //stop deleting on click here
        canDeleteNow = false;
        removeInputsImage.color = Color.white;

        if (allInputsInfo.Count < 12)
        {
            inputsID++;
            //make new input field
            var NewInputField = Instantiate(inputFieldOptionPref, transform.position, Quaternion.identity);
            NewInputField.transform.SetParent(GameObject.FindGameObjectWithTag("InputsGrid").transform, false);
            //add the input to the list
            allInputsInfo.Add(NewInputField);
            //give the inputs IDs
            NewInputField.GetComponent<InputInfo>().ID = inputsID;

            PlayerPrefs.SetInt($"lastID-{listID}", inputsID);
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
    void RandomChosenAfterImageFilledDone()
    {
        //stop deleting on click here
        canDeleteNow = false;
        removeInputsImage.color = Color.white;

        //choose random option from all the allInputsInfo
        int randomOptin = Random.Range(0, allInputsInfo.Count);
        //
        int inputIndex = allInputsInfo.IndexOf(allInputsInfo[randomOptin]);
        int inputIdIndex = allInputsInfo[randomOptin].GetComponent<InputInfo>().ID;
        //
        //copy the text of the chosen option to the top screen text
        var inputText = allInputsInfo[randomOptin].GetComponent<InputInfo>().inputFieldOption.text;
        showTheChosenOne.text = inputText;

        if (!toggleRemovedOrKeepInputsBool)
        {
            if (allInputsInfo.Count >= 3)
            {
                //change the chosen option to red
                allInputsInfo[randomOptin].GetComponent<Image>().color = Color.red;
                PlayerPrefs.DeleteKey($"input-{allInputsInfo[randomOptin].GetComponent<InputInfo>().ID}-{listID}");
                allInputsInfo[randomOptin].GetComponent<InputInfo>().precentageParent.SetActive(false);

                allInputsInfo[randomOptin].gameObject.transform.SetParent(grid.transform);

                Debug.Log(allInputsInfo[randomOptin].gameObject);
                //put the chosen in the removedInputs list
                allRemovedInputsInfo.Add(allInputsInfo[randomOptin]);
                allInputsInfo.Remove(allInputsInfo[randomOptin]);
            }
        }
    }
    public void ChooseRandomOption()
    {
        circleFilledBool = true;
        circleFilled.fillAmount = 0;
    }
    void HundredPercentDivided()
    {
        //show the percentage chance for each option
        int hendred = 100 / allInputsInfo.Count;
        for (int i = 0; i < allInputsInfo.Count; i++)
        {
            allInputsInfo[i].GetComponent<InputInfo>().inputFieldPercentageText.text = hendred.ToString() + "%";
        }
    }
    public void RemoveUnputFieldOption()
    {
        if (!canDeleteNow)
        {
            canDeleteNow = true;
            removeInputsImage.color = Color.green;
        }
        else
        {
            canDeleteNow = false;
            removeInputsImage.color = Color.white;
        }
    }
    public void ToggleRemovedInputsImage()
    {
        if (toggleRemovedInputsImage.activeSelf)
        {
            toggleRemovedInputsImage.SetActive(false);
        }
        else
        {
            toggleRemovedInputsImage.SetActive(true);
        }
    }

    public void ToggleRemoveOrKeepInputs()
    {
        //stop deleting on click here
        canDeleteNow = false;
        removeInputsImage.color = Color.white;
        //
        if (!toggleRemovedOrKeepInputsBool)
        {
            toggleRemovedOrKeepInputsBool = true;
            ToggleOffOnRemoveInputs.text = "Off";
            ButtonImageGreen.SetActive(false);
            ButtonImageRed.SetActive(true);
        }
        else
        {
            toggleRemovedOrKeepInputsBool = false;
            ToggleOffOnRemoveInputs.text = "On";
            ButtonImageGreen.SetActive(true);
            ButtonImageRed.SetActive(false);
        }
    }
    public void ResetGame()
    {
        for (int i = 0; i <= 1000; i++)
        {
            PlayerPrefs.DeleteKey($"input-{i}-{listID}");
        }
        SceneManager.LoadScene(1);
    }
    public void ReturnToMainScreen()
    {
        SceneManager.LoadScene(0);
    }
}

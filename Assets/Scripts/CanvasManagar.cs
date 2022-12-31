using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManagar : MonoBehaviour
{
    public GameObject inputFieldOptionPref;
    public InputField inputFieldOption;

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
        var NewInputField = Instantiate(inputFieldOptionPref, transform.position, Quaternion.identity);
        NewInputField.transform.SetParent(GameObject.FindGameObjectWithTag("InputsGrid").transform, false);

        allInputsInfo.Add(NewInputField);
        // Debug.Log(allInputsInfo.Count);

        allInputsInfo[0].GetComponent<InputInfo>();

      //  Debug.Log(allInputsInfo[0].input));
    }
}

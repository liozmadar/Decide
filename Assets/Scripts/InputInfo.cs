using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


public class InputInfo : MonoBehaviour, IPointerClickHandler
{
    public TMP_InputField inputFieldOption;
    public TextMeshProUGUI inputFieldPercentageText;
    public GameObject precentageParent;
    public int ID;
    public int listID;


    //hebrew
    private const int HEBREW_START = 0x0590;
    private const int HEBREW_END = 0x05FF;

    public ReversedInputField reversedHebrew;
    //


    public void OnPointerClick(PointerEventData eventData)
    {
        if (CanvasManagar.instance.canDeleteNow == true)
        {
            if (CanvasManagar.instance.allInputsInfo.Count > 2)
            {
                for (int i = 0; i < CanvasManagar.instance.allInputsInfo.Count; i++)
                {
                    if (CanvasManagar.instance.allInputsInfo[i].GetComponent<InputInfo>().ID == ID)
                    {
                        Destroy(CanvasManagar.instance.allInputsInfo[i].gameObject);
                        CanvasManagar.instance.allInputsInfo.RemoveAt(i);
                        PlayerPrefs.DeleteKey($"input-{ID}-{listID}");
                    }
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        listID = PlayerPrefs.GetInt($"list");
        inputFieldOption.onValueChanged.AddListener(onValueChange);

        //for hebrew
        inputFieldOption.onValueChanged.AddListener(CheckLanguage);
        //
    }
    void onValueChange(string value)
    {
        PlayerPrefs.SetString($"input-{ID}-{listID}", value);
    }




    //new code for hebrew

    //detect if the symbols are hebrew or not
    private void CheckLanguage(string text)
    {
        foreach (char c in text)
        {
            int code = (int)c;
            if (code >= HEBREW_START && code <= HEBREW_END)
            {
                reversedHebrew.reversHebrew = true;

                Debug.Log("Detected Hebrew language.");
                return;
            }
        }
        Debug.Log("Could not detect language.");
        reversedHebrew.reversHebrew = false;
    }
    //till here



















}

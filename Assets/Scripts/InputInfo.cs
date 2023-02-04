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
    }
    void onValueChange(string value)
    {
        PlayerPrefs.SetString($"input-{ID}-{listID}", value);
    }
}

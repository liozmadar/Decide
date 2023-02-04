using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ListManager : MonoBehaviour
{
    public int listID;

    private void Start()
    {

    }
    private void Update()
    {

    }
    public void SelectList()
    {
        PlayerPrefs.SetInt("list", listID);
        SceneManager.LoadScene(1);
    }
}

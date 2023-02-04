using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ListeManager : MonoBehaviour
{
    public int listID;
  
    public void SelectList()
    {
        PlayerPrefs.SetInt("list", listID);
        SceneManager.LoadScene(0);
    }
}

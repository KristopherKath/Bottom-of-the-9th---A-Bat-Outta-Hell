/*
 * Code by Kristopher Kath
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Tooltip("Input the desired scene build index")]
    [SerializeField] private int sceneBuildIndex = -1;

    [Tooltip("The first button selected when navigating to options menu")]
    [SerializeField] private GameObject optionsFirstButton; 

    public void PlayGame()
    {
        //load given scene value
        if (sceneBuildIndex != -1)
        {
            SceneManager.LoadScene(sceneBuildIndex);
        }
        //load next scene in build order
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

    //Navigates to options menu
    public void ToOptionsPage()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsFirstButton);
    }

}

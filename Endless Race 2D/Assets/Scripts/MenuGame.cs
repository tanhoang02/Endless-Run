using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MenuGame : MonoBehaviour
{
    public void PlayNow()       
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}

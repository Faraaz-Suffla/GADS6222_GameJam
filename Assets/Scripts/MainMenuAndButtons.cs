using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuAndButtons : MonoBehaviour
{
    
    public int scoreCount = 0;

    public GameObject Panel;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);

    }

    public void MoreInfo()
    {
        SceneManager.LoadScene(4);

    }

    public void Quit()
    {
        Application.Quit();

    }

    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }

    public void GoBack()
    {


    }

    public void MaleButton()
    {
        SceneManager.LoadScene(2);
    }

    public void FemaleButton()
    {
        SceneManager.LoadScene(3);


    }

    public void TrueButton()
    {
        scoreCount++;
        if (Panel.activeInHierarchy == false)
        {
            Panel.SetActive(true);
        }
        else
        {
            Panel.SetActive(false);
        }
        Debug.Log("add 1 point to score & close panel");

    }

    public void FalseButton() 
    {
        scoreCount++;
        if (Panel.activeInHierarchy == false)
        {
            Panel.SetActive(true);
        }
        else
        {
            Panel.SetActive(false);
        }
        Debug.Log("add 1 point to score & close panel");
    }

    public void OpenBrowserLink()
    {
        Application.OpenURL("https://loveyournuts.org/");
    }
}

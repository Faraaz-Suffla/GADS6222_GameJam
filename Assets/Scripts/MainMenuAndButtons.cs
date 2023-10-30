using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuAndButtons : MonoBehaviour
{
    public TMP_Text text;
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
        Panel.SetActive(false);
    }

    public void FalseButton() 
    {
        scoreCount++;
        Panel.SetActive(false);
    }
}

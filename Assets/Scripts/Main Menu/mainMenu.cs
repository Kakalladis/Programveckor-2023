using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void playGame () //Laddar banan n�r Play-knappen aktiveras -Filip
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitGame () //G�r ut ur spelet n�r Quit-knappen trycks ned -Filip
    {
        Application.Quit();
       
    }
}

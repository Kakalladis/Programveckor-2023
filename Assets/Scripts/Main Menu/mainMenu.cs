using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void playGame () //Laddar banan när Play-knappen aktiveras -Filip
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitGame () //Går ut ur spelet när Quit-knappen trycks ned -Filip
    {
        Application.Quit();
       
    }
}

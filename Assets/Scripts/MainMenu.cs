using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Función Inicializa Juego
    public void stageGame(){
        SceneManager.LoadScene("HardAgaintsWorld");    
    }

    //Función Salir Juego
    public void Out(){

        Application.Quit();
    }
}

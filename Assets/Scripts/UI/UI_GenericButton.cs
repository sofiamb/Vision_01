using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_GenericButton : MonoBehaviour
{
   
    private float timer = 0.0f;
    private bool isEnter = false;
    public enum TypeButton
    {
        ExitButton,
        ResetButton,
        QuitButton,
        None
    }
    public TypeButton typeButton;

    void Start()
    {

    }

    void Update()
    {
     
        if (isEnter == true )
        {
            
              timer += Time.deltaTime;
            if( timer > 2)
                typeButtonSelection();
        }
    }
    
    public void exitToPoint()
    {
        timer = 0.0f;
        isEnter = false;
    }


    public void enterToPoint()
    {
        timer = 0.0f;
        isEnter = true;
    }

    private void typeButtonSelection() {
       
        if (typeButton == TypeButton.ExitButton) { CloseApp(); }
        if (typeButton == TypeButton.ResetButton) { ResetScene(); }
        if (typeButton == TypeButton.QuitButton) { ExitApp(); }



    }

    private void CloseApp() { SceneManager.LoadScene("SCN_MainMenu"); }
    public void ResetScene() {
        
        SceneManager.LoadScene("VisionTest_01.1");
    }
    public void ExitApp() { Application.Quit(); }
}

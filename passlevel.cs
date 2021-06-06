using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class passlevel : MonoBehaviour
{
    private dontdestroycanvas script;
    private GameObject canv;
    private Text text;
    public void passonelevel()
    {
        text = GameObject.Find("Number").GetComponent<Text>();
        canv = GameObject.Find("Say");
        script = canv.GetComponent<dontdestroycanvas>();
        if(script.say >= 20)
        {
            script.say -= 20;
             text.text = script.say.ToString();
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }


    }
}

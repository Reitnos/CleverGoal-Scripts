using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuyeDon : MonoBehaviour
{
    private dontdestroycanvas script;
    private GameObject canv;
    private Text text;
  public void menuyeGit()
    {
        canv = GameObject.Find("Say");
        script = canv.GetComponent<dontdestroycanvas>();
        text = GameObject.Find("Number").GetComponent<Text>();
        script.say = 0;
        text.text = script.say.ToString();
        SceneManager.LoadScene(0);
    }
    
}

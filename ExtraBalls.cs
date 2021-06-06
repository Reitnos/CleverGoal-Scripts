using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtraBalls : MonoBehaviour
{
    public void ExtraBall()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

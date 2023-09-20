using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro_Butten_E : MonoBehaviour
{
    public void ScenLoader(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}

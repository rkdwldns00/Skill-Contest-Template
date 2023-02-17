using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void StartGame(int difficult)
    {
        GameManager.difficult = difficult;
        SceneManager.LoadScene("SampleScene");
    }
}

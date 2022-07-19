using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public void ClickStartGame()
    {
        SceneManager.LoadScene("gameScene", LoadSceneMode.Single);
    }
}

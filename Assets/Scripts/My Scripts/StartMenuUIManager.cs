using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuUIManager : MonoBehaviour
{
    public InputField PlayerInputField;

    public void StartGame()
    {
        //Need to store player some where
        GameManager.Instance.SetPlayerName(PlayerInputField.text);
        SceneManager.LoadScene(1);

    }
}

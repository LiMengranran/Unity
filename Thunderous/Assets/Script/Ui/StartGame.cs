using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(StartGameButton);
        //transform..GetComponent<Button>();
    }
    void StartGameButton()
    {
        God.god.IsStartGame = true;
    }
}

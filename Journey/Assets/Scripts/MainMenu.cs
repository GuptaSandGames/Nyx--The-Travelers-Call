using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Button play;
    public Button options;

    public LevelLoader levelLoader;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void PlayButtonPressed() {
      levelLoader.LoadNextLevel();
    }

    public void OptionsButtonPressed() {
      Debug.Log("Go To Options");
    }
}

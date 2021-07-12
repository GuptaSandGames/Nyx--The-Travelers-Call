using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public bool givenruby = false;
    public bool trashRemoved = false;
    public bool trashShown = false;

    public GameObject ruby;
    public GameObject coryRuby;
    public GameObject childrenRuby;
    public GameObject aManager;
    public AudioManager aman;
    public GameObject peter;

    // Start is called before the first frame update
    void Start()
    {
      // peter.transform.position = new Vector2(138.13f, 6.6f);
      aManager = GameObject.Find("AudioManager");
      aman = aManager.GetComponent<AudioManager>();
      aman.Play("S1");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateVar(string name) {
      aManager = GameObject.Find("AudioManager");
      aman = aManager.GetComponent<AudioManager>();
      //ruby
      if (name == "ruby") {
        Debug.Log("RubyHERELOL");
        Destroy(ruby);
        coryRuby.SetActive(true);
      }

      if (name == "rubygotten") {
        aman.Play("obtained");
      }

      if (name == "trash") {
        trashRemoved = true;
        aman.Play("S3");
        coryRuby.SetActive(false);
        childrenRuby.SetActive(true);
        peter.transform.position = new Vector2(29.1f, 6.6f);
      }

      if (name == "dirtyTheStreets") {
        trashShown = true;
      }

      Debug.Log(name);
    }

    public void attemptToPlay(string name) {
      aman.Play(name);
    }
}

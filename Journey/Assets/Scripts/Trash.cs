using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public GameObject MainCamera;
    public WorldController world;
    // Start is called before the first frame update
    void Start()
    {
      MainCamera = GameObject.Find("Main Camera");
      world = MainCamera.GetComponent<WorldController>();
      gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
      if (world.trashRemoved) {
        Destroy(gameObject);
      }

      if (world.trashShown) {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
      }
    }
}

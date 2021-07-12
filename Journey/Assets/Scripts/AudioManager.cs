using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
      if (instance == null) {
        instance = this;
      }
      else {
        Destroy(gameObject);
        return;
      }

      DontDestroyOnLoad(gameObject);

      foreach (Sound s in sounds) {
        s.source = gameObject.AddComponent<AudioSource>();
        s.source.clip = s.clip;
        s.source.volume = s.volume;
        s.source.pitch = s.pitch;
        s.source.loop = s.loop;
      }

      Play("S0");
    }

    // Update is called once per frame
    public void Play(string name) {
      Sound s = Array.Find(sounds, sound => sound.name == name);
      if (s == null) {
        Debug.LogWarning("Sound: " + name + " not found!");
        return;
      }
      if (s.name.StartsWith("S")) {

        foreach (Sound i in sounds) {
          AudioSource m = i.source;
          float original = m.volume;
          m.Stop();
          s.source.Play();
        }
      } else {
        s.source.Play();
      }
    }

    public void Stop(string name) {
      Sound s = Array.Find(sounds, sound => sound.name == name);
      if (s == null) {
        Debug.LogWarning("Sound: " + name + " not found!");
        return;
      }
      s.source.Stop();
    }
}

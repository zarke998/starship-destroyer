using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class MusicPlayer : MonoBehaviour {
	public static MusicPlayer instance = null;

	public AudioClip startMenuClip;
	public AudioClip gameClip;
	public AudioClip endMenuClip;

	private AudioSource audioSource;
	
	void Awake () {
		if (instance != null && instance != this) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);

			audioSource = GetComponent<AudioSource>();
		}
	}

	void OnEnable(){
		SceneManager.sceneLoaded += OnSceneLoaded;
		OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
	}

    void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
		audioSource.Stop();

		switch(scene.buildIndex){
			case (int)GameScenes.StartScene:
				audioSource.clip = startMenuClip;
				audioSource.volume = 0.25f;
				break;
			case (int)GameScenes.GameScene:
				audioSource.clip = gameClip;
				audioSource.volume = 0.35f;		
				break;
			case (int)GameScenes.EndScene:
				audioSource.clip = endMenuClip;
				audioSource.volume = 0.15f;
				break;
			default:
				audioSource.clip = gameClip;
				break;
		}

		audioSource.loop = true;
		audioSource.Play();
    }

	void OnDisable(){
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}
}

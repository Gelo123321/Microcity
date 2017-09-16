using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	public GameObject sfx;
	public AudioClip[] audioClips;
	public GameObject music;
	public AudioClip[] musicTracks;
	private AudioSource audioSource;
	private GameObject musicChannel;
	void Start()
	{
		musicChannel = Instantiate(music, transform.position, Quaternion.identity);
	}
	public void PlaySound(int index)
	{
		GameObject sound = Instantiate(sfx, transform.position, Quaternion.identity);
		audioSource = sound.GetComponent<AudioSource>();

		audioSource.clip = audioClips[index];
		audioSource.Play();
		Destroy(sound, audioClips[index].length);
	}
	public void PlayMusic(int index)
	{
		audioSource = musicChannel.GetComponent<AudioSource>();

		audioSource.clip = musicTracks[index];
		audioSource.Play();
	}
}

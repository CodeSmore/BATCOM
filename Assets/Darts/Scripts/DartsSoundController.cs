using UnityEngine;
using System.Collections;

public class DartsSoundController : MonoBehaviour {
	[SerializeField]
	private AudioClip dartHitClip = null, dartThrowClip = null;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	public void PlayDartHitClip () {
		audioSource.PlayOneShot(dartHitClip);
	}

	public void PlayDartThrowClip () {
		audioSource.PlayOneShot(dartThrowClip);
	}
}

using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {
	[SerializeField]
	private AudioClip ballShooterClip = null, multipleBumperHitsClip = null, singleBumperHitClip = null, speedBoostClip = null, paddlesClip = null;

	private AudioSource source;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
	}
	
	public void PlayBallShooterClip () {
		source.PlayOneShot(ballShooterClip);
	}

	public void PlayMultipleBumperHitsClip () {
		source.PlayOneShot(multipleBumperHitsClip);
	}

	public void PlaySingleBumperHitClip () {
		source.PlayOneShot(singleBumperHitClip);
	}

	public void PlaySpeedBoostClip () {
		source.PlayOneShot(speedBoostClip);
	}

	public void PlayPaddlesClip () {
		source.PlayOneShot(paddlesClip);
	}
}

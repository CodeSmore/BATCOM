using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SoundController : MonoBehaviour {

// multiple lines are used to make sure there's only ONE header for each section
	[Header("Pinball")]
	[SerializeField]
	private AudioClip ballShooterClip = null;
	[SerializeField]
	private AudioClip multipleBumperHitsClip = null, singleBumperHitClip = null, speedBoostClip = null, paddlesClip = null;


	[Header("Pool")]
	[SerializeField]
	private AudioClip oneBallHit = null;
	[SerializeField]
	private AudioClip ballInHole = null, stickHitsCueBall = null;

	[Header("Darts")]
	[SerializeField]
	private AudioClip dartHitClip = null;
	[SerializeField]
	private AudioClip dartThrowClip = null;

	private AudioSource source;

	// Use this for initialization
	void Awake () {
		source = gameObject.GetComponent<AudioSource>();

		DontDestroyOnLoad(gameObject);

		if (FindObjectsOfType(GetType()).Length > 1) {
			Destroy(gameObject);
		}

		if (SceneManager.GetActiveScene().buildIndex == 0) {
			source.volume = PlayerPrefsManager.GetSoundFXVolume();
		}
	}

	// Pinball
	
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

	// Pool

	public void PlayOneBallHit () {
		source.PlayOneShot(oneBallHit);
	}

	public void PlayBallInHole () {
		source.PlayOneShot(ballInHole);
	}

	public void PlayStickHitsCueBall () {
		source.PlayOneShot(stickHitsCueBall);
	}

	// Darts
	public void PlayDartHitClip () {
		source.PlayOneShot(dartHitClip);
	}

	public void PlayDartThrowClip () {
		source.PlayOneShot(dartThrowClip);
	}
}

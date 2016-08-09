using UnityEngine;
using System.Collections;

public class PoolSoundController : MonoBehaviour {

	[SerializeField]
	private AudioClip oneBallHit = null, ballInHole = null, stickHitsCueBall = null;

	private AudioSource source;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
	}
	
	public void PlayOneBallHit () {
		source.PlayOneShot(oneBallHit);
	}

	public void PlayBallInHole () {
		source.PlayOneShot(ballInHole);
	}

	public void PlayStickHitsCueBall () {
		source.PlayOneShot(stickHitsCueBall);
	}
}

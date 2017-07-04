using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndeadControl : MonoBehaviour {

	private Animation _animation;
	private bool _shouldMove = false;
	// Use this for initialization
	void Start () {
		_animation = GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (_shouldMove) {
			transform.Translate(Vector3.forward * Time.deltaTime * (transform.localScale.x * 0.05f));
		}
	}

	public void Walk() {
		if (!_animation.isPlaying) {
			_animation.Play ();
			_shouldMove = true;
		} else {
			_animation.Stop ();
			_shouldMove = false;
		}
	}

	public void LookAt() {
		transform.LookAt (Camera.main.transform);
		transform.eulerAngles = new Vector3 (0f, transform.eulerAngles.y, 0f);
	}

	public void IncreseSize(bool increase) {
		if (increase) {
			transform.localScale += new Vector3 (1f, 1f, 1f);
		} else {
			// This will stop making hit dissapear beyond the smallest size
			if (transform.localScale.x > 1f) {
				transform.localScale -= new Vector3 (1f, 1f, 1f);
			}
		}
	}
}

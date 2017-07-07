using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UndeadBase : MonoBehaviour {
	
	protected Animation _animation;
	protected Animator 	_animator;
	protected bool 		_shouldMove = false;

	void Start () {
		_animation = GetComponent<Animation> ();
		_animator = GetComponent<Animator> ();
	}

	void Update () {
		if (_shouldMove) {
			transform.Translate(Vector3.forward * Time.deltaTime * (transform.localScale.x * 0.05f));
		}
	}

	public virtual void Walk() {
		
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

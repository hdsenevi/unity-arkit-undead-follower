using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class UIManageZombieHerd : UIManagerBase {
	public UnityARGeneratePlane generatePlanes;
	private Animator 	_animator;
	private float 		_deltaTime = 0f;


	void Awake() {
		_animator = GetComponent<Animator> ();
	}

	public void EnableUIPanel() {
		if (_animator == null) {
			return;
		}

		_deltaTime = 0f;
			
		_animator.SetBool ("enableUI", true);
	}

	void Update() {
		if (Input.touchCount > 0 || Input.GetMouseButton(0)) {
			// We have a touch. Just reset _deltaTime
			_deltaTime = 0f;
		}

		// Wait 5 seconds before dismissing the panel
		if (_deltaTime < 5f) {
			_deltaTime += Time.deltaTime;
		} else {
			_animator.SetBool ("enableUI", false);
			_deltaTime = 0f;
		}
	}

	public void ToggleDebugPlanes() {
		if (generatePlanes == null)
			return;

		generatePlanes.debugPlanesActive = !generatePlanes.debugPlanesActive;
	}
}

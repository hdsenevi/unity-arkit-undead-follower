using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndeadControl : MonoBehaviour {
	private List<UndeadBase> 	_undeads;
	private UndeadBase 			_activeUndead;

	void Awake() {
		UndeadBase[] array = GetComponentsInChildren<UndeadBase> ();
		_undeads = new List<UndeadBase>(array);

		if (_undeads.Count > 0) {
			_activeUndead = _undeads [0];
			ChangeCharacter ();
		}
	}

	public virtual void Walk() {
		foreach (UndeadBase undead in _undeads) {
			undead.Walk ();
		}
	}

	public void LookAt() {
		foreach (UndeadBase undead in _undeads) {
			undead.LookAt ();
		}
	}

	public void IncreseSize(bool increase) {
		foreach (UndeadBase undead in _undeads) {
			undead.IncreseSize (increase);
		}
	}

	public void ChangeCharacter() {
		int activeUndeadIndex = 0;
		for (int i = 0; i < _undeads.Count; i++) {
			if (_activeUndead == _undeads [i]) {
				activeUndeadIndex = i;
				break;
			}
		}

		for (int i = 0; i < _undeads.Count; i++) {
			if (activeUndeadIndex != i) {
				_activeUndead.gameObject.SetActive (false);
				_activeUndead = _undeads [i];
				_activeUndead.gameObject.SetActive (true);
				break;
			}
		}

		this.Walk ();
	}
}

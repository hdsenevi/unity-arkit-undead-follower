using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndeadControl : MonoBehaviour {
	private List<UndeadBase> _undeads;

	void Awake() {
		UndeadBase[] array = GetComponentsInChildren<UndeadBase> ();
		_undeads = new List<UndeadBase>(array);
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
}

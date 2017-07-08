using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndeadSkeleton : UndeadBase {
	public override void Walk() {
		base.Walk ();
		if (_animator == null) {
			return;
		}

		if (!_animator.GetBool("walk")) {
			_animator.SetBool ("walk", true);
			_shouldMove = true;
		} else {
			_animator.SetBool ("walk", false);
			_shouldMove = false;
		}
	}
}

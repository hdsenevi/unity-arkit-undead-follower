using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndeadZombie : UndeadBase {
	public override void Walk() {
		base.Walk ();

		if (_animation == null) {
			return;
		}

		if (!_animation.isPlaying) {
			_animation.Play ();
			_shouldMove = true;
		} else {
			_animation.Stop ();
			_shouldMove = false;
		}
	}
}

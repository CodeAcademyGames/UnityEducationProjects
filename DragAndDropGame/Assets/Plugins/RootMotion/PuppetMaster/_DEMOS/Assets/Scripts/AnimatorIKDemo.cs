using UnityEngine;
using System.Collections;

namespace RootMotion.Demos {

	// Using the Unity's built in Animator IK to adjust the target pose of the Puppet.
	[RequireComponent(typeof(Animator))]
	public class AnimatorIKDemo : MonoBehaviour {

		bool isActive = false;
		public Transform HandIKTarget;

		private Animator animator;

		void Start() {
			animator = GetComponent<Animator>();
		}

		void OnAnimatorIK(int layer) {
			if (!isActive) {
				return;
			}
			animator.SetIKPosition(AvatarIKGoal.LeftHand, HandIKTarget.position);
			animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
			animator.SetIKPosition(AvatarIKGoal.RightHand, HandIKTarget.position);
			animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
		}

		public void SwitchActive() {
			isActive = ! isActive;
		}
	}
}

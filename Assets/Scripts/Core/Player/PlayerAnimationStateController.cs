using UnityEngine;

namespace HitMaster.Core.Player {
	/// <summary>
	/// Отвечает за переключение параметров и триггеров в PlayerAnimatorController
	/// </summary>
	public class PlayerAnimationStateController : MonoBehaviour {
		private Animator _animator;
		private readonly string _runningName = "IsRunning";
		private readonly string _aimName = "IsAim";
		private readonly string _shootingName = "Shooting";

		private bool _isRunning;
		private bool _isAim;

		public bool IsRunning {
			get => _isRunning;
			set {
				if (value != _isRunning) {
					_isRunning = value;
					_animator.SetBool(_runningName, value);
				}
			}
		}

		public bool IsAim {
			get => _isAim;
			set {
				if (value != _isAim) {
					_isAim = value;
					_animator.SetBool(_aimName, value);
				}
			}
		}

		public void Shooting() {
			_animator.SetTrigger(_shootingName);
		}

		private void Awake() {
			_animator = GetComponent<Animator>();
		}
	}
}
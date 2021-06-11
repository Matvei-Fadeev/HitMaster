using UnityEngine;

namespace HitMaster.Core.Player {
	/// <summary>
	/// Отвечает за переключение параметров и триггеров в PlayerAnimatorController
	/// </summary>
	public class PlayerAnimationStateController : MonoBehaviour {
		private Animator _animator;
		private readonly int _runningNameID = Animator.StringToHash("IsRunning");
		private readonly int _aimNameID = Animator.StringToHash("IsAim");
		private readonly int _shootingNameID = Animator.StringToHash("Shooting");

		private bool _isRunning;
		private bool _isAim;

		private void Awake() {
			_animator = GetComponent<Animator>();
		}

		public bool IsRunning {
			get => _isRunning;
			set {
				if (value != _isRunning) {
					_isRunning = value;
					_animator.SetBool(_runningNameID, value);
				}
			}
		}

		public bool IsAim {
			get => _isAim;
			set {
				if (value != _isAim) {
					_isAim = value;
					_animator.SetBool(_aimNameID, value);
				}
			}
		}

		public void Shooting() {
			_animator.SetTrigger(_shootingNameID);
		}
	}
}
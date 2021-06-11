using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HitMaster.Core.Utils {
	public class PlayerFinish : MonoBehaviour{
		private void OnTriggerEnter(Collider other) {
			if (other.gameObject.TryGetComponent(out Player.Player player)) {
				RestartLevel();
			}
		}

		private void RestartLevel() {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			GC.Collect();
		}
	}
}
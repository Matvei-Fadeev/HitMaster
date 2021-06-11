using UnityEngine;

namespace HitMaster.Core.Utils {
	public class FrameRateSettings : MonoBehaviour {
		[SerializeField] private bool useVSync;
		[SerializeField] private int maxFPS = 60;
		
		private void Start() {
			QualitySettings.vSyncCount = useVSync ? 1 : 0;
			Application.targetFrameRate = maxFPS;
		}
	}
}
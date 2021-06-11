using TMPro;
using UnityEngine;

namespace HitMaster.Core.Health {
	class DisplayedHealthComponent : HealthComponent {
		[Header("Text to display")]
		[SerializeField] private TextMeshPro text;
		[SerializeField] private bool hasDisableWhenDying;

		private void OnEnable() {
			HasChangeHP += UpdateText;
			HasDying += Disable;
		}

		private void OnDisable() {
			HasChangeHP -= UpdateText;
			HasDying -= Disable;
		}

		private void Start() {
			UpdateText(Health);
		}

		private void UpdateText(int newHP) {
			text.text = newHP.ToString();
		}

		private void Disable() {
			text.gameObject.SetActive(false);
		}

		[ContextMenu(nameof(HitByOne))]
		public void HitByOne() {
			Hit(1);
		}
	}
}
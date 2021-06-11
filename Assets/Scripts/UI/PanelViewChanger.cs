using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace HitMaster.UI {
	public class PanelViewChanger : MonoBehaviour {
		[SerializeField] private float durationToChangeView = 1f;
		
		private Image _imageOnPanel;
		private float _defaultFade;
		
		private void Awake() {
			_imageOnPanel = GetComponent<Image>();
			_defaultFade = _imageOnPanel.color.a;
		}

		[ContextMenu(nameof(Hide))]
		public void Hide() {
			_imageOnPanel
				.DOFade(0f, durationToChangeView)
				.OnComplete(() => gameObject.SetActive(false));
		}

		[ContextMenu(nameof(Show))]
		public void Show() {
			gameObject.SetActive(true);
			_imageOnPanel.DOFade(_defaultFade, durationToChangeView);
		}
	}
}
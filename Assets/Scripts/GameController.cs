using KidsStickerGame.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KidsStickerGame.Gameplay
{
	public class GameController : MonoBehaviour
	{
		[SerializeField] private StickersController stickersController;
		[SerializeField] private UIController uiController;
		[SerializeField] private StickerGameScrObj stickerGameScr;

		private void Awake()
		{
			InitGameController();
			uiController.onResetStickers = ResetStickers;
		}

		private void InitGameController()
		{
			stickersController?.InitStickersCtrl(stickerGameScr);
		}

		private void ResetStickers()
		{
			stickersController?.ResetStickers();
		}

	}
}


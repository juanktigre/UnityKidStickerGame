using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KidsStickerGame.UI
{
	public class UIController : MonoBehaviour
	{

		public Action onResetStickers;
		// Start is called before the first frame update
		public void OnResetStickers()
		{
			onResetStickers?.Invoke();
		}
	}
}

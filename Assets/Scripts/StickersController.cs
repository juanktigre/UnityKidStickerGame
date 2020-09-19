using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KidsStickerGame.Gameplay
{
	public class StickersController : MonoBehaviour
	{
		//public static GameController Instance { get; private set; }

		[Header("Audio usados por los stickers")]
		[SerializeField] public AudioClip[] audClips;
		[Header("Duración de retorno para el sticker sin Springoint")]
		[SerializeField] public float backduration = 0.5f;
		[Header("Contenedor de los puntos iniciales")]
		[SerializeField] private GameObject placesContainer;
		[Header("Contenedor de los Stickers con SpringJoint a mover")]
		[SerializeField] private GameObject stickersContainer;
		/*[Header("Contenedor de los Stickers a mover")]
		[SerializeField] private GameObject[] stickersNoJointlist;*/
		[Header("Particulas a instanciar ")]
		[SerializeField] public GameObject[] particles;
		//lista de stickers a usar en la escena
		[SerializeField] private List<Sticker> stickerslist;
		//puntos de inicio de los sticker
		[SerializeField] private Rigidbody2D[] placeslist;

		private StickerGameScrObj stickerGameScr;

		public void InitStickersCtrl(StickerGameScrObj stickerGameScr)
		{
			this.stickerGameScr = stickerGameScr;

			//obtenemos la lista de stickers y sus posiciones
			placeslist = placesContainer.GetComponentsInChildren<Rigidbody2D>();
			stickerslist = new List<Sticker>(stickersContainer.GetComponentsInChildren<Sticker>());


			for (int i = 0; i < stickerslist.Count; i++)
			{
				StickerModel stickerModel = stickerGameScr.GetStickersModels()[0].stickersList[i];
				stickerslist[i].InitSticker(placeslist[i], stickerModel.interaction[0], stickerModel.interaction[1]);
			}


		}


		/// <summary>
		/// Resetea la posicion y valores de los stickers con spring joint
		/// </summary>
		public void ResetStickers()
		{
			for (int i = 0; i < placeslist.Length; i++)
			{
				stickerslist[i].ResetSticker(placeslist[i]);

			}

		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KidsStickerGame.Gameplay
{

	public enum StickerScenesTag
	{
		School,
		Beach,
		Park,
		FarWest,
		Count
	}

	public enum StickerInteractionTag
	{
		Drop,
		PickUp,
		Count
	}

	public enum StickerAsset
	{
		Sticker_1,
		Sticker_2,
		Sticker_3,
		Sticker_4,
		Sticker_5,
		Sticker_6,
		Sticker_7,
		Sticker_8,
		Sticker_9,
		Sticker_10,
		Sticker_11,
		Sticker_12,
		Count


	}

	[System.Serializable]
	public class StickersSceneModel
	{

		[SerializeField, HideInInspector] private string name;

		public StickerScenesTag stickerSceneTag;
		public StickerModel[] stickersList;

		public void Edit_SetName()
		{
			name = (stickerSceneTag).ToString();
			for (int i = 0; i < stickersList.Length; i++)
			{
				stickersList[i].Edit_SetName();
			}
		}

	}
	[System.Serializable]
	public class StickerModel
	{
		[SerializeField, HideInInspector] private string name;

		public StickerAsset stickerAsset;
		public Sprite stickerSprite;
		public StickerInteractionModel[] interaction;

		public void Edit_SetName()
		{
			name = (stickerAsset).ToString();
			for (int i = 0; i < interaction.Length; i++)
			{
				interaction[i].Edit_SetName();
			}
		}
	}

	[System.Serializable]
	public class StickerInteractionModel
	{
		[SerializeField, HideInInspector] private string name;

		public StickerInteractionTag interactionTag;
		public ParticleSystem particles;
		public AudioClip audClips;
		public void Edit_SetName()
		{
			name = (interactionTag).ToString();
		}
	}
}




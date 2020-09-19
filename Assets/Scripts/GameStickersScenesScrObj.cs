using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KidsStickerGame.Gameplay;

namespace KidsStickerGame
{
	[CreateAssetMenu(fileName = "StickersAssets", menuName = "SGAssets", order = 0)]
	public class StickerGameScrObj : ScriptableObject
	{

		[SerializeField] private AudioClip resetAudio;
		[SerializeField] private float stickerBackDuration;

		[Space(50)]
		[SerializeField] private List<StickersSceneModel> stickersSceneModel;



#if UNITY_EDITOR
		void OnValidate()
		{
			for (int i = 0; i < stickersSceneModel.Count; i++)
			{
				stickersSceneModel[i].Edit_SetName();
			}
		}

#endif

		public StickersSceneModel GetGameScenes(StickerScenesTag scenesTag)
		{
			//Debug.Log();
			StickersSceneModel ShdaowScenes = stickersSceneModel.Find(f => f.stickerSceneTag == scenesTag);
			// if (ShdaowScenes.Count > 0)
			// {
			return ShdaowScenes;
			// }
			// else
			// {
			//  return null;
			//}
		}

		public List<StickersSceneModel> GetStickersModels()
		{
			return stickersSceneModel;
		}
	}
}
using UnityEngine;

namespace KidsStickerGame.Interfaces
{
	public interface IInteractable
	{
		void OnTriggerEnter2D(Collider2D other);
		void OnTriggerExit2D(Collider2D other);
	}
}
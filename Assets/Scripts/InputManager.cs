using UnityEngine;
using System.Collections;
using KidsStickerGame.Gameplay;
using KidsStickerGame.Interfaces;

namespace KidsStickerGame
{
	public class InputManager : MonoBehaviour
	{
		public bool draggingItem = false;
		public GameObject draggedObject;
		public Vector2 touchOffset;

		void Update()
		{
			if (HasInput)
			{
				DragOrPickUp();
			}
			else
			{


				if (draggingItem)
				{
					DropItem();

				}
			}
		}

		Vector2 CurrentTouchPosition
		{
			get
			{
				return Camera.main.ScreenToWorldPoint(Input.mousePosition);
			}
		}
		private void DragOrPickUp()
		{
			var inputPosition = CurrentTouchPosition;
			if (draggingItem)
			{
				draggedObject.transform.position = inputPosition + touchOffset;
			}
			else
			{
				RaycastHit2D[] touches = Physics2D.RaycastAll(inputPosition, inputPosition, 0.5f);
				if (touches.Length > 0)
				{
					var hit = touches[0];
					//if (hit.transform != null && hit.transform.tag == "Tile")
					if (hit.transform != null && hit.transform.GetComponent<IDraggable>() != null)
					{
						draggingItem = true;
						draggedObject = hit.transform.gameObject;
						touchOffset = (Vector2)hit.transform.position - inputPosition;

						if (draggedObject.GetComponent<Sticker>() != null)
							hit.transform.GetComponent<Sticker>().PickUp();
					}
				}
			}
		}

		private bool HasInput
		{
			get
			{
				return Input.GetMouseButton(0);
			}
		}

		void DropItem()
		{

			if (draggedObject.GetComponent<Sticker>() != null)
				draggedObject.GetComponent<Sticker>().Drop();
			draggingItem = false;
		}
	}
}
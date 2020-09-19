using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KidsStickerGame.Interfaces;
using Unity.Collections;

namespace KidsStickerGame.Gameplay
{
	public class Sticker : MonoBehaviour, IDraggable, IInteractable
	{
		[HideInInspector]
		private Rigidbody2D startingPosition;
		[HideInInspector]
		private Vector3 initialTrasnform;

		private Rigidbody2D FinalPosition;
		private AudioSource audSource;
		//private GameController gameController;
		private ParticleSystem particlePickUp;
		private ParticleSystem particleDrop;

		[SerializeField] private StickerInteractionModel pickUpModel;
		[SerializeField] private StickerInteractionModel droppModel;
		private bool inplace;

		[Tooltip("Sticker con el que será emparejado")]
		[SerializeField] private GameObject startSticker;

		[Header("Audio usados por los stickers")]
		[SerializeField] public AudioClip[] audClips;

		[Space(10)]
		[SerializeField] private bool initialized;


		public void InitSticker(Rigidbody2D place, StickerInteractionModel pickUpModel, StickerInteractionModel droppModel)
		{
			startingPosition = place;
			audSource = gameObject.GetComponent<AudioSource>();
			gameObject.GetComponent<SpriteRenderer>().sortingOrder = startSticker.GetComponent<SpriteRenderer>().sortingOrder + 1;
			GetComponent<SpringJoint2D>().connectedBody = startingPosition;
			initialTrasnform = transform.localScale;

			this.pickUpModel = pickUpModel;
			this.droppModel = droppModel;

			this.particleDrop = Instantiate(droppModel.particles, transform).GetComponent<ParticleSystem>();
			this.particlePickUp = Instantiate(pickUpModel.particles, transform).GetComponent<ParticleSystem>();


			this.audClips = audClips;
			initialized = true;
		}

		public void PickUp()
		{
			GetComponent<SpringJoint2D>().enabled = false;
			transform.localScale = startSticker.transform.localScale;
			particlePickUp?.Play();

		}

		public void Drop()
		{
			GetComponent<SpringJoint2D>().enabled = true;


			if (!inplace)
			{

				particleDrop?.Stop();
				PlayAudioEffects(droppModel.audClips);
				transform.localScale = initialTrasnform;

			}
			else
			{
				particlePickUp?.Stop();
				particleDrop?.Play();
				PlayAudioEffects(pickUpModel.audClips);

				startingPosition = FinalPosition;
				GetComponent<PolygonCollider2D>().enabled = false;

			}
		}

		public void OnTriggerEnter2D(Collider2D other)
		{

			if (other.name == startSticker.name && !inplace)
			{
				FinalPosition = other.GetComponent<Rigidbody2D>();
				GetComponent<SpringJoint2D>().connectedBody = FinalPosition;
				inplace = true;
			}
		}
		public void OnTriggerExit2D(Collider2D other)
		{

			if (other.name == startSticker.name && inplace)
			{
				GetComponent<SpringJoint2D>().connectedBody = startingPosition;
				inplace = false;

			}
		}

		public void ResetSticker(Rigidbody2D placeRb)
		{
			startingPosition = placeRb;
			//PlayAudioEffects(audClips[2]);
			GetComponent<SpringJoint2D>().connectedBody = placeRb;
			GetComponent<PolygonCollider2D>().enabled = true;
			transform.localScale = initialTrasnform;

		}
		/// <summary>
		/// efectos de sondo que serán reproducidos
		/// </summary>
		/// <param name="clip"></param>
		public void PlayAudioEffects(AudioClip clip)
		{
			audSource.clip = clip;
			audSource.Play();
		}
	}
}

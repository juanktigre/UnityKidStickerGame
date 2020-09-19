using KidsStickerGame.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour, ISlot
{
	[SerializeField] private Color color = Color.yellow;
	[SerializeField] private float sieze = 1f;
	// Start is called before the first frame update
	public Vector3 GetPos()
	{
		return transform.position;

	}

	public void OnDrawGizmos()
	{
		// Draw a yellow sphere at the transform's position
		Gizmos.color = color;
		Gizmos.DrawWireCube(transform.position, Vector3.one * sieze);
	}

}

using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class MixedFlower : MonoBehaviour {

	[SerializeField] List<Material> _materials = new List<Material>();
	[SerializeField] List<MeshRenderer> _petals = new List<MeshRenderer>();

	void OnEnable()
	{
		pickNewColor();
	}

	[Button("test")]
	void pickNewColor()
	{
		Material randomMat = _materials.Random();
		foreach (MeshRenderer petalMesh in _petals)
		{
			petalMesh.material = randomMat;
		}
	}
}

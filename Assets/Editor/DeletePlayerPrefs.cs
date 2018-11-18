using UnityEditor;
using UnityEngine;

public class DeletePlayerPrefs : MonoBehaviour {
	[MenuItem("Tools/Delete All PlayerPrefs")]
	static public void DeleteAllPlayerPrefs() {
		PlayerPrefs.DeleteAll();
	}
}

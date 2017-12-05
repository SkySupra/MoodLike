using UnityEngine;

namespace MoodLike
{
	public class Billboard : MonoBehaviour
	{
		private Transform trCamera;
		private Transform tr;

		private void Awake()
		{
			trCamera = Camera.main.transform;
			tr = transform;
		}
		private void OnWillRenderObject()
		{
			transform.LookAt(tr.position + trCamera.rotation * Vector3.forward, trCamera.rotation * Vector3.up);
		}
	}
}
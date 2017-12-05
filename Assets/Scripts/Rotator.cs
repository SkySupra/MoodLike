using UnityEngine;

namespace MoodLike
{
	public class Rotator : MonoBehaviour
	{
		[SerializeField]
		private Vector3 eulerAngles;

		private Transform tr;

		private void Awake()
		{
			tr = transform;
		}
		private void Update()
		{
			tr.Rotate(eulerAngles * Time.deltaTime);
		}
	}
}
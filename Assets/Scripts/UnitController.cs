using UnityEngine;

namespace MoodLike
{
	public class UnitController : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer rendererModel;
		[SerializeField]
		private AvatarConfig avatarConfig;

		private Transform trCamera;
		private Transform trUnit;

		private void Awake()
		{
			trUnit = transform;
			trCamera = Camera.main.transform;

		}
		private void Update()
		{
			float angleCamUnit = Vector3.Angle(trCamera.forward, trUnit.forward);
			AvatarDirection avatar = avatarConfig.GetAvatarByAngle(angleCamUnit);

			bool isFlip = false;
			if(avatar.IsCanFlip)
			{
				Vector3 cross = Vector3.Cross(trCamera.forward, trUnit.forward);
				isFlip = cross.y < 0;
			}

			rendererModel.sprite = avatar.Idle;
			rendererModel.flipX = isFlip;
		}
	}
}
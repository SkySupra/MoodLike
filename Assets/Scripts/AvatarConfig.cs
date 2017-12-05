using UnityEngine;

namespace MoodLike
{
	[System.Serializable]
	public class AvatarDirection
	{
		[SerializeField]
		private int angleDeg;
		[SerializeField]
		private bool isCanFlip;
		[SerializeField]
		private Sprite idle;
		// TODO добавить сюда другие анимации (run, attack и пр). В зависимости от архитектуры это могут быть AnimationClip, кадровая анимация ToolKit2D или своя собственная.

		public int AngleDeg
		{
			get { return angleDeg; }
		}
		public bool IsCanFlip
		{
			get { return isCanFlip; }
		}
		public Sprite Idle
		{
			get { return idle; }
		}
	}
	public class AvatarConfig : ScriptableObject
	{
		[SerializeField]
		private AvatarDirection[] avatarDirections;

		public AvatarDirection GetAvatarByAngle(float directionAngleDeg)
		{
			float smallestLengVel = float.MaxValue;
			AvatarDirection best = avatarDirections[0];
			foreach(var item in avatarDirections)
			{
				float angleDiff = Mathf.Abs(Mathf.DeltaAngle(directionAngleDeg, item.AngleDeg));

				if(angleDiff < smallestLengVel)
				{
					best = item;
					smallestLengVel = angleDiff;
				}
			}

			return best;
		}

		#if UNITY_EDITOR
		[UnityEditor.MenuItem("Assets/MoodLike/AvatarConfig")]
		private static void FactoryConfig() 
		{
			ScriptableObjectUtility.CreateAsset<AvatarConfig>();
		}
		#endif
	}
}
#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;

public static class ScriptableObjectUtility
{
	/// <summary>
	///	This makes it easy to create, name and place unique new ScriptableObject asset files.
	/// </summary>
	public static void CreateAsset<T>(string pathDirectory = "", string nameFile = "") where T : ScriptableObject
	{
		T asset = ScriptableObject.CreateInstance<T>();

		if(string.IsNullOrEmpty(pathDirectory))
		{
			pathDirectory = AssetDatabase.GetAssetPath(Selection.activeObject);

			if(pathDirectory == "")
			{
				pathDirectory = "Assets";
			}
			else if(Path.GetExtension(pathDirectory) != "")
			{
				pathDirectory = pathDirectory.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
			}
		}
		else
		{
			if(!pathDirectory.StartsWith("Assets"))
			{
				pathDirectory = "Assets/" + pathDirectory;
			}
		}

		if(!pathDirectory.EndsWith("/"))
			pathDirectory += "/";

		if(string.IsNullOrEmpty(nameFile))
			nameFile = "New " + typeof(T).Name;
		nameFile += ".asset";

		string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(pathDirectory + nameFile);

		AssetDatabase.CreateAsset(asset, assetPathAndName);

		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh();

		EditorUtility.FocusProjectWindow();
		Selection.activeObject = asset;
	}
}
#endif
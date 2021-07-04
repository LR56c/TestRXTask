using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public class MyAutoSaveExtensionUpdated
{
	// Static constructor that gets called when unity fires up.
	static MyAutoSaveExtensionUpdated()
	{
		EditorApplication.playModeStateChanged += AutoSaveWhenPlaymodeStarts;
	}

	private static void AutoSaveWhenPlaymodeStarts(PlayModeStateChange playModeStateChange)
	{
		if (EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isPlaying)
		{
			//EditorApplication.SaveScene();
			Save();
		}
	}

	public static void Save()
	{
		EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
		AssetDatabase.SaveAssets();
	}
}
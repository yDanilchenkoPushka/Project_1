using UnityEditor;

namespace DefaultNamespace.Editor
{
    public class BuilderEditor
    {
        [MenuItem("Buildings/Standalone")]
        public static void RunStandaloneBuild()
        {
            string fileName = "TestBuild";
            string fileExtension = ".exe";
            
            string dataPath = EditorUtility.SaveFolderPanel("Windows Build", "", "");

            string locationStringPathName = dataPath + "/" + fileName + fileExtension;

            string[] scenePaths = new[] { "Assets/Scenes/MainMenu.unity", "Assets/Scenes/Level.unity" };
            
            BuildPipeline.BuildPlayer(scenePaths, locationStringPathName, BuildTarget.StandaloneWindows64, BuildOptions.None);
        }
    }
}
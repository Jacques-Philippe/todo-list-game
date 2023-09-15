using UnityEngine.SceneManagement;

public enum Scenes
{
    BEDROOM,
    HALLWAY,
    KITCHEN,
    OUTSIDE,
    STORE
};


public static class SceneUtils 
{
    private static string BEDROOM_SCENE_NAME = "Bedroom";
    private static string HALLWAY_SCENE_NAME = "Hallway";
    private static string KITCHEN_SCENE_NAME = "Kitchen";
    private static string OUTSIDE_SCENE_NAME = "Outside";
    private static string STORE_SCENE_NAME = "Store";

    public static void Load(Scenes scene)
    {
        switch (scene)
        {
            case Scenes.BEDROOM:
                {
                    SceneManager.LoadScene(BEDROOM_SCENE_NAME);
                    break;
                }
            case Scenes.HALLWAY:
                {
                    SceneManager.LoadScene(HALLWAY_SCENE_NAME);
                    break;
                }
            case Scenes.KITCHEN:
                {
                    SceneManager.LoadScene(KITCHEN_SCENE_NAME);
                    break;
                }
            case Scenes.OUTSIDE:
                {
                    SceneManager.LoadScene(OUTSIDE_SCENE_NAME);
                    break;
                }
            case Scenes.STORE:
                {
                    SceneManager.LoadScene(STORE_SCENE_NAME);
                    break;
                }
            default:
                {
                    throw new System.Exception($"Received unhandled value {scene}");
                }
        }
    }


}

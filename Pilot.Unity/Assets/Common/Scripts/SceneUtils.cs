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
    private const string BEDROOM_SCENE_NAME = "Bedroom";
    private const string HALLWAY_SCENE_NAME = "Hallway";
    private const string KITCHEN_SCENE_NAME = "Kitchen";
    private const string OUTSIDE_SCENE_NAME = "Outside";
    private const string STORE_SCENE_NAME = "Store";

    public static void Load(Scenes scene)
    {
        var activeSceneName = SceneManager.GetActiveScene().name;
        SceneSwitchData.lastScene = SceneFromString(activeSceneName);

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

    public static Scenes CurrentScene()
    {
        return SceneFromString(SceneManager.GetActiveScene().name);
    }

    private static Scenes SceneFromString(string sceneName)
    {
        switch (sceneName)
        {
            case BEDROOM_SCENE_NAME:
                {
                    return Scenes.BEDROOM;
                }
            case HALLWAY_SCENE_NAME:
                {
                    return Scenes.HALLWAY;
                }
            case KITCHEN_SCENE_NAME:
                {
                    return Scenes.KITCHEN;
                }
            case OUTSIDE_SCENE_NAME:
                {
                    return Scenes.OUTSIDE;
                }
            case STORE_SCENE_NAME:
                {
                    return Scenes.OUTSIDE;
                }
            default:
                {
                    throw new System.Exception($"Received unexpected value {sceneName}");
                }
        }
    }


}

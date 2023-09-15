using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlacePlayerByDoor : MonoBehaviour
{
    [Serializable]
    public struct SpawnPositions {
        public Scenes lastScene;
        public Transform spawnPosition;
    }

    [SerializeField]
    private List<SpawnPositions> spawnPositions;

    // Start is called before the first frame update
    void Start()
    {
        bool playerIsEnteringFromAnotherScene = SceneSwitchData.lastScene.HasValue;
        if (!playerIsEnteringFromAnotherScene)
        {
            return;
        }

        var lastScene = SceneSwitchData.lastScene.Value;

        var playerTransform = GetPlayerTransform();
        var spawnPoint = this.spawnPositions
            .Where(s => s.lastScene == lastScene)
            .Select(s => s.spawnPosition)
            .FirstOrDefault();

        if (spawnPoint == null)
        {
            throw new Exception($"No spawn point was found for the last scene {lastScene}");
        }

        playerTransform.position = spawnPoint.position;
    }

    private Transform GetPlayerTransform()
    {
        const string PLAYER_TAG = "Player";
        var match = GameObject.FindGameObjectWithTag(PLAYER_TAG);
        if (match == null)
        {
            throw new System.Exception("No gameobject with tag Player was found in the scene");
        }
        return match.transform;
    }
}

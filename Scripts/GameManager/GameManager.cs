using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public PlayerDetails pDetails;
    public UIManager uiMan;
    public SpawnObject itemSpawner;
    public Transform spawnPoint;
    public GameObject playerPrefab;

    // Use this for initialization
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        itemSpawner.SpawnItemChest();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerWasHit(int damage)
    {
        pDetails.TakeDmg(damage);
        uiMan.UpdateHealthBar();
    }

    public void RespawnPlayer()
    {
        playerPrefab.transform.position = spawnPoint.transform.position;
        pDetails.RespawnPlayer();
        uiMan.UpdateHealthBar();
    }
}

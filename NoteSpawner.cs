using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public static NoteSpawner instance;

    public GameObject noteObject;
    public GameObject gapObject;
    public Transform objectSpawnPoint;

    int shouldSpawn;

    private void Awake(){
        instance = this;
    }

    public void SpawnEntity(){
        if(shouldSpawn%2 == 0) Instantiate(gapObject,objectSpawnPoint.position,gapObject.transform.rotation);
        else Instantiate(noteObject,objectSpawnPoint.position,noteObject.transform.rotation);
        shouldSpawn++;
    }
}

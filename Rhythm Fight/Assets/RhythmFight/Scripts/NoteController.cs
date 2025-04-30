using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{

    public GameObject[] notePrefabs; // References to the note prefabs that will be spawned.
    public Vector3[] spawnPositions; // The positions where the notes will spawn.
    public float beatTempo;
    public string parentObjectName;
    public float bpm = 120f;
    private float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = 60f / bpm;
    }

    // Update is called once per frame
    void Update()
    {
        // Subtract the time elapsed since the last note spawn from the cooldown.
        cooldown -= Time.deltaTime;

        if (cooldown <= 0f && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            // Reset the cooldown.
            cooldown = 60f / bpm;

            if (Input.GetKeyDown(KeyCode.LeftArrow)) // Check if the left arrow key is pressed.
            {
                SpawnNote(0); // Call the SpawnNote function and pass in the index of the first note prefab.
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow)) // Check if the down arrow key is pressed.
            {
                SpawnNote(1); // Call the SpawnNote function and pass in the index of the second note prefab.
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow)) // Check if the up arrow key is pressed.
            {
                SpawnNote(2); // Call the SpawnNote function and pass in the index of the third note prefab.
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow)) // Check if the right arrow key is pressed.
            {
                SpawnNote(3); // Call the SpawnNote function and pass in the index of the fourth note prefab.
            }

            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        }
    }
    private void SpawnNote(int index)
    {
        GameObject parentObject = GameObject.Find("NoteHolder");
        GameObject spawnedNote = Instantiate(notePrefabs[index], spawnPositions[index], Quaternion.identity); // Spawn the specified note prefab at the specified position.
        spawnedNote.transform.parent = parentObject.transform;
    }
}

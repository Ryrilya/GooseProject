using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooseDisplay : MonoBehaviour
{
    public Goose goose;

    private Party party;
    private GameObject gooseInstantiated;
    private Camera cam;
    //private CameraController camController;

    // Start is called before the first frame update
    private void Awake()
    {
        party = GameObject.Find("GameManager").GetComponent<Party>();
        goose = party.partyMembers[0];
        cam = Camera.main;
        //camController = cam.GetComponent<CameraController>();
    }

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        gooseInstantiated = Instantiate(goose.modelFBX, new Vector3(0, 0, 0), Quaternion.identity);
        gooseInstantiated.transform.parent = GameObject.Find("GFX").transform;
        gooseInstantiated.transform.localPosition = new Vector3(0, 0, 0);
        gooseInstantiated.transform.localScale = goose.scale;
        gooseInstantiated.transform.localRotation = Quaternion.Euler(goose.rotation.x, goose.rotation.y, goose.rotation.z);
        //camController.target = gooseInstantiated.transform;
        //camController.offset = goose.cameraOffset;
    }
}

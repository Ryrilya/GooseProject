// Code developed by following "Emergent Sagas" on Youtube: https://www.youtube.com/watch?v=bVo0YLLO43s

using UnityEngine;

public class CamersOrbit : MonoBehaviour
{
    public float mouseSensitivity = 4f;
    public float scrollsensitivity = 2f;
    public float orbitSpeed = 10f;
    public float scrollSpeed = 6f;
    public bool cameraDisabled = false;

    private Transform cam;
    private Transform camPivot;
    private Vector3 localRotation;
    private float camDistance = 10f;

    // Start is called before the first frame update
    void Start()
    {
        cam = transform;
        camPivot = transform.parent;
    }

    // Update is called once per frame, after Update() on every game object in the scene.
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            cameraDisabled = !cameraDisabled;

        if (!cameraDisabled)
        {
            if (Input.GetMouseButton(1))
            {
                // Rotation of the camera based on Mouse Coordinates
                if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
                {
                    localRotation.x += Input.GetAxis("Mouse X") * mouseSensitivity;
                    localRotation.y -= Input.GetAxis("Mouse Y") * mouseSensitivity;

                    // Clamp the Y rotation to horizon and not flipping over at the top
                    localRotation.y = Mathf.Clamp(localRotation.y, -20f, 75f);
                }
            }

            // Zooming Input from our Mouse Scrollwheel
            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                float scrollAmount = Input.GetAxis("Mouse ScrollWheel") * scrollsensitivity;

                // Makes camera zoom faster the further away it is from the target
                scrollAmount *= (camDistance * 0.3f);

                camDistance += scrollAmount * -1f;

                // This makes camera go no closer than 1.5 meters from target, and no further than 100 meters
                camDistance = Mathf.Clamp(camDistance, 7f, 30f);
            }

            // Actual camera rig transformations
            Quaternion QT = Quaternion.Euler(localRotation.y, localRotation.x, 0);
            camPivot.rotation = Quaternion.Lerp(camPivot.rotation, QT, Time.deltaTime * orbitSpeed);

            if (cam.localPosition.z != camDistance * -1f)
            {
                cam.localPosition = new Vector3(0f, 5f, Mathf.Lerp(cam.localPosition.z, camDistance * -1f, Time.deltaTime * scrollSpeed));
            }
        }
    }
}

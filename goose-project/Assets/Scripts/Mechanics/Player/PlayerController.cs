using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    private PlayerMotor _motor;
    private Camera _camera;
    [SerializeField] private Interactable _focus = null;

    private void Start()
    {
        _motor = GetComponent<PlayerMotor>();
        _camera = Camera.main;
    }

    private void Update()
    {
        // If we press left mouse
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            // we create a ray
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If the ray hits
            if(Physics.Raycast(ray, out hit, 100))
            {
                _motor.MoveToPoint(hit.point);  // Move to where we hit
                RemoveFocus();                  // Stop any focusing object
            }
        }

        // If we press right mouse
        if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
        {
            // we create a ray
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If the ray hits
            if (Physics.Raycast(ray, out hit, 100))
            {
                // Check if we hit an interactable
                Interactable interactable = hit.collider.GetComponentInParent<Interactable>();
                // If we did, set it as our focus
                if(interactable != null)
                    SetFocus(interactable);
            }
        }
    }

    public void SetFocus(Interactable newFocus)
    {
        if(newFocus != _focus)
        {
            if(_focus != null)
                _focus.OnDefocused();
            _focus = newFocus;
            _motor.FollowTarget(newFocus);
        }

        newFocus.OnFocused();
    }

    public void RemoveFocus()
    {
        if(_focus != null)
            _focus.OnDefocused();
        _focus = null;
        _motor.StopFollowingTarget();
    }
}

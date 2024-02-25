using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpaceshipController : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 3f;
    public float maxDistanceFromPlanet = 50f;
    public Transform planet;
    public Transform respawnPoint;

    private Rigidbody rb;
    private Vector2 touchStartPos;
    private bool isTouching = false;

    // UI Buttons
    public Button forwardButton;
    public Button backwardButton;
    public Button leftButton;
    public Button rightButton;
    public Button fasterForwardButton;


    // Flags to check if buttons are being held down
    private bool isForwardPressed = false;
    private bool isBackwardPressed = false;
    private bool isLeftPressed = false;
    private bool isRightPressed = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Add onClick listeners to the buttons
        forwardButton.onClick.AddListener(ApplyForwardForce);
        backwardButton.onClick.AddListener(ApplyBackwardForce);
        leftButton.onClick.AddListener(ApplyLeftForce);
        rightButton.onClick.AddListener(ApplyRightForce);
        fasterForwardButton.onClick.AddListener(ApplyFasterForwardForce);


        // Add EventTrigger components for pointer down and up events
        EventTrigger triggerForward = forwardButton.gameObject.AddComponent<EventTrigger>();
        EventTrigger triggerBackward = backwardButton.gameObject.AddComponent<EventTrigger>();
        EventTrigger triggerLeft = leftButton.gameObject.AddComponent<EventTrigger>();
        EventTrigger triggerRight = rightButton.gameObject.AddComponent<EventTrigger>();
        EventTrigger triggerFasterForward = fasterForwardButton.gameObject.AddComponent<EventTrigger>();


        // Add pointer down events
        AddEventTrigger(triggerForward, EventTriggerType.PointerDown, () => isForwardPressed = true);
        AddEventTrigger(triggerBackward, EventTriggerType.PointerDown, () => isBackwardPressed = true);
        AddEventTrigger(triggerLeft, EventTriggerType.PointerDown, () => isLeftPressed = true);
        AddEventTrigger(triggerRight, EventTriggerType.PointerDown, () => isRightPressed = true);
        AddEventTrigger(triggerFasterForward, EventTriggerType.PointerDown, () => ApplyFasterForwardForce());


        // Add pointer up events
        AddEventTrigger(triggerForward, EventTriggerType.PointerUp, () => isForwardPressed = false);
        AddEventTrigger(triggerBackward, EventTriggerType.PointerUp, () => isBackwardPressed = false);
        AddEventTrigger(triggerLeft, EventTriggerType.PointerUp, () => isLeftPressed = false);
        AddEventTrigger(triggerRight, EventTriggerType.PointerUp, () => isRightPressed = false);
        AddEventTrigger(triggerFasterForward, EventTriggerType.PointerUp, () => { /* You can handle pointer up events if needed */ });

        
    }

    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            HandleInput();

            float distanceToPlanet = Vector3.Distance(transform.position, planet.position);

            if (distanceToPlanet > maxDistanceFromPlanet)
            {
                Respawn();
            }
        }
    }

    private void HandleInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
                isTouching = true;
            }
            else if (touch.phase == TouchPhase.Moved && isTouching)
            {
                Vector2 touchDelta = touch.position - touchStartPos;

                float mouseX = touchDelta.x;
                float mouseY = touchDelta.y;

                transform.Rotate(Vector3.up * mouseX * rotationSpeed);
                transform.Rotate(Vector3.left * mouseY * rotationSpeed);

                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isTouching = false;
            }
        }

        // Modify the existing input handling to consider continuous input
        if (isForwardPressed)
        {
            rb.AddForce(transform.forward * speed);
        }
        if (isBackwardPressed)
        {
            rb.AddForce(-transform.forward * speed);
        }
        if (isLeftPressed)
        {
            rb.AddForce(-transform.right * speed);
        }
        if (isRightPressed)
        {
            rb.AddForce(transform.right * speed);
        }
    }

    private void AddEventTrigger(EventTrigger trigger, EventTriggerType eventType, UnityEngine.Events.UnityAction callback)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry { eventID = eventType };
        entry.callback.AddListener(new UnityEngine.Events.UnityAction<BaseEventData>((data) => { callback.Invoke(); }));
        trigger.triggers.Add(entry);
    }

    private void ApplyForwardForce()
    {
        rb.AddForce(transform.forward * speed);
    }

    private void ApplyBackwardForce()
    {
        rb.AddForce(-transform.forward * speed);
    }

    private void ApplyLeftForce()
    {
        rb.AddForce(-transform.right * speed);
    }

    private void ApplyRightForce()
    {
        rb.AddForce(transform.right * speed);
    }
    private void ApplyFasterForwardForce()
    {
        rb.AddForce(transform.forward * speed * 2f);
    }


    public void Respawn()
    {
        if (respawnPoint != null)
        {
            transform.position = respawnPoint.position;
            transform.rotation = respawnPoint.rotation;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(shootProjectile))]
public class projectTrajectory : MonoBehaviour
{
    public float velocity;
    public float baseVelocity;
    public float maxVelocity;
    public float gravity;
    public Transform launchPosition;
    public LineRenderer lineRenderer;
    public int maxPoints;
    public bool isProjecting;
    public float currentHold;
    public float timeBeforeAugmentingVelocity;
    public float maxHold;
    public InputActionReference holdButton;
    public InputActionReference holdReleaseButton;
    public GameObject hitPointMarker;
    public LayerMask layerMask;
    public ActionBasedController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = transform.parent.gameObject.GetComponent<ActionBasedController>();
        lineRenderer = GetComponent<LineRenderer>();
        isProjecting = false;
        lineRenderer.enabled = false;
        holdButton.action.performed += ctx => HoldTrigger();
        holdReleaseButton.action.performed += ctx => HoldReleaseTrigger();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isProjecting && GetComponent<InventoryManager>().IsFull())
        {
            project();
            // increase velocity based on how long the button is held
            // vibrate till release
            // vibration should rise up as the maxhold time is reached
            currentHold += Time.fixedDeltaTime;
            if (currentHold > maxHold)
            {
                currentHold = maxHold;
            }
            if (currentHold > timeBeforeAugmentingVelocity)
            {
                velocity = Mathf.Lerp(baseVelocity, maxVelocity, (currentHold - timeBeforeAugmentingVelocity) / (maxHold - timeBeforeAugmentingVelocity));
            }

            controller.SendHapticImpulse(currentHold / maxHold, 0.5f);

            Debug.Log("velocity: " + velocity);
        }
        else if (isProjecting && !GetComponent<InventoryManager>().IsFull())
        {
            Debug.Log("Empty");
        }
    }

    public void project()
    {
        // play haptics when projecting
        
        // Set the line renderer to be visible
        lineRenderer.enabled = true;
        // The idea is to project the trajectory of the object till it hits the ground
        // the trajectory is forward with gravity acting on it
        lineRenderer.positionCount = maxPoints;
        Vector3[] positions = new Vector3[maxPoints];
        Vector3 velocityVector = launchPosition.forward * velocity;
        Vector3 currentVelocity = velocityVector;
        Vector3 currentPosition = launchPosition.position;
        positions[0] = currentPosition;
        for (int i = 1; i < maxPoints; i++)
        {
            // Calculate the new position
            currentPosition += currentVelocity * Time.fixedDeltaTime;
            // Calculate the new velocity
            currentVelocity -= Vector3.up * gravity * Time.fixedDeltaTime;
            positions[i] = currentPosition;
            // Check if the object has hit something
            //TODO : change with a collision check
            Vector3 previouspoint = positions[i - 1];
            Vector3 currentpoint = positions[i];
            Vector3 segmentDirection = (currentpoint - previouspoint).normalized;

            Ray ray = new Ray(previouspoint, segmentDirection);
            RaycastHit hit;
            // exclude layer
            if (Physics.Raycast(ray, out hit, Vector3.Distance(previouspoint, currentpoint), layerMask))
            {
                // If the object has hit something, stop projecting
                lineRenderer.positionCount = i + 1;
                positions[i] = hit.point;
                // display the hit point
                hitPointMarker.SetActive(true);
                hitPointMarker.transform.position = hit.point;
                break;
            } else
            {
                hitPointMarker.SetActive(false);
            }
        }
        lineRenderer.SetPositions(positions);
    }

    public void HoldReleaseTrigger()
    {
        if (this.GetComponent<InventoryManager>().IsFull() && !this.GetComponent<suckProjectile>().isSucking)
        {
            GetComponent<shootProjectile>().shoot(launchPosition, launchPosition.forward, velocity);
            controller.SendHapticImpulse(0f, 0.5f);
        }
        isProjecting = false;
        hitPointMarker.SetActive(false);
        lineRenderer.enabled = false;
        currentHold = 0f;
        velocity = baseVelocity;
    }

    public void HoldTrigger()
    {
        if (this.GetComponent<suckProjectile>().isSucking)
        {
            return;
        }
        isProjecting = true;
    }
}

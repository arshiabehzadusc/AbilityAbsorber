using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;
    public Vector2 overviewEndPoint; // Add this to set the end point in the Inspector
    public float overviewSpeed = 1f;
    private bool gameStarted = false;
    private Vector3 originalPosition; // To remember the original position
    public PlayerMovement playerMov;
    public static event Action OnOverviewComplete;

    void Start () {
        originalPosition = transform.position; // Store the original position at the start
        StartCoroutine(StartGameOverview());
    }

    IEnumerator StartGameOverview() {
        Vector3 endPosition = new Vector3(overviewEndPoint.x, overviewEndPoint.y, transform.position.z);
        playerMov.enabled = false;
        // lerp to the end position
        float t = 0;
        while (t < 1) {
            t += Time.deltaTime * overviewSpeed;
            transform.position = Vector3.Lerp(originalPosition, endPosition, t);
            yield return null;
        }

        // then lerp back to the original position
        t = 0;
        while (t < 1) {
            t += Time.deltaTime * overviewSpeed;
            transform.position = Vector3.Lerp(endPosition, originalPosition, t);
            yield return null;
        }

        gameStarted = true;

        // trigger event when overview movement is complete
        OnOverviewComplete?.Invoke();
        playerMov.enabled = true;
    }
    
    void LateUpdate () {
        if(gameStarted && transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x,
                                                 target.position.y,
                                                 transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x,
                                           minPosition.x,
                                           maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y,
                                           minPosition.y,
                                           maxPosition.y);
            
            transform.position = Vector3.Lerp(transform.position,
                                             targetPosition, smoothing);
        }
    }

    private Vector3 RoundPosition(Vector3 position)
    {
        float xOffset = position.x % .0625f;
        if(xOffset != 0)
        {
            position.x -= xOffset;
        }
        float yOffset = position.y % .0625f;
        if(yOffset != 0)
        {
            position.y -= yOffset;
        }
        return position;
    }
}

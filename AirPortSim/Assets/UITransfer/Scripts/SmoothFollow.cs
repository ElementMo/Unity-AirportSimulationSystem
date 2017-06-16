using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {

    public float distance = 10.0f;
    public float height = 5.0f;
    public float heightDamping = 2.0f;
    public float rotationDamping = 3.0f;
    public float offsetHeight = 1.0f;
    Transform selfTransform;

    public Transform Target;
    [AddComponentMenu("Camera-Control/Smooth Follow")]
	void Start () {
        selfTransform = GetComponent<Transform>();
	}
	
	void LateUpdate () {
        if (!Target)
            return;

        float wantedRotationAngle = Target.eulerAngles.y;
        float wantedHeight = Target.position.y + height;

        float currentRotationAngle = selfTransform.eulerAngles.y;
        float currentHeight = selfTransform.position.y;

        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        selfTransform.position = Target.position;
        selfTransform.position -= currentRotation * Vector3.forward * distance;

        Vector3 currentPosition = transform.position;
        currentPosition.y = currentHeight;
        selfTransform.position = currentPosition;

        selfTransform.LookAt(Target.position + new Vector3(0, offsetHeight, 0));
	}
}

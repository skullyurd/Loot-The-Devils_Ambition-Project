using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowe : MonoBehaviour
{
	public Transform player;
	public float speed = 0.125f;
	public Vector3 offset;

    private void Awake()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void FixedUpdate()
	{
		Vector3 desiredPosition = player.position + offset;
		transform.position = desiredPosition;
	}
}

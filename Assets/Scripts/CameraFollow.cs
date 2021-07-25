using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    Vector3 offset;
    private float y;
    public float Speedfollow = 5;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 followpos = target.position + offset;
        RaycastHit hit;

        if (Physics.Raycast(target.position, Vector3.down, out hit, 2.5f))
        {
            y = Mathf.Lerp(y, hit.point.y, Time.deltaTime * Speedfollow);
        }
        else
        {
            y = Mathf.Lerp(y, target.position.y, Time.deltaTime * Speedfollow);
        }

        followpos.y = offset.y + y;

        transform.position = followpos;
    }
}

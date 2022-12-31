using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector2 minPos;
    public Vector2 maxPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPos = new Vector3(target.transform.position.x, target.position.y, transform.position.z);

            targetPos.x = Mathf.Clamp(target.position.x, minPos.x, maxPos.x);
            targetPos.y = Mathf.Clamp(target.position.y, minPos.y, maxPos.y);

            transform.position = Vector3.Lerp(transform.position, targetPos, 1);
        }
    }
}

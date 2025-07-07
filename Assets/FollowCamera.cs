using UnityEditor.SearchService;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // object variable, set in Unity
    [SerializeField] GameObject followObject;
    void Start()
    {
        // init selecting 'Car' object
        followObject = GameObject.Find("Car");
    }
    void LateUpdate()
    {
        // after other objects update, updates camera position to follow selected object
        transform.position = followObject.transform.position + new Vector3(0, 0, -10);
    }
}

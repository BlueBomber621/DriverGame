using UnityEditor.SearchService;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject followObject;
    //camera should be the same as the car's position
    void Start()
    {
        followObject = GameObject.Find("Car");
    }
    void LateUpdate()
    {
        transform.position = followObject.transform.position + new Vector3(0, 0, -10);
    }
}

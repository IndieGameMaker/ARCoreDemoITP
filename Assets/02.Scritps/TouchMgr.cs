using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class TouchMgr : MonoBehaviour
{
    public Camera arCamera;
    public GameObject monster;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);

        TrackableHit hit;
        TrackableHitFlags mask = TrackableHitFlags.FeaturePointWithSurfaceNormal
                                | TrackableHitFlags.PlaneWithinPolygon;

        if (touch.phase == TouchPhase.Began
            && Frame.Raycast(touch.position.x, touch.position.y, mask, out hit))
        {
            var anchor = hit.Trackable.CreateAnchor(hit.Pose);
            GameObject _monster = Instantiate(monster
                                            , hit.Pose.position
                                            , Quaternion.identity
                                            , anchor.transform);
        } 
    }
}

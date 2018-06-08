using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GunParameters", menuName = "Params/GunParameters")]
public class GunParams : ScriptableObject {

    [Range(1, 5)]
    public int mass;

    [Range(2, 20)]
    public int speed;

    [Range(2, 20)]
    public int timeToLive;

    // field for testing purposes
    public PrimitiveType bulletShape;

}

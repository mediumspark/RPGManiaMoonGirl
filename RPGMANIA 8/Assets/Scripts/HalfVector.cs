using System;
using UnityEngine;

//namespace HalfVector { }

[Serializable]
public struct Vec3
{
    public float x, y, z;

    public Vec3(float x, float y, float z)
    {
        this.x = x; this.y = y; this.z = z;
    }

    public static Vector3 ToVector3(float x, float y, float z) => new Vector3(x, y, z);
    public static Vector3 ToVector3(Vec3 vector) => new Vector3(vector.x, vector.y, vector.z);
    public static Vec3 ToVec3(Vector3 vector) => new Vec3(vector.x, vector.y, vector.z);
}


public static class HalfVector
{
    //Down
    public static Vector3 HalfForward => Vector3.forward / 2;  
    public static Vector3 HalfBack => Vector3.back / 2;        
    public static Vector3 HalfUp => Vector3.up / 2;            
    public static Vector3 HalfDown => Vector3.down / 2;        
    public static Vector3 HalfLeft => Vector3.left / 2;        
    public static Vector3 HalfRight => Vector3.right / 2;

    public static Vector3 QuarterForward => Vector3.forward / 4;
    public static Vector3 QuarterBack => Vector3.back / 4;
    public static Vector3 QuarterUp => Vector3.up / 4;
    public static Vector3 QuarterDown => Vector3.down / 4;
    public static Vector3 QuarterLeft => Vector3.left / 4;
    public static Vector3 QuarterRight => Vector3.right / 4;
                          
    //Up
    public static Vector3 SesquiForward => Vector3.forward * 1.5f;
    public static Vector3 SesquiBack => Vector3.back * 1.5f;
    public static Vector3 SesquiUp => Vector3.up * 1.5f;
    public static Vector3 SesquiDown => Vector3.down * 1.5f;
    public static Vector3 SesquiLeft => Vector3.left * 1.5f;
    public static Vector3 SesquiRight => Vector3.right * 1.5f;

    public static Vector3 SesquodForward => Vector3.forward * 1.25f;
    public static Vector3 SesquodBack => Vector3.back * 1.25f;
    public static Vector3 SesquodUp => Vector3.up * 1.25f;
    public static Vector3 SesquodDown => Vector3.down * 1.25f;
    public static Vector3 SesquodLeft => Vector3.left * 1.25f;
    public static Vector3 SesquodRight => Vector3.right * 1.25f;

    /// <summary>
    /// (0.5f, 0.5f, 0.5f)
    /// </summary>
    public static Vector3 Half => Vector3.one / 2;
    public static Vector3 Sesqui => Vector3.one * 1.5f; 
}

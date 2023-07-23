using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreePiece : MonoBehaviour
{
    public float scale = 2.0f/3;
    public void Generate(int hashed) {
        int i = Unpair(hashed)[0];
        int s = Unpair(hashed)[1];
        // DEBUG: Print out current rotation
        Debug.Log("TreePiece.GenerateLeft: " + this.transform.rotation);
        // transform up and rotate left 45 degrees
        this.transform.position += this.transform.up * this.transform.localScale.y;
        var object_bottom = this.transform.position - this.transform.up * this.transform.localScale.y / 2;
        // rotate around the base of the object rather than the center
        this.transform.RotateAround(object_bottom, this.transform.forward, this.DecideAngle(i, s));
                // shrink to scale
        this.transform.localScale *= scale;
        // correct the position by moving down half the size of the object
        this.transform.position -= this.transform.up * this.transform.localScale.y *(1-scale);
    }

    private int[] Unpair(int z) {
        int w = (int)Mathf.Floor((-1 + Mathf.Sqrt(1 + 8 * z)) / 2);
        int t = (w * w + w) / 2;
        int y = z - t;
        int x = w - y;
        return new int[] { x, y };
    }

    private float DecideAngle(int i, int s) {
        float[] angles = new float[s];
        float angle = 90/s;
        if(s % 2 == 1) {
            angles[s/2] = 0f;
        }
        for(int j = 0; j < s/2; j++) {
            angles[j] = -angle * (j+1);
            angles[s-j-1] = angle * (j+1);
        }
        return angles[i];
    }
}

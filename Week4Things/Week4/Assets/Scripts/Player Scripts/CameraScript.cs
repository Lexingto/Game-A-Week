using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraScript : MonoBehaviourPun
{
    public Transform attachedPlayer;
    public float blendAmount = 0.05f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Vector3 player = attachedPlayer.transform.position;
        Vector3 newCamPos = player * blendAmount
            + transform.position * (1.0f - blendAmount);
        transform.position = new Vector3(newCamPos.x, newCamPos.y, transform.position.z);
    }
}

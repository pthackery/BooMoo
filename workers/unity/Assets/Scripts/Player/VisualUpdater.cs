using Improbable;
using Improbable.Gdk.GameObjectRepresentation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VisualUpdater : MonoBehaviour
{

    [Require] private Position.Requirable.Reader positionReader;
    void OnPositionUpdate(Coordinates update)
    {
        Vector3 newPos = new Vector3((float)update.X, (float)update.Y, (float)update.Z);
        gameObject.transform.position = newPos;
    }
    private void OnEnable()
    {
        //Debug.LogError("Launching");
        positionReader.CoordsUpdated += OnPositionUpdate;
    }
    //why is this so complicated
}
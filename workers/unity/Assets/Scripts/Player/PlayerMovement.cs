using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Improbable.Gdk.GameObjectRepresentation;
using Improbable.Player;
using Improbable;

namespace Assets.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Require] private PlayerControls.Requirable.Reader inputReader;
        [Require] private Position.Requirable.Writer positionWriter;

        float speed = .5f;

        private void OnEnable()
        {
            inputReader.OnMovementUpdate += OnControlUpdate;
        }

        void OnControlUpdate(MovementUpdate update)
        {
            Vector2 control = new Vector2(update.X, update.Y);
            control.Normalize();
            control = control * speed;

            Vector3 newPos = this.transform.position;
            newPos.x = newPos.x + control.x;
            newPos.z = newPos.z + control.y;
            this.transform.position = newPos;

            Coordinates serverPos = new Coordinates((double)newPos.x, (double)newPos.y, (double)newPos.z);

            positionWriter.Send(new Position.Update
            {

                Coords = serverPos


            });
           
        }

    }
}

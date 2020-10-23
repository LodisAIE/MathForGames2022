using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    class Enemy : Actor
    {
        public Actor target;
        public Vector2 facing;

        public Enemy(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, icon, color)
        {

        }

        public Enemy(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, rayColor, icon, color)
        {
            facing = new Vector2(1, 0);
        }

        public bool CheckIfActorSeen(Actor actor, float maxViewAngle, float maxViewDistance)
        {

            Vector2 direction = actor.Position - Position;
            float angle = (float)Math.Acos(Vector2.DotProduct(facing, direction.Normalized));
            if ( angle <= maxViewAngle && direction.Magnitude <= maxViewDistance)
                return true;

            return false;
        }

        public override void Update()
        {
            if (CheckIfActorSeen(target, 1, 2))
            {
                _rayColor = Color.WHITE;
            }
            else
            {
                _rayColor = Color.GREEN;
            }
            base.Update();
        }
    }
}

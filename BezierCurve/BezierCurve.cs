using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BezierCurve
{

    public class BezierCurve
    {
        private readonly Vector2[] controlPoints;

        public BezierCurve(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, Vector2 p5)
        {
            controlPoints = new[] { p1, p2, p3, p4, p5 };
        }


        public Vector2 CalculateBezierPoint(float t)
        {
            float u = 1 - t;
            float tt = t * t;
            float uu = u * u;
            float uuu = uu * u;
            float ttt = tt * t;

            Vector2 p = uuu * controlPoints[0]; // (1-t)^3 * P0
            p += 3 * uu * t * controlPoints[1]; // 3(1-t)^2 * t * P1
            p += 3 * u * tt * controlPoints[2]; // 3(1-t) * t^2 * P2
            p += ttt * controlPoints[3]; // t^3 * P3

            return p;
        }

        public void Draw(SpriteBatch spriteBatch, int segments,Texture2D pixelTexture)
        {       
            Vector2 previousPoint = controlPoints[0];

            for (int i = 1; i <= segments; i++)
            {
                float t = i / (float)segments;
                Vector2 currentPoint = CalculateBezierPoint(t);
                DrawLine(spriteBatch,previousPoint, currentPoint, Color.White,pixelTexture);
                previousPoint = currentPoint;
            }
        }

        // You can add this method to your code to draw a line between two points
        public static void DrawLine(SpriteBatch spriteBatch, Vector2 point1, Vector2 point2, Color color, Texture2D pixelTexture, int lineWidth = 1)
        {
            float angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
            float length = Vector2.Distance(point1, point2);

            spriteBatch.Draw(
                pixelTexture,                  // A 1x1 pixel texture
                point1,                        // Starting point
                null,
                color,                         // Color of the line
                angle,                         // Angle of the line
                Vector2.Zero,                  // Origin of the line (top-left corner)
                new Vector2(length, lineWidth), // Scale of the line (length and width)
                SpriteEffects.None,
                0
            );
        }
    }

}
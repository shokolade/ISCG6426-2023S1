using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;

namespace sfml_list_example
{
    /// <summary>
    /// Class that extends SFML CircleShape. Provides a link to connect
    /// two Balls together with a line.
    /// </summary>
    public class Ball : CircleShape
    {
        private RectangleShape ballLink;
        private Vector2f velocity;
        private float linkWidth;
        private Color lineFillColour;

        public Ball(Color fillColour, Color lineColour, float radius = 20, int pointCount = 30, int lineWidth = 1) : base(radius, (uint)pointCount)
        {
            this.ballLink = null;
            this.velocity = new Vector2f(0, 0);
            this.linkWidth = 2;
            this.lineFillColour = Color.White;
            this.Origin = new Vector2f(radius, radius);
            this.FillColor = fillColour;
            this.OutlineColor = lineColour;
            this.OutlineThickness = lineWidth;
        }

        public void setLinkVisuals(Color colour, float linkWidth)
        {
            this.lineFillColour = colour;
            this.linkWidth = linkWidth;
        }

        public void setPosition(float x, float y)
        {
            this.setPosition(new Vector2f(x, y));
        }

        public void setPosition(Vector2f position)
        {
            this.Position = position;
        }

        public void offsetPosition(Vector2f offset)
        {
            this.setPosition(this.Position + offset);
        }

        public void setRotation(float angle)
        {
            this.Rotation = angle;
        }

        public void offsetRotation(float angle)
        {
            this.Rotation += angle;
        }

        public void setVelocity(float x, float y)
        {
            this.setVelocity(new Vector2f(x, y));
        }

        public void setVelocity(Vector2f vel)
        {
            this.velocity = vel;
        }

        public void setLinkWidth(float width)
        {
            this.linkWidth = width > 0 ? width : 1;
        }

        /// <summary>
        /// Calculate the distance and angle between this circle and another
        /// circle. Create a rectangle that connects the 2 circles together.
        /// </summary>
        /// <param name="position"></param>
        public void setLink(Vector2f position)
        {
            float distance = (float)MathLib2D.distance(this.Position, position);
            float angle = (float)MathLib2D.bearing(this.Position, position, false) - 90;

            Vector2f rectSize = new Vector2f(distance, this.linkWidth);
            if (this.ballLink == null)
                this.ballLink = new RectangleShape();
            this.ballLink.Size = rectSize;

            this.ballLink.Position = this.Position;
            this.ballLink.Origin = new Vector2f(0, this.linkWidth / 2);
            this.ballLink.Rotation = angle;
        }

        public void DrawLink(RenderTarget target, RenderStates state)
        {
            ballLink.Draw(target, state);
        }

        public void Draw(RenderTarget target, RenderStates state)
        {
            base.Draw(target, state);
        }

        public void Update(float deltaTime, Vector2f linkTarget, float ax, float ay, float bx, float by)
        {
            this.offsetPosition(this.velocity * deltaTime);
            this.setLink(linkTarget);
            CheckEdgeCollision(ax, ay, bx, by);
        }

        /// <summary>
        /// Check if the circle is outside the bounds of the window. Respond to a collision
        /// by reversing the direction of the ball in the axis.
        /// </summary>
        /// <param name="ax"></param>
        /// <param name="ay"></param>
        /// <param name="bx"></param>
        /// <param name="by"></param>
        public void CheckEdgeCollision(float ax, float ay, float bx, float by)
        {
            var left = ax + this.Radius;
            var right = bx - this.Radius;
            var top = ay + this.Radius;
            var bottom = by - this.Radius;
            // left
            if (this.Position.X < left)
            {
                this.velocity.X = -this.velocity.X;
                this.Position = new Vector2f(left, this.Position.Y);
            }
            // right
            else if (this.Position.X > right)
            {
                this.velocity.X = -this.velocity.X;
                this.Position = new Vector2f(right, this.Position.Y);
            }
            // top
            if (this.Position.Y < top)
            {
                this.velocity.Y = -this.velocity.Y;
                this.Position = new Vector2f(this.Position.X, top);
            }
            else if (this.Position.Y > bottom)
            {
                this.velocity.Y = -this.velocity.Y;
                this.Position = new Vector2f(this.Position.X, bottom);
            }
        }
    }
}

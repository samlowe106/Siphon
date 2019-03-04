using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Siphon
{
    /// <summary>
    /// GameObject from which the player, enemies, and structures will inherit
    /// </summary>
	abstract class GameObject : IDisplayable
	{
        #region Fields

        // MonoGame-relevant fields
        protected Vector2 position;
        protected Texture2D texture;
        protected Rectangle rectangle;
        protected Vector2 direction;
        protected bool active;
        protected float angle;
        protected Vector2 origin;
        protected Vector2 speed;
        #endregion

        #region Constructor
        /// <summary>
        /// Basic constructor, with parameters only necessary for MonoGame
        /// </summary>
        /// <param name="position">The position of the GameObject's center</param>
        /// <param name="texture">The GameObject's texture</param>
        /// <param name="width">The width of this GameObject</param>
        /// <param name="height">The height of this GameObject</param>
        public GameObject(Vector2 position, Texture2D texture, int width, int height, int screenWidth, int screenHeight)
        {
            // Set this object's speed to be 2% of the screen width and height
            this.speed = new Vector2(screenWidth * 0.02f, screenHeight * 0.02f);
            this.position = position;
            this.texture = texture;
            this.rectangle = new Rectangle((int)(position.X - width/2), (int)(position.Y - width/2), width, height);
            this.active = true;
            this.origin = new Vector2(texture.Width / 2, texture.Height / 2);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Draws this GameObject's texture (if this object is active)
        /// </summary>
        /// <param name="sp">The current spritebatch</param>
        public virtual void Draw(SpriteBatch sp)
        {
            if (this.active)
            {

                sp.Draw(texture, position, null, Color.White, (float)(angle + (Math.PI / 2)), origin, 1f, SpriteEffects.None, 1f);

                /*sp.Draw(texture,
                    rectangle,
                    null,
                    Color.White,
                    (float)(angle),
                    origin,                    
                    SpriteEffects.None,
                    0); */
                    
               
                
            }
        }

        /// <summary>
        /// Updates this object. Base method is empty
        /// </summary>
        public virtual void Update() { }

        /// <param name="obj">Object to compare this object's distance to</param>
        /// <returns>The distance from this object to another object</returns>
        public double GetDistance(GameObject obj)
        {
            return Math.Sqrt(Math.Pow(obj.position.X - this.position.X, 2) + Math.Pow(obj.position.Y - this.position.Y, 2));
        }

        /// <param name="obj">Object to compare this object's distance to</param>
        /// <returns>A vector representing the distance from this object to the specified GameObject</returns>
        public Vector2 GetDistanceVector(GameObject obj)
        {
            return obj.position - this.position;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectComparedTo"></param>
        /// <returns></returns>
        public float SetAngle(int objX, int objY)
        {
            direction.X = objX - this.Position.X;
            direction.Y = objY - this.Position.Y;

            angle = (float)Math.Atan2(direction.Y, direction.X);
            return angle;
        }
        #endregion

        #region Properties


        /// <summary>
        /// Whether this object should be drawn to the screen or not
        /// </summary>
        public bool Active
        {
            get
            {
                return active;
            }
        }

        /// <summary>
        /// Vector2 representing this object's position
        /// </summary>
        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        /// <summary>
        /// Floating point number representing the angle that this object is facing
        /// </summary>
        public float Angle
        {
            get
            {
                return angle;
            }
            set
            {
                angle = value;
            }
        }

        #endregion
    }
}

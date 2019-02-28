﻿using System;
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

        #endregion

        #region Constructor

        /// <summary>
        /// Basic constructor, with parameters only necessary for MonoGame
        /// </summary>
        /// <param name="position">The GameObject's position</param>
        /// <param name="texture">The GameObject's texture</param>
        /// <param name="x">The upper top-left x coordinate of the GameObject's position</param>
        /// <param name="y">The upper top-left y coordinate of the GameObject's position</param>
        /// <param name="width">The width of this GameObject</param>
        /// <param name="height">The height of this GameObject</param>
        public GameObject(Vector2 position, Texture2D texture, int x, int y, int width, int height)
        {
            this.position = position;
            this.texture = texture;
            this.rectangle = new Rectangle(x, y, width, height);
            this.active = true;
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
        }

        #endregion

        #region Methods
        /// <summary>
        /// Draws this GameObject's texture (if this object is active)
        /// </summary>
        /// <param name="sp">The current spritebatch</param>
        public void Draw(SpriteBatch sp)
        {
            if (this.active)
            {
                //Draws Player
                sp.Draw(texture,
                    position,
                    null,
                    Color.White,
                    angle,
                    origin,
                    1f,
                    SpriteEffects.None,
                    1f);
                
               
                
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectComparedTo"></param>
        /// <returns></returns>
        public float SetAngle(int objX, int objY)
        {
            direction.X = objX - this.Position.X;
            direction.Y = objY - this.Position.Y;

            angle = (float)(Math.Atan2(direction.Y, direction.X) + Math.PI / 2);
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
        }

        #endregion
    }
}

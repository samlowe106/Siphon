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
	abstract class GameObject : IDamageable, IDisplayable
	{
        // MonoGame-relevant fields
        protected Vector2 position;
        protected Texture2D texture;
        protected Rectangle rectangle;

        // Siphon-relevant fields
        protected float armorRating;
        protected int currentHealth;
        protected int maxHealth;
        protected bool active;

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
            this.armorRating = 0f; // we may decide to change this default value later
            // TODO: initialize maxHealth to a default value
            this.currentHealth = this.maxHealth;
            this.active = true;
        }

        /// <summary>
        /// Overloaded constructor with additional parameters relevant to game mechanics
        /// </summary>
        /// <param name="position">The GameObject's position</param>
        /// <param name="texture">The GameObject's texture</param>
        /// <param name="x">The upper top-left x coordinate of the GameObject's position</param>
        /// <param name="y">The upper top-left y coordinate of the GameObject's position</param>
        /// <param name="width">The width of this GameObject</param>
        /// <param name="height">The height of this GameObject</param>
        /// <param name="armorRating">The percentage amount of damage this object will ignore</param>
        /// <param name="maxHealth">The maximum amount of health this object has</param>
        public GameObject(Vector2 position, Texture2D texture, int x, int y, int width, int height,
            float armorRating, int maxHealth)
        {
            this.position = position;
            this.texture = texture;
            this.rectangle = new Rectangle(x, y, width, height);
            this.armorRating = armorRating;
            this.maxHealth = maxHealth;
            this.currentHealth = this.maxHealth;
            active = true;
        }

        /// <summary>
        /// Draws this GameObject's texture (if this object is active)
        /// </summary>
        /// <param name="sp">The current spritebatch</param>
        public void Draw(SpriteBatch sp)
        {
            if (this.active)
            {
                sp.Draw(this.texture, this.position, Color.White);
            }
        }

        /// <summary>
        /// Updates this object. Base method is empty
        /// </summary>
        public virtual void Update() { }

        /// <summary>
        /// Performs a basic damage calculation
        /// </summary>
        /// <param name="damage"></param>
        /// <returns></returns>
        public int TakeDamage(int damage)
        {
            // Calculates % of damage that will still go through, and reduces current health by that amount
            currentHealth =- (int)((float)damage * (100f - armorRating));
            // If this object has health less than or equal to zero, mark it as dead
            if (currentHealth <= 0)
            {
                active = false;
                // trigger the on-death event
            }
            return currentHealth - damage;
        }

        /// <param name="obj">Object to compare this object's distance to</param>
        /// <returns>The distance from this object to another object</returns>
        public double GetDistance(GameObject obj)
        {
            return Math.Sqrt(Math.Pow(obj.position.X - this.position.X, 2) + Math.Pow(obj.position.Y - this.position.Y, 2));
        }

        /// <summary>
        /// Amount of health that this object currently has
        /// </summary>
        public int CurrentHealth
        {
            get
            {
                return currentHealth;
            }
        }

        /// <summary>
        /// Maximum amount of health this object can have
        /// </summary>
        public int MaximumHealth
        {
            get
            {
                return maxHealth;
            }
        }

        /// <summary>
        /// Percentage of damage mitigated by this object
        /// </summary>
        public float ArmorRating
        {
            get
            {
                return armorRating;
            }
        }

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
	}
}

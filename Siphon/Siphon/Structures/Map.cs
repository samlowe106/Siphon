using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace Siphon
{
    class Map
    {

		#region Fields
		// fields 
		Structure[ , ] structures;
        private int sideLength;
        private int screenWidth;
        private int screenHeight;
        private Stack<gameState> stack;


        public MainStructure mainStructure;
        public Structure[,] Structures { get { return structures; } }

        // textures
        private Texture2D mainStructureTexture;
        private Texture2D turretTexture;
        private Texture2D bulletTexture;
        private Texture2D groundTexture;

		#endregion

		#region Properties

		public List<BasicTurret> Turrets
		{
			get
			{
				List<BasicTurret> turrets = new List<BasicTurret>();
				foreach (Structure structure in structures)
				{
					if (structure is BasicTurret)
					{
						turrets.Add((BasicTurret)structure);
					}
				}
				return turrets;
			}
		}

		#endregion

		#region Contructor

		public Map(int screenWidth, int screenHeight, Texture2D mainStructureTexture, Texture2D turretTexture, Texture2D bulletTexture, Texture2D groundTexture, Stack<gameState> stack)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.mainStructureTexture = mainStructureTexture;
			this.turretTexture = turretTexture;
			this.bulletTexture = bulletTexture;
			this.groundTexture = groundTexture;
            this.stack = stack;

            Load();
        }

		#endregion

		#region Medthods

		private void Load()
        {
            Load("..\\..\\..\\..\\Content\\demo.level");
            //Load("..\\..\\..\\..\\Content\\empty.level");
        }

        private void Load(string filePath)
        {
            Stream inStream = File.OpenRead(filePath);
            BinaryReader input = new BinaryReader(inStream);

            int height = input.ReadInt32();
            int width = input.ReadInt32();
            //set enemy health to input.ReadInt32()
            //set enemy damage to input.ReadInt32()
            //set turret health to input.ReadInt32()
            //set enemy damage to input.ReadInt32()
            //set main structure health to input.ReadInt32()
            structures = new Structure[height, width];

            sideLength =(int)((screenHeight / height) * 0.8);

            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    switch (input.ReadInt32())
                    {
                        case 0:
							structures[r, c] = new EmptyTile(new Vector2(
																(int)((screenWidth / 2) - (4.5 - c) * sideLength),
																(int)((screenHeight / 2) - (4.5 - r) * sideLength)),
																groundTexture, this, r, c,
																sideLength, true);
                            break;
                        case 1:
							structures[r, c] = new BasicTurret(new Vector2(
																(int)((screenWidth / 2) - (4.5 - c) * sideLength), 
																(int)((screenHeight / 2) - (4.5 - r) * sideLength)), 
                                                                turretTexture, bulletTexture, groundTexture,
																sideLength);
							break;
                        case 2:
							if (mainStructure == null)
							{
								mainStructure = new MainStructure(new Vector2(
																	(int)((screenWidth / 2) - (4 - c) * sideLength),
																	(int)((screenHeight / 2) - (4 - r) * sideLength)),
																	mainStructureTexture,
																	sideLength * 2);
								structures[r, c] = mainStructure;
							}
							break;
                    }
                }
            }
        }

        public void Update(List<Enemy> enemies, MouseState currentMouseState, MouseState previousMouseState, bool BuildPhase, GameTime gameTime)
        {
            foreach (Structure structure in structures)
            {
				if (structure is BasicTurret)
				{
					((BasicTurret)structure).Update(enemies, gameTime);
				}
				if (structure is EmptyTile)
				{
					((EmptyTile)structure).Update(enemies, currentMouseState, previousMouseState, BuildPhase);
				}
			}

            if (!mainStructure.Active)
            {
				Load();
				stack.Pop();
            }
        }

        public void Draw(SpriteBatch sp)
        {
            foreach (Structure structure in structures)
            {
                if (structure != null)
                    structure.Draw(sp);
            }
        }

		public void placeTurret(int rows, int cols)
		{
			structures[rows, cols] = new BasicTurret(new Vector2(
												(int)((screenWidth / 2) - (4.5 - cols) * sideLength),
												(int)((screenHeight / 2) - (4.5 - rows) * sideLength)),
												turretTexture, bulletTexture, groundTexture,
												sideLength);
		}

		#endregion
	}
}

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
	enum TurretType { Wall, Turret };
	
    class Map
    {

		#region Fields
		// fields 
		Structure[ , ] structures;
        private int sideLength;
        private int screenWidth;
        private int screenHeight;
        private Stack<gameState> stack;
        private Bank bank;

        public MainStructure mainStructure;
        public Structure[,] Structures { get { return structures; } }

        // textures
        private Texture2D mainStructureTexture;
        private Texture2D turretTexture;
        private Texture2D wallTexture;
        private Texture2D bulletTexture;
        private Texture2D groundTexture;
        private Texture2D healthBar;

		#endregion

		#region Properties

		public List<Structure> Turrets
		{
			get
			{
				List<Structure> turrets = new List<Structure>();
				foreach (Structure structure in structures)
				{					
                    if (!(structure is EmptyTile) && (structure != null) && (structure.Active))
						turrets.Add(structure);					
				}
				return turrets;
			}
		}

		#endregion

		#region Contructor

		public Map(int screenWidth, int screenHeight, TextureManager textureManager, Stack<gameState> stack, Bank bank)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;

            mainStructureTexture = textureManager.batteryTexture;
			turretTexture = textureManager.turret;
			bulletTexture = textureManager.bullet;
			groundTexture = textureManager.groundTexture;
			healthBar = textureManager.healthBar;
            wallTexture = textureManager.wall;

            this.bank = bank;
            this.stack = stack;

            Load();
        }

		#endregion

		#region Medthods

		private void Load()
        {
            //Load("..\\..\\..\\..\\Content\\demo.level");
            Load("..\\..\\..\\..\\Content\\empty.level");
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
																groundTexture, bank, this, r, c,
																sideLength, true);
                            break;

                        case 1:
							structures[r, c] = new BasicTurret(new Vector2(
																(int)((screenWidth / 2) - (4.5 - c) * sideLength), 
																(int)((screenHeight / 2) - (4.5 - r) * sideLength)), 
                                                                turretTexture, bulletTexture, groundTexture, healthBar,
																sideLength, r, c, this, bank);
							break;

                        case 2:
							if (mainStructure == null)
							{
								mainStructure = new MainStructure(new Vector2(
																	(int)((screenWidth / 2) - (4 - c) * sideLength),
																	(int)((screenHeight / 2) - (4 - r) * sideLength)),
																	mainStructureTexture, groundTexture, healthBar,
																	sideLength * 2);
								structures[r, c] = mainStructure;
							}
							break;

						case 3:
							structures[r, c] = new Wall(new Vector2(
																(int)((screenWidth / 2) - (4.5 - c) * sideLength),
																(int)((screenHeight / 2) - (4.5 - r) * sideLength)),
																wallTexture, groundTexture, healthBar, bank, this,
																sideLength, r, c);
							break;
					}
                }
            }
        }

        public void repairUpdate(MouseState mouse, bool repair)
        {
            foreach(Structure structure in structures)
            {
                if (structure != null && !structure.Active && (structure is BasicTurret))
                {
                    ((BasicTurret)structure).RepairOrDestroy(mouse, repair);
                }
                if (structure != null && !structure.Active && (structure is Wall))
                {
                    ((Wall)structure).RepairOrDestroy(mouse, repair);
                }
            }
        }

        public void Update(List<Enemy> enemies, MouseState currentMouseState, MouseState previousMouseState, bool BuildPhase, GameTime gameTime, bool repair, TurretType type)
        {
            foreach (Structure structure in structures)
            {
				if ((structure is BasicTurret) && (structure.Active))
				{
					((BasicTurret)structure).Update(enemies, gameTime);
				}
				if (structure is EmptyTile)
				{
					((EmptyTile)structure).Update(enemies, currentMouseState, previousMouseState, BuildPhase, type);
				}
			}

            if (BuildPhase)
            {
                repairUpdate(currentMouseState, repair);
            }

            if (mainStructure.endGame)
            {
				stack.Push(gameState.EndGame);
            }
        }

        public void Draw(SpriteBatch sp)
        {
            foreach (Structure structure in structures)
            {
				if (structure != null)
				{
					structure.Draw(sp);
				}
            }
        }

		public void placeTurret(int rows, int cols, TurretType type)
		{
			switch (type)
			{
				case TurretType.Turret:
					if (bank.Purchase(100))
						structures[rows, cols] = new BasicTurret(new Vector2(
												(int)((screenWidth / 2) - (4.5 - cols) * sideLength),
												(int)((screenHeight / 2) - (4.5 - rows) * sideLength)),
												turretTexture, bulletTexture, groundTexture, healthBar,
												sideLength, rows, cols, this, bank);
					break;

				case TurretType.Wall:
					if (bank.Purchase(50))
						structures[rows, cols] = new Wall(new Vector2(
												(int)((screenWidth / 2) - (4.5 - cols) * sideLength),
												(int)((screenHeight / 2) - (4.5 - rows) * sideLength)),
												wallTexture, groundTexture, healthBar, bank, this,
												sideLength, rows, cols);
					break;
			}
		}

        public void removeTurret(int rows, int cols)
        {
            structures[rows, cols] = new EmptyTile(new Vector2(
                              (int)((screenWidth / 2) - (4.5 - cols) * sideLength),
                              (int)((screenHeight / 2) - (4.5 - rows) * sideLength)),
                              groundTexture, bank, this, rows, cols,
                              sideLength, true);
        }

        #endregion
    }
}

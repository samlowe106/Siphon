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
        // fields 
        Structure[ , ] structures;
        private int sideLength;
        private int screenWidth;
        private int screenHeight;

        // textures
        private Texture2D mainStructureTexture;

        public Map(int screenWidth, int screenHeight, Texture2D mainStructureTexture)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.mainStructureTexture = mainStructureTexture;

            Load();
        }

        private void Load()
        {
            Load("empty.level");
        }

        private void Load(string filePath)
        {
            Stream inStream = File.OpenRead(filePath);
            BinaryReader input = new BinaryReader(inStream);

            int height = input.ReadInt32();
            int width = input.ReadInt32();
            structures = new Structure[height, width];

            sideLength = screenHeight / height;

            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    switch (input.ReadInt32())
                    {
                        case 0:
                            structures[r, c] = null;
                            break;
                        case 1:
                            //structures[r, c] = TURRET
                            break;
                        case 2:
                            structures[r, c] = new MainStructure(new Vector2((screenWidth / 2) - (r - width / 2) * sideLength, 
                                                                (screenHeight / 2) - (r - height / 2) * sideLength), 
                                                                mainStructureTexture, 
                                                                (screenWidth / 2) - (r - 5) * sideLength, 
                                                                (screenHeight / 2) - (r - 5) * sideLength, 
                                                                sideLength * 2, sideLength * 2);
                            break;
                    }
                }
            }
        }

    }
}

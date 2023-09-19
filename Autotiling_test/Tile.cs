using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Net.Sockets;

namespace Autotiling1
{
    internal class Tile
    {
        Texture2D texture;
        int[,] constraint;
  

        public Tile(Texture2D texture, int[,] constraint)
        {
            this.texture = texture;
            this.constraint = constraint;

            
        }
        public Texture2D Texture { get { return texture; }set { texture = value; } }
        public int[,] Constraint {   get { return constraint; }  set { constraint = value; }  }
    }
}

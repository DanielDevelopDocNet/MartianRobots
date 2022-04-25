using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaSRV.Models
{
    public class Planet
    {
        public Point Dimension { get; private set; }

        public Planet(int x, int y)
        {
            Dimension = new Point(x, y);

        }
    }
}

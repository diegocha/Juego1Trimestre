﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace Refactoring
{
    class MovVertical:Pelota
    {   

        static Random rnd = new Random();

        public MovVertical(List<Obstaculos> LObstaculos)
            : base(LObstaculos)
        {
        }
        public MovVertical():base()
        {

        }

        public int ObtenerDir()
        {
            return m;
        }

        public void CambiarDir()
        {
            if (m == 0) m = 1;
            else m = 0;
        }

        public MovVertical(int proximo, int delta,int x, int y) : base(proximo, delta) 
        {
            pos.x = x;
            pos.y = y;
        }

        public override void mover()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.WriteLine(" ");

            switch (m) //Direccion
            {
                case 0:
                    pos.y--;
                    break;

                case 1:
                    pos.y++;
                    break;
            }
            Imprimir();

            //Limites

            if (pos.y <= 1 && m == 0) m = 1;
            if (pos.y == 55 && m == 1) m = 0;

        }

        public override void Intersecta(Obstaculos obs)
        {
            if (pos.x >= obs.ObtenerX() && pos.x < (obs.ObtenerX() + obs.ObtenerW()) && pos.y >= obs.ObtenerY()-1 && pos.y < (obs.ObtenerY() + obs.ObtenerH()))
            {
                if (m == 0) m = 1;
                else m = 0;
            }
        }

        public void Imprimir()
        {
            Console.ForegroundColor = color;

            Console.SetCursorPosition(pos.x, pos.y);
            Console.WriteLine("*");

            Console.ForegroundColor = ConsoleColor.Black;
        }  
    }
}

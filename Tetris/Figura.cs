﻿using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace Tetris
{
    public class Figura : ICloneable
    {
        public List<Klocek> ListaKlocków { get; set; }

        private Figura()
        {
            ListaKlocków = new List<Klocek>();
        }

        public Figura(KszałtFigury kszałtFigury, Klocek klocekStartowy)
        {
            List<Klocek> kształt = null;

            switch (kszałtFigury)
            {
                case KszałtFigury.TetriminoI:
                    kształt = new List<Klocek>(new Klocek[] {
                                                            new Klocek(klocekStartowy.X+1, klocekStartowy.Y, Brushes.DarkGray),
                                                            new Klocek(klocekStartowy.X+1, klocekStartowy.Y+1, Brushes.DarkGray),
                                                            new Klocek(klocekStartowy.X+1, klocekStartowy.Y+2, Brushes.DarkGray),
                                                            new Klocek(klocekStartowy.X+1, klocekStartowy.Y+3, Brushes.DarkGray)});

                    break;
                case KszałtFigury.TetriminoT:
                    kształt = new List<Klocek>(new Klocek[] {
                                                            new Klocek(klocekStartowy.X, klocekStartowy.Y, Brushes.Tomato),
                                                            new Klocek(klocekStartowy.X+1, klocekStartowy.Y, Brushes.Tomato),
                                                            new Klocek(klocekStartowy.X+2, klocekStartowy.Y, Brushes.Tomato),
                                                            new Klocek(klocekStartowy.X+1, klocekStartowy.Y+1, Brushes.Tomato)});
                    break;
                case KszałtFigury.TetriminoO:
                    kształt = new List<Klocek>(new Klocek[] {
                                                            new Klocek(klocekStartowy.X, klocekStartowy.Y,  Brushes.Chocolate),
                                                            new Klocek(klocekStartowy.X, klocekStartowy.Y+1, Brushes.Chocolate),
                                                            new Klocek(klocekStartowy.X+1, klocekStartowy.Y, Brushes.Chocolate),
                                                            new Klocek(klocekStartowy.X+1, klocekStartowy.Y+1, Brushes.Chocolate)});
                    break;
                case KszałtFigury.TetriminoL:
                    kształt = new List<Klocek>(new Klocek[] {
                                                            new Klocek(klocekStartowy.X, klocekStartowy.Y, Brushes.DarkOrange),
                                                            new Klocek(klocekStartowy.X, klocekStartowy.Y+1, Brushes.DarkOrange),
                                                            new Klocek(klocekStartowy.X, klocekStartowy.Y+2, Brushes.DarkOrange),
                                                            new Klocek(klocekStartowy.X+1, klocekStartowy.Y+2, Brushes.DarkOrange)});
                    break;
                case KszałtFigury.TetriminoJ:
                    kształt = new List<Klocek>(new Klocek[] {
                                                            new Klocek(klocekStartowy.X+1, klocekStartowy.Y, Brushes.Gold),
                                                            new Klocek(klocekStartowy.X+1, klocekStartowy.Y+1, Brushes.Gold),
                                                            new Klocek(klocekStartowy.X+1, klocekStartowy.Y+2, Brushes.Gold),
                                                            new Klocek(klocekStartowy.X, klocekStartowy.Y+2, Brushes.Gold)});
                    break;
                case KszałtFigury.TetriminoS:
                    kształt = new List<Klocek>(new Klocek[] {
                                                            new Klocek(klocekStartowy.X+1, klocekStartowy.Y, Brushes.Olive),
                                                            new Klocek(klocekStartowy.X+2, klocekStartowy.Y, Brushes.Olive),
                                                            new Klocek(klocekStartowy.X, klocekStartowy.Y+1, Brushes.Olive),
                                                            new Klocek(klocekStartowy.X+1, klocekStartowy.Y+1, Brushes.Olive)});
                    break;
                case KszałtFigury.TetriminoZ:
                    kształt = new List<Klocek>(new Klocek[] {
                                                            new Klocek(klocekStartowy.X, klocekStartowy.Y, Brushes.Magenta),
                                                            new Klocek(klocekStartowy.X+1, klocekStartowy.Y, Brushes.Magenta),
                                                            new Klocek(klocekStartowy.X+1, klocekStartowy.Y+1, Brushes.Magenta),
                                                            new Klocek(klocekStartowy.X+2, klocekStartowy.Y+1, Brushes.Magenta)});
                    break;
            }
            this.ListaKlocków = kształt;
        }

        public Figura PrzesuńWDół()
        {
            foreach (Klocek klocek in this.ListaKlocków)
            {
                klocek.Y++;
            }
            return this;
        }

        public Figura PrzesuńWLewo()
        {
            foreach (Klocek klocek in this.ListaKlocków)
            {
                klocek.X--;
            }
            return this;
        }

        public Figura PrzesuńWPrawo()
        {
            foreach (Klocek klocek in this.ListaKlocków)
            {
                klocek.X++;
            }
            return this;
        }

        public Figura Obróc()
        {
            int tempMinX = this.MinX;
            int tempMinY = this.MinY;
            int tempMaxX = this.MaxX;
            int tempMaxY = this.MaxY;
            if (((tempMaxX - tempMinX) == 1) && ((tempMaxY - tempMinY) == 2))
            {
                ZamieńKlocki(new Klocek(tempMinX, tempMinY), new Klocek(tempMinX + 2, tempMinY + 1));
                ZamieńKlocki(new Klocek(tempMinX + 1, tempMinY), new Klocek(tempMinX + 2, tempMinY + 2));
                ZamieńKlocki(new Klocek(tempMinX, tempMinY + 1), new Klocek(tempMinX, tempMinY));
                ZamieńKlocki(new Klocek(tempMinX, tempMinY + 2), new Klocek(tempMinX, tempMinY + 1));
                ZamieńKlocki(new Klocek(tempMinX + 1, tempMinY + 2), new Klocek(tempMinX, tempMinY + 2));
                ZamieńKlocki(new Klocek(tempMinX + 1, tempMinY + 1), new Klocek(tempMinX + 1, tempMinY + 2));
                ZamieńKlocki(new Klocek(tempMinX, tempMinY), new Klocek(tempMinX + 1, tempMinY + 1));
            }
            else if (((tempMaxX - tempMinX) == 2) && ((tempMaxY - tempMinY) == 1))
            {
                ZamieńKlocki(new Klocek(tempMinX, tempMinY), new Klocek(tempMinX + 1, tempMinY - 1));
                ZamieńKlocki(new Klocek(tempMinX, tempMinY + 1), new Klocek(tempMinX, tempMinY - 1));
                ZamieńKlocki(new Klocek(tempMinX + 1, tempMinY + 1), new Klocek(tempMinX, tempMinY));
                ZamieńKlocki(new Klocek(tempMinX + 2, tempMinY + 1), new Klocek(tempMinX, tempMinY + 1));
                ZamieńKlocki(new Klocek(tempMinX + 2, tempMinY), new Klocek(tempMinX + 1, tempMinY + 1));
            }
            else if (((tempMaxX - tempMinX) == 0) && ((tempMaxY - tempMinY) == 3))
            {
                ZamieńKlocki(new Klocek(tempMinX, tempMinY), new Klocek(tempMinX + 2, tempMinY + 2));
                ZamieńKlocki(new Klocek(tempMinX, tempMinY + 1), new Klocek(tempMinX + 1, tempMinY + 2));
                ZamieńKlocki(new Klocek(tempMinX, tempMinY + 3), new Klocek(tempMinX - 1, tempMinY + 2));
            }
            else if (((tempMaxX - tempMinX) == 3) && ((tempMaxY - tempMinY) == 0))
            {
                ZamieńKlocki(new Klocek(tempMinX, tempMinY), new Klocek(tempMinX + 1, tempMinY - 2));
                ZamieńKlocki(new Klocek(tempMinX + 1, tempMinY), new Klocek(tempMinX + 1, tempMinY - 1));
                ZamieńKlocki(new Klocek(tempMinX + 2, tempMinY), new Klocek(tempMinX + 1, tempMinY));
                ZamieńKlocki(new Klocek(tempMinX + 3, tempMinY), new Klocek(tempMinX + 1, tempMinY + 1));
            }
            return this;
        }

        public int MinX
        {
            get
            {
                int minX = int.MaxValue;
                foreach (Klocek klocek in this.ListaKlocków)
                {
                    if (klocek.X < minX)
                        minX = klocek.X;
                }
                return minX;
            }
        }

        public int MaxX
        {
            get
            {
                int maxX = int.MinValue;
                foreach (Klocek klocek in this.ListaKlocków)
                {
                    if (klocek.X > maxX)
                        maxX = klocek.X;
                }
                return maxX;
            }
        }


        public int MinY
        {
            get
            {
                int minY = int.MaxValue;
                foreach (Klocek klocek in this.ListaKlocków)
                {
                    if (klocek.Y < minY)
                        minY = klocek.Y;
                }
                return minY;
            }
        }

        public int MaxY
        {
            get
            {
                int maxY = int.MinValue;
                foreach (Klocek klocek in this.ListaKlocków)
                {
                    if (klocek.Y > maxY)
                        maxY = klocek.Y;
                }
                return maxY;
            }
        }


        public Figura RóżnicaPomiędzyFigurami(Figura porównywanaFigura)
        {
            Figura figura = new Figura();
            foreach (Klocek klocek in porównywanaFigura.ListaKlocków)
            {
                if (!this.ListaKlocków.Contains(klocek))
                    figura.ListaKlocków.Add(klocek);
            }
            return figura;
        }

        public object Clone()
        {
            Figura figura = new Figura();
            foreach (Klocek klocek in this.ListaKlocków)
            {
                figura.ListaKlocków.Add((Klocek)klocek.Clone());
            }
            return figura;
        }

        private void ZamieńKlocki(Klocek klocekŹrodłowy, Klocek klocekDocelowy)
        {
            int indexKlockaWLiscie = this.ListaKlocków.IndexOf(klocekŹrodłowy);
            if (indexKlockaWLiscie >= 0)
            {
                this.ListaKlocków[indexKlockaWLiscie].X = klocekDocelowy.X;
                this.ListaKlocków[indexKlockaWLiscie].Y = klocekDocelowy.Y;
            }

        }
    }
}

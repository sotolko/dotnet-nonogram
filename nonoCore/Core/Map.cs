using System;

namespace nonoCore
{
    [Serializable]
    public class Map
    {
        public readonly Tile[,] _tiles;
        public int RowCount { get; }
        public int ColumnCount { get; }

        public Map(int rowCount, int columnCount,int seed)
        {
            this.RowCount = rowCount;
            this.ColumnCount = columnCount;
            _tiles = new Tile[rowCount, columnCount];
            createMap(rowCount, columnCount,seed);
        }

        public Tile GetTile(int row, int column)
        {
            return _tiles[row, column];
        }

        public Tile this[int row, int column]
        {
            get { return _tiles[row, column]; }
        }

        public void createMap(int rowCount, int columnCount,int seed)
        {
            Random random;

            if (seed == 0)
            {
                random = new Random();
            }
            else
            {
                random = generateSeed(seed);
            }

            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    if (random.Next(0, 100) >= 50)
                    {
                        _tiles[i, j] = new Tile(1);
                    }
                    else
                    {
                        _tiles[i, j] = new Tile(0);
                    }
                }
            }
        }

        public int[,] getRowCoord(int rowCount,int columnCount)
        {
            int[,] coordY = new int[rowCount+1, columnCount+1];
            int count = 0;

            for(var x = 0; x < rowCount; x++)
            {
                for(var y = 0; y < columnCount; y++)
                {
                    if(_tiles[x,y].Value == 0 && coordY[x,count] > 0)
                    {
                        count++;
                    }
                    else if(_tiles[x,y].Value == 1)
                    {
                        coordY[x, count]++;
                    }
                }
                count = 0;
            }

            return coordY;
        }

        public int[,] getColCoord(int rowCount, int columnCount)
        {
            int[,] coordX = new int[rowCount+1, columnCount+1];
            int count = 0;

            for (var x = 0; x < rowCount; x++)
            {
                for (var y = 0; y < columnCount; y++)
                {
                    if (_tiles[y, x].Value == 0 && coordX[x, count] > 0)
                    {
                        count++;
                    }
                    else if (_tiles[y, x].Value == 1)
                    {
                        coordX[x, count]++;
                    }
                }
                count = 0;
            }

            return coordX;
        }

        public Random generateSeed(int seed)
        {
            Random random = new Random(seed);
            return random;
        }
    }

    [Serializable]
    public class Guess
    {
        private readonly Tile[,] _guess;
        private readonly Map mapa;

        public int RowCount { get; }
        public int ColumnCount { get; }


        public Guess(int rowCount, int columnCount, Map actualMap)
        {
            this.mapa = actualMap;
            this.RowCount = rowCount;
            this.ColumnCount = columnCount;


            _guess = new Tile[rowCount, columnCount];
            createMap(rowCount, columnCount);
        }

        public Tile GetTile(int row, int column)
        {
            return _guess[row, column];
        }

        public Tile this[int row, int column]
        {
            get { return _guess[row, column]; }
        }

        public void createMap(int rowCount, int columnCount)
        {
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    _guess[i, j] = new Tile(0);
                }
            }
        }

        public void playerGuess(int row, int column)
        {
            if (_guess[row, column] != null && _guess[row, column].Value == 0)
            {
                _guess[row, column] = null;
                _guess[row, column] = new Tile(1);
            }
            else if (_guess[row, column] != null && _guess[row, column].Value == 1)
            {
                _guess[row, column] = null;
                _guess[row, column] = new Tile(0);
            }
        }

        public bool isSolved()
        {
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    if (_guess[i, j].Value == mapa._tiles[i, j].Value)
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
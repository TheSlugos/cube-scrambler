/*
       Face definition in memory looks like this (i think)
       format (row, col) (y, x)
       (0,0)   (0,1)   (0,2)
       (1,0)   (1,1)   (1,2)
       (2,0)   (2,1)   (2,2)
*/

using System;
using System.Text;

namespace cube_scrambler
{
  public class Face
  {
    private const int NO_OF_TILES = 3;

    private string[,] _tiles = new string[NO_OF_TILES, NO_OF_TILES];

    public string[,] Tiles
    {
      get
      {
        return _tiles;
      }
    }

    private string _Colour;

    public Face(string colour = "W")
    {
      _Colour = colour;

      ResetFace();
    }

    public string DrawFace()
    {
      string h_line = "+-----+-----+-----+";
      string mt_line = "|     |     |     |";
      string line = "|  {0}  |  {1}  |  {2}  |";
      StringBuilder sb = new StringBuilder();

      sb.Append(h_line);
      sb.AppendLine();

      for (int row = 0; row < NO_OF_TILES; row++)
      {
        sb.Append(mt_line);
        sb.AppendLine();
        sb.AppendFormat(line, _tiles[row, 0], _tiles[row, 1], _tiles[row, 2]);
        sb.AppendLine();
        sb.Append(mt_line);
        sb.AppendLine();
        sb.Append(h_line);
        sb.AppendLine();
      }

      return sb.ToString();
    }

    public void ResetFace()
    {
      for (int col = 0; col < NO_OF_TILES; col++)
      {
        for (int row = 0; row < NO_OF_TILES; row++)
        {
          _tiles[row, col] = _Colour;
        }
      }
    }

    // cw rotation of 90deg: x' = 2 - y, y' = x
    public void RotateFaceCW()
    {
      string[,] newFace = new string[NO_OF_TILES, NO_OF_TILES];

      for (int col = 0; col < NO_OF_TILES; col++)
      {
        for (int row = 0; row < NO_OF_TILES; row++)
        {
          newFace[col, 2 - row] = _tiles[row, col];
        }
      }

      _tiles = newFace;
    }

    // ccw rotation of 90deg: x' = y, y' = 2 - x
    public void RotateFaceCCW()
    {
      string[,] newFace = new string[NO_OF_TILES, NO_OF_TILES];

      for (int col = 0; col < NO_OF_TILES; col++)
      {
        for (int row = 0; row < NO_OF_TILES; row++)
        {
          newFace[2 - col, row] = _tiles[row, col];
        }
      }

      _tiles = newFace;
    }
  }
}

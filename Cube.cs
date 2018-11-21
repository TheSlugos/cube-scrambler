using System;
using System.Text;

namespace cube_scrambler
{
  public class Cube
  {
    private Face[] _Faces;

    public Cube()
    {
      _Faces = new Face[CubeHelper.TOTAL_FACES];

      // set colour of each face
      for (int i = CubeHelper.LEFT; i < CubeHelper.TOTAL_FACES; i++)
      {
        _Faces[i] = new Face(CubeHelper.FACE_COLOURS[i]);
      }
    }

    public void DrawCube()
    {
      // up, left, front, right, back, down
      Console.WriteLine(CubeHelper.FACE_NAMES[CubeHelper.UP]);
      Console.WriteLine(_Faces[CubeHelper.UP].DrawFace());
      Console.WriteLine(CubeHelper.FACE_NAMES[CubeHelper.LEFT]);
      Console.WriteLine(_Faces[CubeHelper.LEFT].DrawFace());
      Console.WriteLine(CubeHelper.FACE_NAMES[CubeHelper.FRONT]);
      Console.WriteLine(_Faces[CubeHelper.FRONT].DrawFace());
      Console.WriteLine(CubeHelper.FACE_NAMES[CubeHelper.RIGHT]);
      Console.WriteLine(_Faces[CubeHelper.RIGHT].DrawFace());
      Console.WriteLine(CubeHelper.FACE_NAMES[CubeHelper.BACK]);
      Console.WriteLine(_Faces[CubeHelper.BACK].DrawFace());
      Console.WriteLine(CubeHelper.FACE_NAMES[CubeHelper.DOWN]);
      Console.WriteLine(_Faces[CubeHelper.DOWN].DrawFace());
    }

    private void RotateU()
    {
      // Apply rotation to face tiles
      _Faces[CubeHelper.UP].RotateFaceCW();

      // left face
      // store left face top row in temp
      string[] temp = new string[CubeHelper.TOTAL_TILES];
      temp[CubeHelper.COLLFT] = _Faces[CubeHelper.LEFT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLLFT];
      temp[CubeHelper.COLMID] = _Faces[CubeHelper.LEFT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLMID];
      temp[CubeHelper.COLRGT] = _Faces[CubeHelper.LEFT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLRGT];

      // moving top row
      // LEFT face now contains FRONT face tiles
      _Faces[CubeHelper.LEFT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLLFT] = _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLLFT];
      _Faces[CubeHelper.LEFT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLMID] = _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLMID];
      _Faces[CubeHelper.LEFT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLRGT] = _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLRGT];

      // FRONT face now contains RIGHT face tiles
      _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLLFT] = _Faces[CubeHelper.RIGHT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLLFT];
      _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLMID] = _Faces[CubeHelper.RIGHT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLMID];
      _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLRGT] = _Faces[CubeHelper.RIGHT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLRGT];

      // RIGHT face now contains BACK face tiles
      _Faces[CubeHelper.RIGHT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLLFT] = _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWTOP, CubeHelper.COLLFT];
      _Faces[CubeHelper.RIGHT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLMID] = _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWTOP, CubeHelper.COLMID];
      _Faces[CubeHelper.RIGHT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLRGT] = _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWTOP, CubeHelper.COLRGT];

      // BACK face now contains LEFT face tiles, stored in temp
      _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWTOP, CubeHelper.COLLFT] = temp[CubeHelper.COLLFT];
      _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWTOP, CubeHelper.COLMID] = temp[CubeHelper.COLMID];
      _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWTOP, CubeHelper.COLRGT] = temp[CubeHelper.COLRGT];
    }

    private void RotateUW()
    {
      // Apply rotation to face tiles
      _Faces[CubeHelper.UP].RotateFaceCCW();

      // moving top row

      // store LEFT face in temp
      string[] temp = new string[CubeHelper.TOTAL_TILES];
      temp[CubeHelper.COLLFT] = _Faces[CubeHelper.LEFT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLLFT];
      temp[CubeHelper.COLMID] = _Faces[CubeHelper.LEFT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLMID];
      temp[CubeHelper.COLRGT] = _Faces[CubeHelper.LEFT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLRGT];

      // LEFT face contains tiles from BACK face
      _Faces[CubeHelper.LEFT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLLFT] = _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWTOP, CubeHelper.COLLFT];
      _Faces[CubeHelper.LEFT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLMID] = _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWTOP, CubeHelper.COLMID];
      _Faces[CubeHelper.LEFT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLRGT] = _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWTOP, CubeHelper.COLRGT];

      // BACK face contains tiles from RIGHT face
      _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWTOP, CubeHelper.COLLFT] = _Faces[CubeHelper.RIGHT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLLFT];
      _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWTOP, CubeHelper.COLMID] = _Faces[CubeHelper.RIGHT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLMID];
      _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWTOP, CubeHelper.COLRGT] = _Faces[CubeHelper.RIGHT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLRGT];

      // RIGHT face contains tiles from FRONT face
      _Faces[CubeHelper.RIGHT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLLFT] = _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLLFT];
      _Faces[CubeHelper.RIGHT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLMID] = _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLMID];
      _Faces[CubeHelper.RIGHT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLRGT] = _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLRGT];

      // FRONT face contains tiles from LEFT face, stored in temp
      _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLLFT] = temp[CubeHelper.COLLFT];
      _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLMID] = temp[CubeHelper.COLMID];
      _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLRGT] = temp[CubeHelper.COLRGT];

    }

    private void RotateD()
    {
      // Apply rotation to face tiles
      _Faces[CubeHelper.DOWN].RotateFaceCW();

      // moving bottom row

      // store LEFT face in temp
      string[] temp = new string[CubeHelper.TOTAL_TILES];
      temp[CubeHelper.COLLFT] = _Faces[CubeHelper.LEFT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLLFT];
      temp[CubeHelper.COLMID] = _Faces[CubeHelper.LEFT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLMID];
      temp[CubeHelper.COLRGT] = _Faces[CubeHelper.LEFT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLRGT];

      // LEFT face contains tiles from BACK face
      _Faces[CubeHelper.LEFT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLLFT] = _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWBOT, CubeHelper.COLLFT];
      _Faces[CubeHelper.LEFT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLMID] = _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWBOT, CubeHelper.COLMID];
      _Faces[CubeHelper.LEFT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLRGT] = _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWBOT, CubeHelper.COLRGT];

      // BACK face contains tiles from RIGHT face
      _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWBOT, CubeHelper.COLLFT] = _Faces[CubeHelper.RIGHT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLLFT];
      _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWBOT, CubeHelper.COLMID] = _Faces[CubeHelper.RIGHT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLMID];
      _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWBOT, CubeHelper.COLRGT] = _Faces[CubeHelper.RIGHT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLRGT];

      // RIGHT face contains tiles from FRONT face
      _Faces[CubeHelper.RIGHT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLLFT] = _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLLFT];
      _Faces[CubeHelper.RIGHT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLMID] = _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLMID];
      _Faces[CubeHelper.RIGHT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLRGT] = _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLRGT];

      // FRONT face contains tiles from LEFT face, stored in temp
      _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLLFT] = temp[CubeHelper.COLLFT];
      _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLMID] = temp[CubeHelper.COLMID];
      _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLRGT] = temp[CubeHelper.COLRGT];

    }

    private void RotateDW()
    {

      // rotate face tiles
      _Faces[CubeHelper.DOWN].RotateFaceCCW();

      // left face
      // store left face in temp
      string[] temp = new string[CubeHelper.TOTAL_TILES];
      temp[CubeHelper.COLLFT] = _Faces[CubeHelper.LEFT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLLFT];
      temp[CubeHelper.COLMID] = _Faces[CubeHelper.LEFT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLMID];
      temp[CubeHelper.COLRGT] = _Faces[CubeHelper.LEFT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLRGT];

      // moving bottom row
      // LEFT face now contains FRONT face tiles
      _Faces[CubeHelper.LEFT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLLFT] = _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLLFT];
      _Faces[CubeHelper.LEFT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLMID] = _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLMID];
      _Faces[CubeHelper.LEFT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLRGT] = _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLRGT];

      // FRONT face now contains RIGHT face tiles
      _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLLFT] = _Faces[CubeHelper.RIGHT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLLFT];
      _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLMID] = _Faces[CubeHelper.RIGHT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLMID];
      _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLRGT] = _Faces[CubeHelper.RIGHT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLRGT];

      // RIGHT face now contains BACK face tiles
      _Faces[CubeHelper.RIGHT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLLFT] = _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWBOT, CubeHelper.COLLFT];
      _Faces[CubeHelper.RIGHT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLMID] = _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWBOT, CubeHelper.COLMID];
      _Faces[CubeHelper.RIGHT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLRGT] = _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWBOT, CubeHelper.COLRGT];

      // BACK face now contains LEFT face tiles, stored in temp
      _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWBOT, CubeHelper.COLLFT] = temp[CubeHelper.COLLFT];
      _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWBOT, CubeHelper.COLMID] = temp[CubeHelper.COLMID];
      _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWBOT, CubeHelper.COLRGT] = temp[CubeHelper.COLRGT];
    }

    private void RotateL()
    {
      // Apply rotation to face tiles
      _Faces[CubeHelper.LEFT].RotateFaceCW();

      // moving left col, except for BACK which is moving right col

      // store front face left column in temp
      string[] temp = new string[CubeHelper.TOTAL_TILES];
      temp[CubeHelper.ROWTOP] = _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLLFT];
      temp[CubeHelper.ROWMID] = _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWMID, CubeHelper.COLLFT];
      temp[CubeHelper.ROWBOT] = _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLLFT];

      // FRONT face left column contains tiles from UP face left column
      _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLLFT] = _Faces[CubeHelper.UP].Tiles[CubeHelper.ROWTOP, CubeHelper.COLLFT];
      _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWMID, CubeHelper.COLLFT] = _Faces[CubeHelper.UP].Tiles[CubeHelper.ROWMID, CubeHelper.COLLFT];
      _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLLFT] = _Faces[CubeHelper.UP].Tiles[CubeHelper.ROWBOT, CubeHelper.COLLFT];

      // UP face contains tiles from BACK face, but right col and the rows are inverted
      _Faces[CubeHelper.UP].Tiles[CubeHelper.ROWTOP, CubeHelper.COLLFT] = _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWBOT, CubeHelper.COLRGT];
      _Faces[CubeHelper.UP].Tiles[CubeHelper.ROWMID, CubeHelper.COLLFT] = _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWMID, CubeHelper.COLRGT];
      _Faces[CubeHelper.UP].Tiles[CubeHelper.ROWBOT, CubeHelper.COLLFT] = _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWTOP, CubeHelper.COLRGT];

      // BACK face right column contains tiles from DOWN face left column, rows inverted
      _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWBOT, CubeHelper.COLRGT] = _Faces[CubeHelper.DOWN].Tiles[CubeHelper.ROWTOP, CubeHelper.COLLFT];
      _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWMID, CubeHelper.COLRGT] = _Faces[CubeHelper.DOWN].Tiles[CubeHelper.ROWMID, CubeHelper.COLLFT];
      _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWTOP, CubeHelper.COLRGT] = _Faces[CubeHelper.DOWN].Tiles[CubeHelper.ROWBOT, CubeHelper.COLLFT];

      // DOWN face left column contains tiles from FRONT face left column, stored in temp
      _Faces[CubeHelper.DOWN].Tiles[CubeHelper.ROWTOP, CubeHelper.COLLFT] = temp[CubeHelper.ROWTOP];
      _Faces[CubeHelper.DOWN].Tiles[CubeHelper.ROWMID, CubeHelper.COLLFT] = temp[CubeHelper.ROWMID];
      _Faces[CubeHelper.DOWN].Tiles[CubeHelper.ROWBOT, CubeHelper.COLLFT] = temp[CubeHelper.ROWBOT];
    }

    private void RotateLW()
    {
      // Apply rotation to face tiles
      _Faces[CubeHelper.LEFT].RotateFaceCCW();

      // moving left col, except for BACK which is moving right col

      // store front face left column in temp
      string[] temp = new string[CubeHelper.TOTAL_TILES];
      temp[CubeHelper.ROWTOP] = _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLLFT];
      temp[CubeHelper.ROWMID] = _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWMID, CubeHelper.COLLFT];
      temp[CubeHelper.ROWBOT] = _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLLFT];

      // FRONT face left column contains tiles from DOWN face left column
      _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWTOP, CubeHelper.COLLFT] = _Faces[CubeHelper.DOWN].Tiles[CubeHelper.ROWTOP, CubeHelper.COLLFT];
      _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWMID, CubeHelper.COLLFT] = _Faces[CubeHelper.DOWN].Tiles[CubeHelper.ROWMID, CubeHelper.COLLFT];
      _Faces[CubeHelper.FRONT].Tiles[CubeHelper.ROWBOT, CubeHelper.COLLFT] = _Faces[CubeHelper.DOWN].Tiles[CubeHelper.ROWBOT, CubeHelper.COLLFT];

      // DOWN face contains tiles from BACK face, but right col and the rows are inverted
      _Faces[CubeHelper.DOWN].Tiles[CubeHelper.ROWTOP, CubeHelper.COLLFT] = _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWBOT, CubeHelper.COLRGT];
      _Faces[CubeHelper.DOWN].Tiles[CubeHelper.ROWMID, CubeHelper.COLLFT] = _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWMID, CubeHelper.COLRGT];
      _Faces[CubeHelper.DOWN].Tiles[CubeHelper.ROWBOT, CubeHelper.COLLFT] = _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWTOP, CubeHelper.COLRGT];

      // BACK face right column contains tiles from UP face left column, rows inverted
      _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWBOT, CubeHelper.COLRGT] = _Faces[CubeHelper.UP].Tiles[CubeHelper.ROWTOP, CubeHelper.COLLFT];
      _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWMID, CubeHelper.COLRGT] = _Faces[CubeHelper.UP].Tiles[CubeHelper.ROWMID, CubeHelper.COLLFT];
      _Faces[CubeHelper.BACK].Tiles[CubeHelper.ROWTOP, CubeHelper.COLRGT] = _Faces[CubeHelper.UP].Tiles[CubeHelper.ROWBOT, CubeHelper.COLLFT];

      // UP face left column contains tiles from FRONT face left column, stored in temp
      _Faces[CubeHelper.UP].Tiles[CubeHelper.ROWTOP, CubeHelper.COLLFT] = temp[CubeHelper.ROWTOP];
      _Faces[CubeHelper.UP].Tiles[CubeHelper.ROWMID, CubeHelper.COLLFT] = temp[CubeHelper.ROWMID];
      _Faces[CubeHelper.UP].Tiles[CubeHelper.ROWBOT, CubeHelper.COLLFT] = temp[CubeHelper.ROWBOT];
    }

    private void RotateR()
    {
      // Apply rotation to face tiles
      _Faces[CubeHelper.RIGHT].RotateFaceCW();
    }

    private void RotateRW()
    {
      // Apply rotation to face tiles
      _Faces[CubeHelper.RIGHT].RotateFaceCCW();
    }

    private void RotateF()
    {
      // Apply rotation to face tiles
      _Faces[CubeHelper.FRONT].RotateFaceCW();
    }

    private void RotateFW()
    {
      // Apply rotation to face tiles
      _Faces[CubeHelper.FRONT].RotateFaceCCW();
    }

    private void RotateB()
    {
      // Apply rotation to face tiles
      _Faces[CubeHelper.BACK].RotateFaceCW();
    }

    private void RotateBW()
    {
      // Apply rotation to face tiles
      _Faces[CubeHelper.BACK].RotateFaceCCW();
    }

    public void ResetCube()
    {
      for (int f = CubeHelper.LEFT; f < CubeHelper.TOTAL_FACES; f++)
      {
        _Faces[f].ResetFace();
      }
    }

    public void PerformMoves(string commandString)
    {
      string[] commands = commandString.Split(' ');

      foreach (string command in commands)
      {
        switch (command)
        {
          case "U":
            RotateU();
            break;

          case "U\'":
            RotateUW();
            break;

          case "U2":
            RotateU();
            RotateU();
            break;

          case "D":
            RotateD();
            break;

          case "D\'":
            RotateDW();
            break;

          case "D2":
            RotateD();
            RotateD();
            break;

          case "L":
            RotateL();
            break;

          case "L\'":
            RotateLW();
            break;

          case "L2":
            RotateL();
            RotateL();
            break;

          case "R":
            RotateR();
            break;

          case "R\'":
            RotateRW();
            break;

          case "R2":
            RotateR();
            RotateR();
            break;

          case "F":
            RotateF();
            break;

          case "F\'":
            RotateFW();
            break;

          case "F2":
            RotateF();
            RotateF();
            break;

          case "B":
            RotateB();
            break;

          case "B\'":
            RotateBW();
            break;

          case "B2":
            RotateB();
            RotateB();
            break;
        }
      }
    }
  }
}

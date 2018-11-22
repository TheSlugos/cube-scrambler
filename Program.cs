using System;

namespace cube_scrambler
{
  class Program
  {
    static void Main(string[] args)
    {
      /*  var moves = new[] {
          new[] { "U", "D" },
          new[] { "F", "B" },
          new[] { "L", "R" }};

      Random rand = new Random();

      int thisType = -1;

      for ( int i = 0; i < 20; i++ )
      {

      }

      Console.WriteLine("Length of moves: {0}", moves.Length);
      Console.WriteLine("Length of moves[1]: {0}", moves[1].Length);
      Console.WriteLine("Type of moves: {0}", moves.GetType());
      Console.WriteLine("Type of moves[1]: {0}", moves[1].GetType()); */

      Scrambler myScrambler = new Scrambler();
      string myMoves = myScrambler.Scramble();
      myMoves = @"D' B' R' D B U' B2 L' U R2 B' U R2 F' R D B U F' L L' F U' B' D' R' F R2 U' B R2 U' L B2 U B' D' R B D";
      Console.WriteLine(myMoves);

      Console.WriteLine();

      // make a cube and draw it
      Cube theCube = new Cube();
      theCube.PerformMoves(myMoves);
      theCube.DrawCube();
    }
  }
}

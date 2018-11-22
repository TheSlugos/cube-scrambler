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
      string revMoves = myScrambler.ReverseScramble(myMoves);

      Console.WriteLine(myMoves);
      Console.WriteLine(revMoves);

      Console.WriteLine();

      // make a cube and draw it
      Cube theCube = new Cube();
      theCube.PerformMoves(myMoves);
      theCube.DrawCube();

      Console.WriteLine();
      theCube.PerformMoves(revMoves);
      theCube.DrawCube();
    }
  }
}

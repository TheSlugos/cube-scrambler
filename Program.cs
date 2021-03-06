﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

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
      var MoveSet = new { scramble = string.Empty, reverse = string.Empty };
      string jsonstring = myScrambler.Scramble();
      var moveset = JsonConvert.DeserializeAnonymousType(jsonstring, MoveSet);
      
      Console.Clear();

      Console.WriteLine($"moves: {moveset.scramble}\nreverse: {moveset.reverse}");
      Console.WriteLine();

      // make a cube and draw it
      Cube theCube = new Cube();
      theCube.PerformMoves(moveset.scramble);
      // theCube.DrawCube();

      // Console.WriteLine();
      // theCube.PerformMoves(moveset.reverse);
      // theCube.DrawCube();

      // New ICubeDrawer
      Console.WriteLine("Testing cubeDrawer:");
      ICubeDrawer cubeDrawer = new ConsoleCubeDrawer();
      theCube.Draw(cubeDrawer);
      cubeDrawer = new ImageCubeDrawer();
      theCube.Draw(cubeDrawer);

      // Testing json -> can create a Draw class/method that takes this json and displays
      // the cube as per platform
      /*
        ICubeDrawer
          - public void DrawCube(string cubeJson)
            public

        Cube.Draw(ICubeDrawer theDrawer);

        Class ConsoleCubeDrawer : ICubeDrawer
          public void DrawCube(string cubeJson)
          {
            Console.SetCursorPosition(x,y) blah blah
          }
       */
      // var TestClass = new
      // {
      //   left = new[] { new[] { "", "", "" }, new[] { "", "", "" }, new[] { "", "", "" } },
      //   front = new[] { new[] { "", "", "" }, new[] { "", "", "" }, new[] { "", "", "" } },
      //   right = new[] { new[] { "", "", "" }, new[] { "", "", "" }, new[] { "", "", "" } },
      //   back = new[] { new[] { "", "", "" }, new[] { "", "", "" }, new[] { "", "", "" } },
      //   up = new[] { new[] { "", "", "" }, new[] { "", "", "" }, new[] { "", "", "" } },
      //   down = new[] { new[] { "", "", "" }, new[] { "", "", "" }, new[] { "", "", "" } }
      // };

      // var testClass = JsonConvert.DeserializeAnonymousType(theCube.ToJson(), TestClass);

      Console.WriteLine();
      // JObject o = JObject.Parse(theCube.ToJson());
      // JArray a = (JArray)o["left"];
      // Console.WriteLine(a[0][0]);
      // Console.WriteLine(a[0][1]);
      // Console.WriteLine(a[0][2]);
      // JArray row1 = (JArray)a[0];
      // foreach(JValue jv in row1) {
      //   Console.WriteLine(jv.Value.ToString());
      // }
    }
  }
}

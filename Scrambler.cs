using System;
using System.Text;

namespace cube_scrambler
{
  public class Scrambler
  {
    string[][] _moves = new[] {
            new[] { "U", "D" },
            new[] { "F", "B" },
            new[] { "L", "R" }};

    string[] _times = new[] { string.Empty, "\'", "2" };
    Random _rand = new Random();

    int _lastResult = -1;

    public string Scramble(int moves = 20)
    {
      StringBuilder sb = new StringBuilder();

      for (int i = 0; i < moves; i++)
      {
        // get a move set
        int move_set = getNonRepeatRandomElement(_moves, _lastResult);
        string move = getRandomElement(_moves[move_set]);
        string times = getRandomElement(_times);
        _lastResult = move_set;

        sb.Append(move);
        sb.Append(times);
        sb.Append(" ");
      }

      return sb.ToString().Trim();
    }

    private int getNonRepeatRandomElement(string[][] array, int lastResult = -1)
    {
      int result = -1;

      do
      {
        result = _rand.Next(array.Length);
      } while (result == lastResult);

      return result;
    }

    private string getRandomElement(string[] array)
    {
      int element = _rand.Next(array.Length);

      return array[element];
    }
  }
}

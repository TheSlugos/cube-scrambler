using System;
using System.Text;
using Newtonsoft.Json;

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

      string scramble_moves = sb.ToString().Trim();
      string reverse_moves = ReverseScramble(scramble_moves);

      string json = JsonConvert.SerializeObject(new { scramble = scramble_moves, reverse = reverse_moves });

      return json;
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

    private string ReverseScramble(string moves)
    {
      // split the string
      string[] commands = moves.Split(' ');
      string newMoves = string.Empty;

      for (int i = commands.Length - 1; i >= 0; i--)
      {
        string reverseCommand = string.Empty;

        if (commands[i].Contains(@"'"))
        {
          // ccw - make cw
          reverseCommand = commands[i].Substring(0, 1);
        }
        else if (commands[i].Contains("2"))
        {
          // double rotation is same as double prime rotation
          reverseCommand = commands[i];
        }
        else
        {
          // must be cw rotation, make ccw
          reverseCommand = commands[i] + "\'";
        }

        newMoves += reverseCommand + " ";
      }

      return newMoves.Trim();
    }
  }
}

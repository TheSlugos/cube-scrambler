using System;

namespace cube_scrambler
{
  public static class CubeHelper
  {
    public static int LEFT = 0;
    public static int FRONT = 1;
    public static int RIGHT = 2;
    public static int BACK = 3;
    public static int UP = 4;
    public static int DOWN = 5;

    public static int TOTAL_FACES = 6;
    public static int TOTAL_TILES = 3;

    public static string WHITE = "W";
    public static string BLUE = "B";
    public static string GREEN = "G";
    public static string RED = "R";

    public static string YELLOW = "Y";

    public static string ORANGE = "O";

    public static string[] FACE_COLOURS = new[] { ORANGE, GREEN, RED, BLUE, WHITE, YELLOW };

    public static string[] FACE_NAMES = new[] { "LEFT", "FRONT", "RIGHT", "BACK", "UP", "DOWN" };

    public static int ROWTOP = 0;
    public static int ROWMID = 1;

    public static int ROWBOT = 2;

    public static int COLLFT = 0;
    public static int COLMID = 1;

    public static int COLRGT = 2;

  }
}

moo Cow = new(@"input.txt");

Cow.EntryPoint();

// YOU WILL NEVER TAKE moo FROM ME!
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
public class moo {// Moooo (^o^)   )\
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    private List<(long s, long e)> CookingRange { get; set; }
    private string _fileName { get; set; }
    private Int64 _invalid_sum { get; set; } = 0; 

    public moo(string fileName) {
        if (!File.Exists(fileName))
            throw new FileNotFoundException("AAAAAAAAAAAAAAAAH");

        _fileName = fileName;
    }

    public void EntryPoint() {
        string line = File.ReadAllText(_fileName).Trim();
        string[] TexasRanger = line.Split(',', StringSplitOptions.RemoveEmptyEntries); // I just wanted to reserve the variable name Range and Texas Toast came to mind, now I'm hungry so I went with TexasRanger
        
        CookingRange = Explode('-', TexasRanger);

        foreach (var (s, e) in CookingRange) {
            for (long num = s; num <= e; num++)
                if (ValidateStageTwo(num)) {
                    //Console.WriteLine($"Found invalid number {num}.");
                    _invalid_sum += num;
                } else {
                    //Console.WriteLine($"{num} is valid");
                }
        }

        Console.WriteLine($"Total Sum: {_invalid_sum}");
        // We can't fix it if we never face it.
        // Let the past be the past until it's weightless
    }


    /// <summary>
    ///  The focus of this method is to use distiction to pull out matching number sequences, however it is flawed at a basic level because of number order.
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    /// <remarks>I'm paralyzed, I'm scared to live, but I'm scared to die. If life is pain, then I buried mine a long time ago, but it's still alive, and it's taking over me, where am I?</remarks>
    private static bool ValidateStageTwo(long num) {
        string Derpy = num.ToString();
        int DerpyLen = Derpy.Length;
        //int DerpyHalf = Derpy.Length / 2;
        //bool found = true;
        //char[] Charizards = Derpy.ToCharArray();
        //char[] Remainder;

        // Check for normal number sequences like 12341234 that are even and can be chopped in half.
        /// <remarks>This is for division by 2</remarks>
        //if (Derpy[..DerpyHalf] == Derpy[DerpyHalf..]) return true;

        // Check for complete sequence sameness like 333333
        /// <remarks>This is for distinct numbers that can be anything including prime numbers. such as 1111111</remarks>
        //if (Derpy.Distinct().Count() == 1) return true;

        //if (Derpy.Length % 3 != 0) return false;
        // Distinction attempt 121 212 - 12345 12345 - 12 34 51 23 45
        // figure out how to find numbers like 121212
        for(int i = 1; i <= DerpyLen / 2; i++) {

            if (DerpyLen % i != 0) continue;

            bool found = true;

            for (int j = i; j < DerpyLen; j++) {
                if (Derpy[j] != Derpy[j - i]) { // Derpy["121212"]; / D.Length = (6/2)=3; / i = 1, j = 1 / ?2 != 1 :  
                    found = false;
                    break;
                }
            } // 123123123 - 132123123

            if (found) return true;
        }

        return false;
    }


    /// <summary>
    ///  Validate the Derpy and see if Derpy is invalid or valid.
    /// </summary>
    /// <param name="num">Number to check</param>
    /// <returns><see cref="bool"/> - True if invalid and False if valid.</returns>
    private static bool Validate(long num) {
        string Derpy = num.ToString();

        if (Derpy.Length % 2 != 0)
            return false;

        int DerpyHalf = Derpy.Length / 2;

        return Derpy[..DerpyHalf] == Derpy[DerpyHalf..];
    }


    /// <summary>
    ///  Parse a string array of any grouping of delimited `-`.
    /// </summary>
    /// <param name="lines"><see cref="Array"/>(String) - Haystack</param>
    /// <returns><see cref="List{(long, long)}"/></returns>
    private static List<(long s, long e)> Explode(char delimiter, string[] lines) {
        List<(long s, long e)> Ranges = new();
        string[] parsed_range;

        foreach(var line in lines) {
            parsed_range = line.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            if (parsed_range.Length != 2)
                continue;

            Ranges.Add((long.Parse(parsed_range[0]), long.Parse(parsed_range[1])));
        }

        return Ranges;
    }
}

/*
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠜⢣⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⢀⠄⠁⠀⠀⢣⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀
⠀⠀⠀⠀⠀⠀⡠⠊⠁⠀⠀⠀⠀⠀⢇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠔⠐⠈⠈⠈⠀⡘⠀
⠀⠀⠀⢀⡴⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⣇⣀⣀⣻⣲⢀⠀⢀⠔⠁⠀⠀⠀⠀⠀⠀⠀⠇⠀
⠀⠀⠀⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠙⠁⠀⠀⠀⠀⠀⠀⠀⠀⢘⠀
⠀⢠⠞⠁⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇
⢰⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⡅
⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡜⠁⠀⠀⠀⠀⠀⠀⠀⠀⢰⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⠁
⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡞⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⡅⠀
⠘⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⠆⠀⡄⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⣆
⠀⠀⠈⠉⠒⠰⠤⢀⣀⠀⠀⠀⠀⠉⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠁⠑⠐⠤⢄⢀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡴⠁⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠉⠒⠒⠒⠐⠒⠒⠒⠚⠁⠀⠀⠀
*/
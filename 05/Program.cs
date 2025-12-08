// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

string fileName = @"input1.txt";
string[]? fresh_Selpie = null;

if (File.Exists(fileName))
    fresh_Selpie = File.ReadAllLines(fileName);//.ToList();

if (fresh_Selpie == null) throw new Exception("You gave me an empty list, meow.");

moo moo = new(fresh_Selpie);

Console.WriteLine($"Hello stranger, would you like a snickerdoodle cookie? I have {moo.GetCookies} of them.");

public class moo {

    private Dictionary<long, short> _FreshIDs;
    private HashSet<long> _downloadingMoreRam; // loool it lasted longer than dic
    private long[] ProductIDs;
    private int Snickerdoodles = 0;

    public moo(string[] Inventree) {
        //Inventree = new() { (1, 2), (3, 4) };
        _FreshIDs = new();
        _downloadingMoreRam = new();

        /*foreach(string line in  Inventree) {
            if(line.Contains("-")) {
                long start_range = Convert.ToInt64(line.Split("-")[0]);
                long end_range = Convert.ToInt64(line.Split('-')[1]);

                _FreshIDs.Add((start_range, end_range));
            } else {
                ProductIDs.Add(Convert.ToInt64(line));
            }
        }*/

        foreach (string line in Inventree) {
            if (line.Contains('-')) {
                long start = Convert.ToInt64(line.Split('-')[0]);
                long end = Convert.ToInt64(line.Split('-')[1]);

                for (long i = start; i <= end; i++) {
                    if (!_FreshIDs.ContainsKey(i))
                        _FreshIDs.Add(i, 0);
                    //Thread.Sleep(2);
                }
            } else {
                if (string.IsNullOrEmpty(line)) continue;
                ProductIDs?.Append(Convert.ToInt64(line));
            }
        }

        if (ProductIDs?.Length <= 0 || ProductIDs == null) throw new Exception("Product ID long[] was empty. Meow.");

        foreach (var id in ProductIDs) {
            if (_FreshIDs.ContainsKey(id))
                Snickerdoodles++;

            /*foreach(var (start, end) in Inventree) {
                Console.WriteLine($"Tuple<{start}, {end}>");
            }*/
        }

        //private bool isGood(long id) => _FreshIDs.se // where id > start && id < end
    }

    public long GetCookies => Snickerdoodles;
}
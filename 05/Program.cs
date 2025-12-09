// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Text;

string fileName = @"test.txt";
string[]? fresh_Selpie = null;

if (File.Exists(fileName))
    fresh_Selpie = File.ReadAllLines(fileName);//.ToList();

if (fresh_Selpie == null) throw new Exception("You gave me an empty list, meow.");

moo moo = new(fresh_Selpie);

Console.WriteLine($"Hello stranger, would you like a snickerdoodle cookie? I have {moo.GetCookies} of them.");

public class moo {

    private Dictionary<long, short> _FreshIDs;
    private HashSet<long> _downloadingMoreRam; // loool it lasted longer than dic
    private long[] ProductIDs = new long[] { };
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

        /* don't ask I just hit random keys in dev console.
            let block1s = 121161608318992;
            let block1e = 123341125834598;
            let block2s = 122946705389751;
            let block2e = 124929708122133;

            if (block1s < block2e) { // Possible new range - Cuts down on false comparisons against lower blocks (1e6 < 30)
 	            if (block1s < block2s) { // Possible low end extension (The bottom grows)
                    if(block1e > block2e) console.log('low end caught full replacement - REMOVE BLOCK 2 ADJUST BLOCK 1 RANGE NOW')
                    else if(block1e < block2e) console.log(`low end caught partial replacement - REMOVE BLOCK 1 ADJUST BLOCK 2 LOW RANGE`)
		            else console.log(`fuck - low end exception flawed logic`)
	            } else if (block1e > block2s) { // Possible block extension because 14 > 12 (High end extension the top grows)
		            if( block1s > block2s ) console.log(`high end - REMOVE BLOCK 2 FULL REPLACEMENT BLOCK 1 COVERS ENTIRE RANGE`) // >= OTHERWISE YOU WILL EAT NUMBERS 10 > 12 == false
		            else if ( block1e < block2e ) console.log(`idk high end eat block 2 END`) // 14 < 18 TRUE - WE KNOW NOTHING 
	            }
            } else { console.warn('0') }
 
         */

        // Get all ranges into a dictionary
        // Figure out how to sort the ranges.
        // idk draw the fucking owl.
        //Dictionary<long, long> keyValuePairs = new();
        //List<(long start, long end, bool dead)> listTuple = new();
        List<Blocks> listTuple = new();

        foreach (string key in Inventree) {
            if (key.Contains('-')) {
                long start = Convert.ToInt64(key.Split('-')[0]);
                long end = Convert.ToInt64(key.Split('-')[1]);

                //keyValuePairs.Add(start, end);
                ///listTuple.Add((start, end, false));
                listTuple.Add(new Blocks(start, end));
            } else {
                if (string.IsNullOrEmpty(key)) continue;
                ///ProductIDs.Append(Convert.ToInt64(key));
                ProductIDs = ProductIDs.Append<long>(Convert.ToInt64(key)).ToArray();
            }
        }

        //listTuple.Sort();
        Console.WriteLine(listTuple.Count());
        //List<(long start, long end)> HammerShuffle = new();
        //Dictionary<int, short> replaced_blocks = new();
        HashSet<int> dead_blocks = new();

        // Used my phone a Stackoverflow card.
        // https://stackoverflow.com/a/14125600
        // TODO: Work on linq expressions especially lambdas.
        listTuple.Sort((a, b) => a.GetMinimum.CompareTo(b.GetMinimum));

        List<Blocks> sortedBlocks = new();
        foreach (var block in listTuple) {
            if(block.IsDead) continue;

            if (sortedBlocks.Count == 0) {
                sortedBlocks.Add(new Blocks(block.GetMinimum, block.GetMaximum));
                continue;
            }

            Blocks lastChristmas = sortedBlocks[^1];

            if (block.GetMinimum <= lastChristmas.GetMaximum + 1)
                lastChristmas.UpdateBlock(lastChristmas.GetMinimum, Math.Max(lastChristmas.GetMaximum, block.GetMaximum));
            else
                sortedBlocks.Add(new Blocks(block.GetMinimum, block.GetMaximum));
        }


        int wgewgerwggeqwgggqgwgerqwqgewqfewdsgvewdrqgewgfvqwegf = 1;
        foreach (var key in sortedBlocks) {
            if (key.IsDead) continue;
            Console.WriteLine($"{wgewgerwggeqwgggqgwgerqwqgewqfewdsgvewdrqgewgfvqwegf++}: {key.GetMinimum}-{key.GetMaximum}");
        }

        foreach (long product in ProductIDs) {
            //if (product == null) continue;
            foreach (var key in sortedBlocks) {
                if (key.IsDead) continue;
                if (product >= key.GetMinimum && product <= key.GetMaximum) {
                    Snickerdoodles++;
                    continue;
                }
            }
        }


        return;


        for (int jk = 0; jk < listTuple.Count - 1; jk++) {
            long block1_start = listTuple[jk].GetMinimum;
            long block1_end = listTuple[jk].GetMaximum;

            for (int lmao = 0; lmao < listTuple.Count - 1; lmao++) {
                long block2_start = listTuple[lmao + 1].GetMinimum;
                long block2_end = listTuple[lmao + 1].GetMaximum;

                if (listTuple[lmao + 1].IsDead || listTuple[jk].IsDead) { continue; }

                if (block1_start <= block2_end) {
                    if (block1_start <= block2_start) {
                        if (block1_end >= block2_end) {
                            //listTuple.RemoveAt(lmao + 1);
                            ///listTuple.Insert(lmao + 1, (block2_start, block2_end, true));
                            listTuple[jk].UpdateBlock(block1_start, block1_end);
                            listTuple[lmao + 1].MarkDead();
                            //Console.WriteLine($"low end caught full replacement - REMOVE BLOCK 2 ADJUST BLOCK 1 RANGE NOW");
                        } else if (block1_end <= block2_end) {
                            //listTuple[jk].end = block2_end;
                            ///listTuple.Insert(jk, (block1_start, block2_end, false));
                            ///listTuple.Insert(lmao + 1, (block2_start, block2_end, true));
                            listTuple[jk].UpdateBlock(block1_start, block2_end);
                            listTuple[lmao + 1].MarkDead();
                            //listTuple.RemoveAt(lmao + 1);
                            //Console.WriteLine($"low end caught partial replacement - REMOVE BLOCK 2 ADJUST BLOCK 1 HIGH RANGE");
                        } else {
                            Console.WriteLine($"fuck - low end exception flawed logic");
                        }
                    } else if (block1_end >= block2_start) { // Possible block extension because 14 > 12 (High end extension the top grows)
                        if (block1_start >= block2_start) {
                            Console.WriteLine($"high end - REMOVE BLOCK 2 FULL REPLACEMENT BLOCK 1 COVERS ENTIRE RANGE"); // >= OTHERWISE YOU WILL EAT NUMBERS 10 > 12 == false
                        } else if (block1_end <= block2_end) {
                            Console.WriteLine($"idk high end eat block 2 END"); // 14 < 18 TRUE - WE KNOW NOTHING
                        } else {
                            Console.WriteLine($"LOOOOOOOOOOOOOOOOOOOOOOOOOOLL I LOVE BAD BITCHES, THAT MY FUCKIN PROBLEM. AND YEAH I LIKE TO FUCK, I GOT A FUCKIN PROBLEM");
                        }
                    }
                }
            }
        }

        Console.WriteLine(listTuple.Count());

        int asdfasdffrerewrggergqwgewgerwggeqwgggqgwgerqwqgewqfewdsgvewdrqgewgfvqwegf = 1;
        foreach(var key in listTuple) {
            if (key.IsDead) continue;
            Console.WriteLine($"{asdfasdffrerewrggergqwgewgerwggeqwgggqgwgerqwqgewqfewdsgvewdrqgewgfvqwegf++}: {key.GetMinimum}-{key.GetMaximum}");
        }

        foreach(long product in ProductIDs) {
            //if (product == null) continue;
            foreach(var key in listTuple) {
                if (key.IsDead) continue;
                if(product > key.GetMinimum && product < key.GetMaximum) {
                    Snickerdoodles++;
                }
            }
        }

        return;

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

public class Blocks {
    private bool _Dead { get; set; } = false;
    private long _Minimum { get; set; } = 0;
    private long _Maximum { get; set; } = 0;


    public Blocks(long Min, long Max) {
        _Minimum = Min;
        _Maximum = Max;
    }

    public void UpdateBlock(long min, long max, bool ded) {
        _Minimum = min;
        _Maximum = max;
        _Dead = ded;
    }

    public void UpdateBlock(long min, long max) {
        _Minimum = min;
        _Maximum = max;
    }

    public void MarkDead() => _Dead = true;
    public void UpdateMinimum(long num) => _Minimum = num;
    public void UpdateMaximum(long num) => _Maximum = num;
    public bool IsDead => _Dead;
    public long GetMinimum => _Minimum;
    public long GetMaximum => _Maximum;
}
// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Text;

string fileName = @"input1.txt";
string[]? fresh_Selpie = null;

if (File.Exists(fileName))
    fresh_Selpie = File.ReadAllLines(fileName);

if (fresh_Selpie == null) throw new Exception("You gave me an empty list, meow.");

moo moo = new(fresh_Selpie);

Console.WriteLine($"Hello stranger, would you like a snickerdoodle cookie? I have {moo.GetCookies} of them.");

public class moo {
    private long[] ProductIDs = new long[] { };
    private int Snickerdoodles = 0; // Sum of good ingrediants.

    public moo(string[] Inventree) {
        List<Blocks> BlockCollection = new();

        foreach (string line in Inventree) {
            if (line.Contains('-')) {
                string[] ranges = line.Split('-');
                long Min = Convert.ToInt64(ranges[0]);
                long Max = Convert.ToInt64(ranges[1]);

                BlockCollection.Add(new Blocks(Min, Max));
            } else {
                if (string.IsNullOrEmpty(line)) continue;
                ProductIDs = ProductIDs.Append<long>(Convert.ToInt64(line)).ToArray();
            }
        }

        Console.WriteLine(BlockCollection.Count());

        // Used my phone a Stackoverflow card.
        // https://stackoverflow.com/a/14125600
        // TODO: Work on linq expressions especially lambdas.
        BlockCollection.Sort((a, b) => a.GetMinimum.CompareTo(b.GetMinimum));

        List<Blocks> OptimizedBlocks = new();
        foreach (var block in BlockCollection) {
            ///if(block.IsDead) continue; I believe it's safe to remove this now since we don't mark as dead anymore we stuff them into a new collection.

            if (OptimizedBlocks.Count == 0) {
                OptimizedBlocks.Add(new Blocks(block.GetMinimum, block.GetMaximum));
                continue;
            }

            Blocks lastChristmas = OptimizedBlocks[^1]; // peek at last value

            if (block.GetMinimum <= lastChristmas.GetMaximum + 1)
                lastChristmas.UpdateBlock(lastChristmas.GetMinimum, Math.Max(lastChristmas.GetMaximum, block.GetMaximum));
            else
                OptimizedBlocks.Add(new Blocks(block.GetMinimum, block.GetMaximum));
        }


        int BlockID = 1;
        foreach (var Block in OptimizedBlocks) {
            ///if (Block.IsDead) continue;
            Console.WriteLine($"{BlockID++}: {Block.GetMinimum}-{Block.GetMaximum}");
        }

        foreach (long product in ProductIDs) {
            foreach (var Block in OptimizedBlocks) {
                ///if (Block.IsDead) continue;
                if (product >= Block.GetMinimum && product <= Block.GetMaximum) {
                    Snickerdoodles++;
                    continue;
                }
            }
        }
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


    public void UpdateBlock(long min, long max) {
        _Minimum = min;
        _Maximum = max;
    }


    public long GetMinimum => _Minimum;
    public long GetMaximum => _Maximum;
}
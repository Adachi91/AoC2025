// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Numerics;
using System.Text;

string fileName = @"input1.txt";
string[]? fresh_Selpie = null;

if (File.Exists(fileName))
    fresh_Selpie = File.ReadAllLines(fileName);

if (fresh_Selpie == null) throw new Exception("You gave me an empty list, meow.");

moo moo = new(fresh_Selpie);

Console.WriteLine($"Hello stranger, would you like a snickerdoodle cookie? I have {moo.GetCookies} of them.");
Console.WriteLine($"Would you also like some Mexican Wedding cookies? They pair quite well with winter. I have {moo.GetMexicanWeddingCookies} left."); // This gave me 359913027576322000 // using bigint: 359913027576322000

public class moo {
    private long[] ProductIDs = new long[] { };
    private int Snickerdoodles = 0; // Sum of good ingrediants.
    private BigInteger MexicanWeddingCookies = 0;

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
            Console.WriteLine($"{BlockID++}: {Block.GetMinimum}-{Block.GetMaximum}");
            MexicanWeddingCookies += Block.GetSum(); // Part 2 addition
        }

        foreach (long product in ProductIDs) {
            foreach (var Block in OptimizedBlocks) {
                if (product >= Block.GetMinimum && product <= Block.GetMaximum) {
                    Snickerdoodles++;
                    continue;
                }
            }
        }
    }


    public long GetCookies => Snickerdoodles;
    public BigInteger GetMexicanWeddingCookies => MexicanWeddingCookies;
}

public class Blocks {
    private long _Minimum { get; set; } = 0;
    private long _Maximum { get; set; } = 0;
    private long _Sum { get; set; } = 0;


    /// <summary>
    ///  Construct a new block with a minimum and maximum value range.
    /// </summary>
    /// <param name="Min">The minimum size of the block range.</param>
    /// <param name="Max">The maximum size of the block range.</param>
    public Blocks(long Min, long Max) {
        _Minimum = Min;
        _Maximum = Max;
    }


    /// <summary>
    ///  Update the block range
    /// </summary>
    /// <param name="min">The minimum size of the block range.</param>
    /// <param name="max">The maximum size of the block range.</param>
    public void UpdateBlock(long min, long max) {
        _Minimum = min;
        _Maximum = max;
    }


    /// <summary>
    ///  Get the total sum of all good foodstuffs.
    /// </summary>
    /// <returns><see cref="long"/> - num of good foodstuffs in this block</returns>
    public long GetSum() { // STILL A JOKE
        if (_Maximum > _Minimum)
            return _Maximum - _Minimum + 1;
        else
            return _Minimum - _Maximum + 1;

        for (int i = 0; i <= _Maximum; i++) // Still funny to think about. Hold my Epyc.
            _Sum++;

        return _Sum;
    }


    public long CheckSum => _Sum; // IT'S A JOKE
    public long GetMinimum => _Minimum;
    public long GetMaximum => _Maximum;
}
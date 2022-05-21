using System;

namespace Cheapest_Flights_Within_K_Stops
{
  class Program
  {
    static void Main(string[] args)
    {
      int[][] flights = new int[5][] { new int[] { 0, 1, 100 }, new int[] { 1, 2, 100 }, new int[] { 2, 0, 100 }, new int[] { 1, 3, 600 }, new int[] { 2, 3, 200 } };
      Solution s = new Solution();
      var result = s.FindCheapestPrice(4, flights, 0, 3, 2);
      Console.WriteLine(result);
    }
  }

  public class Solution
  {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
    {
      var cost = new int[n];
      // Initially all the cost will be infinite
      Array.Fill(cost, int.MaxValue);
      // to reach src from src will sot 0
      cost[src] = 0;
      // Why we are running the loop from 0 to equals k, as we need at least one loop to update the cost when we opted for 0 stop.
      for (int i = 0; i <= k; i++)
      {
        var temp = new int[n];
        Array.Copy(cost, temp, n);
        foreach (var flight in flights)
        {
          int source = flight[0];
          int destination = flight[1];
          int price = flight[2];
          // If source is not yet updated and still infinite, we can ignore processing further
          // because when we add infinite with the new cost to reach dest there is no point
          // Why checking the node is processed or not in Cost array, as we want to update the cost for the nodes which are visited already
          if (cost[source] == int.MaxValue) continue;
          temp[destination] = Math.Min(temp[destination], temp[source] + price);
        }
        cost = temp;
      }

      return cost[dst] == int.MaxValue ? -1 : cost[dst];
    }
  }
}

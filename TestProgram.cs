using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LotteryModule;

namespace ConsoleApp1
{
  public record Participant(int Id, string Name, string Email);

  internal static class TestProgram
  {
    public static void BasicTest()
    {
      // 主程式示範
      using var lottery = new FisherYatesLottery();

      // 示範 1: 基本洗牌
      Console.WriteLine("=== 基本 Fisher-Yates Shuffle 示範 ===");
      int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
      Console.WriteLine($"原始順序: [{string.Join(", ", numbers)}]");

      lottery.Shuffle(numbers);
      Console.WriteLine($"洗牌後:   [{string.Join(", ", numbers)}]");

      // 示範 2: 參與者抽獎
      Console.WriteLine("\n=== 抽獎示範 ===");
      var participants = new List<Participant>
                {
                    new(1, "張三", "zhang@example.com"),
                    new(2, "李四", "li@example.com"),
                    new(3, "王五", "wang@example.com"),
                    new(4, "趙六", "zhao@example.com"),
                    new(5, "孫七", "sun@example.com"),
                    new(6, "周八", "zhou@example.com"),
                    new(7, "吳九", "wu@example.com"),
                    new(8, "鄭十", "zheng@example.com")
                };

      Console.WriteLine("參與者名單:");
      foreach (var p in participants)
      {
        Console.WriteLine($"  {p.Id}. {p.Name} ({p.Email})");
      }

      // 抽出 3 名中獎者
      var winners = lottery.DrawLottery(participants, 3, useSecureRandom: false);

      Console.WriteLine("\n🎉 中獎者公布 🎉");
      for (int i = 0; i < winners.Length; i++)
      {
        Console.WriteLine($"第 {i + 1} 名: {winners[i].Name} ({winners[i].Email})");
      }

      // 示範 3: 安全抽獎（適用於重要場合）
      Console.WriteLine("\n=== 高安全性抽獎示範 ===");
      var secureWinners = lottery.DrawLottery(participants, 2, useSecureRandom: true);

      Console.WriteLine("使用密碼學安全隨機數抽獎結果:");
      for (int i = 0; i < secureWinners.Length; i++)
      {
        Console.WriteLine($"第 {i + 1} 名: {secureWinners[i].Name}");
      }

      // 示範 4: 多次洗牌驗證隨機性
      Console.WriteLine("\n=== 隨機性驗證 ===");
      int[] testArray = { 1, 2, 3, 4, 5 };
      Console.WriteLine("連續 5 次洗牌結果:");

      for (int round = 1; round <= 5; round++)
      {
        int[] temp = (int[])testArray.Clone();
        lottery.Shuffle(temp);
        Console.WriteLine($"第 {round} 次: [{string.Join(", ", temp)}]");
      }
    }

    /// <summary>
    /// 測試洗牌
    /// </summary>
    public static void BasicTest2()
    {
      // 主程式示範
      using var lottery = new FisherYatesLottery();

      
    }
  }
}

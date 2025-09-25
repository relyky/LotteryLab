using ConsoleApp1;

TestProgram.BasicTest();

// 測試洗牌數次後再抽獎
TestProgram.TestShuffleAndDraw();

// 壓力測試：測試洗牌數次後再抽獎
TestProgram.TestShuffleAndDraw_MoreData(2000,17,26);

Console.WriteLine("\n按任意鍵結束...");
Console.ReadKey(); 
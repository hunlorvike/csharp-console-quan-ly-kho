using System;

namespace QuanLyKhoHang.Utils
{
    internal class InputUtils
    {
        public static int GetValidIntegerInput(string message)
        {
            int input;
            bool validInput = false;

            do
            {
                Console.Write(message);
                string inputString = Console.ReadLine();

                if (int.TryParse(inputString, out input))
                {
                    validInput = true;
                }
                else
                {
                    // Thay đổi màu của console thành đỏ
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập một số nguyên.");

                    // Khôi phục màu mặc định của console
                    Console.ResetColor();
                }
            }
            while (!validInput);

            return input;
        }
    }
}

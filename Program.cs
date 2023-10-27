using System;
using System.Data.Common;
using System.Text;
using MySql.Data.MySqlClient;
using QuanLyKhoHang.Model; 
using DbConnection = QuanLyKhoHang.Model.DbConnection;

namespace Main
{
    public class Program
    {
        internal static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Clear();
            Console.WriteLine("Phần Mềm Quản Lý Kho");
            Console.WriteLine("---------------------------");
            MaterialControllerWithView materialControllerWithView = new MaterialControllerWithView();
            materialControllerWithView.Menu();
        }
    }
}

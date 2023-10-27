using System;
using System.Collections.Generic;
using QuanLyKhoHang.Dao.material;
using QuanLyKhoHang.Model;
using QuanLyKhoHang.Utils;

public class MaterialControllerWithView
{
    private IMaterialDao materialDao = new MaterialDaoImpl();

    public void Menu()
    {
        bool continueMenu = true;

        while (continueMenu)
        {
            Console.Clear();
            Console.WriteLine("Danh sách nguyên liệu\n");
            Console.WriteLine("{0,-4} {1,-25} {2,-12} {3}", "ID", "Tên nguyên liệu", "Số Lượng", "Ngày Nhập");
            Console.WriteLine("------------------------------------------------------------");

            List<MaterialModel> materials = materialDao.GetAllMaterials();

            foreach (var material in materials)
            {
                Console.WriteLine($"{material.id,-4} {material.name,-25} {material.quantity,-12} {material.createdAt:dd/MM/yyyy}");
            }

            Console.WriteLine("\n");
            Console.WriteLine("Chương trình quản lý nguyên liệu\n");
            Console.WriteLine("1. Nhập nguyên liệu");
            Console.WriteLine("2. Sửa nguyên liệu");
            Console.WriteLine("3. Xoá nguyên liệu");
            Console.WriteLine("4. Lịch sử Nhập nguyên liệu");
            Console.WriteLine("5. Lịch sử Xuất nguyên liệu");
            Console.WriteLine("6. Thoát");
            int choice = InputUtils.GetValidIntegerInput("Lựa chọn: ");

            switch (choice)
            {
                case 1:
                    Console.Write("Nhập tên của nguyên liệu: ");
                    string nameInput = Console.ReadLine();
                    // Nhập số lượng nguyên liệu
                    int quantityInput = InputUtils.GetValidIntegerInput("Nhập số lượng nguyên liệu: ");

                    // Kiểm tra xem tên nguyên liệu đã tồn tại trong cơ sở dữ liệu chưa
                    MaterialModel existingMaterial = materialDao.GetMaterialByName(nameInput);

                    if (existingMaterial != null)
                    {
                        // Tên nguyên liệu đã tồn tại, cập nhật số lượng
                        int newQuantity = existingMaterial.quantity + quantityInput;
                        existingMaterial.quantity = newQuantity;
                        materialDao.UpdateMaterial(existingMaterial.id, existingMaterial);
                        Console.WriteLine($"Đã cập nhật số lượng nguyên liệu {nameInput} thành {newQuantity}.");
                    }
                    else
                    {
                        // Tên nguyên liệu chưa tồn tại, thêm mới nguyên liệu
                        MaterialModel newMaterial = new MaterialModel(nameInput, quantityInput);
                        materialDao.AddMaterial(newMaterial);
                        Console.WriteLine($"Đã thêm mới nguyên liệu {nameInput} với số lượng {quantityInput}.");
                    }

                    break;

                case 2:
                    // Gọi phương thức để sửa nguyên liệu
                    int idUpdate = InputUtils.GetValidIntegerInput("Nhập ID nguyên liệu cần sửa: ");

                    // Kiểm tra xem id nguyên liệu đã tồn tại trong cơ sở dữ liệu chưa
                    MaterialModel existingMaterialUpdate = materialDao.GetMaterialById(idUpdate);
                    if (existingMaterialUpdate != null)
                    {
                        Console.Write("Nhập tên mới của nguyên liệu: ");
                        string newName = Console.ReadLine();
                        int newQuantityUpdate = InputUtils.GetValidIntegerInput("Nhập số lượng nguyên liệu mới: ");

                        existingMaterialUpdate.name = newName;
                        existingMaterialUpdate.quantity = newQuantityUpdate;

                        materialDao.UpdateMaterial(idUpdate, existingMaterialUpdate);
                        Console.WriteLine($"Đã cập nhật thông tin của nguyên liệu với ID {idUpdate}.");
                    }
                    else
                    {
                        Console.WriteLine("ID không tồn tại.");
                    }
                    break;

                case 3:
                    // Gọi phương thức để xoá nguyên liệu
                    int idDelete = InputUtils.GetValidIntegerInput("Nhập ID nguyên liệu cần xoá: ");
                    // Kiểm tra xem id nguyên liệu đã tồn tại trong cơ sở dữ liệu chưa
                    MaterialModel existingMaterialDelete = materialDao.GetMaterialById(idDelete);
                    if (existingMaterialDelete != null)
                    {
                       materialDao.DeleteMaterial(idDelete);
                    }
                    else
                    {
                        Console.WriteLine("ID không tồn tại.");
                    }
                    break;
                case 4:
                    // Gọi phương thức lịch sử nhập nguyên liệu
                    List<MaterialModel> listMaterials = materialDao.GetAllMaterials();

                    // Lấy đường dẫn thư mục gốc từ thư mục hiện tại
                    string baseDirectory = Directory.GetCurrentDirectory();

                    // Đường dẫn tương đối đến tệp Excel
                    string relativePath = Path.Combine("..", "..", "..", "Data", "DanhSachNguyenLieu.xlsx");

                    // Kết hợp thư mục gốc và đường dẫn tương đối để có đường dẫn hoàn chỉnh
                    string filePath = Path.Combine(baseDirectory, relativePath);

                    ExcelExporter.ExportToExcel(listMaterials, filePath);
                    Console.WriteLine($"Đã xuất dữ liệu ra file Excel: {filePath}");

                    break;

                case 5:
                    // Gọi phương thức nhập dữ liệu từ file excel
                    Console.WriteLine("Chưa xây dựng logic!");
                    break;
                case 6:
                    // Thoát khỏi menu
                    Console.WriteLine("Đã thoát khỏi chương trình");
                    continueMenu = false;
                    break;
                default:
                    Console.WriteLine("Nhập sai lựa chọn");
                    break;
            }
        }
    }
}

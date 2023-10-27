using QuanLyKhoHang.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.Dao.material
{
    public interface IMaterialDao
    {
        void AddMaterial(MaterialModel materialModel);
        void UpdateMaterial(int id, MaterialModel materialModel);
        void DeleteMaterial(int id);
        List<MaterialModel> GetAllMaterials();
        MaterialModel GetMaterialById(int id);
        MaterialModel GetMaterialByName(string name);
    }
}

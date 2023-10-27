using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.Model
{
    public class MaterialModel
    {
        public int id {  get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }

        public MaterialModel() { }
        public MaterialModel (string name, int quantity)
        {
            this.name = name;
            this.quantity = quantity;
        }
        public MaterialModel(int id, string name, int quantity, DateTime createdAt, DateTime updatedAt)
        {
            this.id = id;
            this.name = name;
            this.quantity = quantity;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
        }
    }
}

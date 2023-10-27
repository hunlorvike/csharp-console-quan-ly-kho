using MySql.Data.MySqlClient;
using QuanLyKhoHang.Dao.material;
using QuanLyKhoHang.Model;

public class MaterialDaoImpl : IMaterialDao
{
    private DbConnection dbConnection;

    public MaterialDaoImpl()
    {
        dbConnection = DbConnection.Instance();
    }

    public void AddMaterial(MaterialModel materialModel)
    {
        if (dbConnection.IsConnect())
        {
            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO nguyenlieu(name, quantity) VALUES (@name, @quantity)", dbConnection.Connection))
            {
                cmd.Parameters.AddWithValue("@name", materialModel.name);
                cmd.Parameters.AddWithValue("@quantity", materialModel.quantity);

                cmd.ExecuteNonQuery();
                dbConnection.Close();
            }
        }
    }

    public void DeleteMaterial(int id)
    {
        if (dbConnection.IsConnect())
        {
            using (MySqlCommand cmd = new MySqlCommand("DELETE FROM nguyenlieu WHERE id = @id", dbConnection.Connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                dbConnection.Close();
            }
        }
    }

    public List<MaterialModel> GetAllMaterials()
    {
        List<MaterialModel> materials = new List<MaterialModel>();

        if (dbConnection.IsConnect())
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM nguyenlieu", dbConnection.Connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MaterialModel material = new MaterialModel
                        {
                            id = reader.GetInt32("id"),
                            name = reader.GetString("name"),
                            quantity = reader.GetInt32("quantity"),
                            createdAt = reader.GetDateTime("createdAt"),
                            updatedAt = reader.GetDateTime("updatedAt")
                        };
                        materials.Add(material);
                    }
                }
                dbConnection.Close();
            }
        }

        return materials;
    }

    public MaterialModel GetMaterialById(int id)
    {
        MaterialModel material = null;

        if (dbConnection.IsConnect())
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM nguyenlieu WHERE id = @id", dbConnection.Connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        material = new MaterialModel
                        {
                            id = reader.GetInt32("id"),
                            name = reader.GetString("name"),
                            quantity = reader.GetInt32("quantity"),
                            createdAt = reader.GetDateTime("createdAt"),
                            updatedAt = reader.GetDateTime("updatedAt")
                        };
                    }
                }
                dbConnection.Close();
            }
        }

        return material;
    }

    public MaterialModel GetMaterialByName(string name)
    {
        MaterialModel material = null;

        if (dbConnection.IsConnect())
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM nguyenlieu WHERE name = @name", dbConnection.Connection))
            {
                cmd.Parameters.AddWithValue("@name", name);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        material = new MaterialModel
                        {
                            id = reader.GetInt32("id"),
                            name = reader.GetString("name"),
                            quantity = reader.GetInt32("quantity"),
                            createdAt = reader.GetDateTime("createdAt"),
                            updatedAt = reader.GetDateTime("updatedAt")
                        };
                    }
                }
                dbConnection.Close();
            }
        }

        return material;
    }

    public void UpdateMaterial(int id, MaterialModel materialModel)
    {
        if (dbConnection.IsConnect())
        {
            using (MySqlCommand cmd = new MySqlCommand("UPDATE nguyenlieu SET name = @name, quantity = @quantity, updatedAt = @updatedAt WHERE id = @id", dbConnection.Connection))
            {
                cmd.Parameters.AddWithValue("@name", materialModel.name);
                cmd.Parameters.AddWithValue("@quantity", materialModel.quantity);
                cmd.Parameters.AddWithValue("@updatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                dbConnection.Close();
            }
        }
    }
}

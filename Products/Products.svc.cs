using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Products
{
    public class Products : IProducts
    {
        public List<Product> GetProductList() 
        {
            String SQL = "SELECT ProductID, Name, ProductNumber, ISNULL(Color,'') AS Color, ListPrice FROM Production.Product ORDER BY ProductID";
            String ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["localhost"].ConnectionString;
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(SQL, conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(comm))
                    {
                        da.Fill(dt);
                    }
                }
            }
            List<Product> ProductList = dt.AsEnumerable().Select(r => new Product()
            {
                ID = r.Field<int>("ProductID"),
                Name = r.Field<String>("Name"),
                ProductNumber = r.Field<String>("ProductNumber"),
                Color = r.Field<String>("Color"),
                Price = r.Field<Decimal>("ListPrice")
            }).ToList();
            return ProductList;
        }

    }
}

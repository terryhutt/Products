using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Products
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string ProductNumber { get; set; }

        [DataMember]
        public string Color { get; set; }

        [DataMember]
        public decimal Price { get; set; }
    }

    [ServiceContract]
    public interface IProducts
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "ProductList/")]
        List<Product> GetProductList();
    }
}

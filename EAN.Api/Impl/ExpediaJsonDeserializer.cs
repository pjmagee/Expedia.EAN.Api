namespace EAN.Api.Impl
{
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using RestSharp;
    using RestSharp.Deserializers;

    public class ExpediaJsonDeserializer : IDeserializer
    {
        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }

        public T Deserialize<T>(IRestResponse response)
        {
            T target;

            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(response.Content)))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                target = (T)ser.ReadObject(ms);
            }

            return target;
        }
    }
}
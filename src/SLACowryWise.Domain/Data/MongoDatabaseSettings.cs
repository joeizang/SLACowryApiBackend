using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLACowryWise.Domain.Data
{
    public class MongoDatabaseSettings : IMongoDatabaseSettings
    {
        public string CollectionName { get; set; }
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }

    public interface IMongoDatabaseSettings
    {
        string CollectionName { get; set;}

        string DatabaseName { get; set;}

        string ConnectionString { get; set; }
    }
}

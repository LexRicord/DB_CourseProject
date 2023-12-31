using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_CourseProject.Models
{
    public class Model
    {
        public string ModelName { get; set; }
        public string DeviceType { get; set; }
        public string Producer { get; set; }

        public Model(string modelName, string deviceType, string producer)
        {
            ModelName = modelName;
            DeviceType = deviceType;
            Producer = producer;
        }
    }
}

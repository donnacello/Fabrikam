using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabrikamApp.Model
{
    class NutritionFacts
    {
        public class Fields
        {
            public string item_name { get; set; }
            public double nf_calories { get; set; }
            public double nf_cholesterol { get; set; }
            public double nf_sodium { get; set; }
            public int nf_serving_size_qty { get; set; }
            public string nf_serving_size_unit { get; set; }
        }

        public class Hit
        {
            public string _index { get; set; }
            public string _type { get; set; }
            public string _id { get; set; }
            public double _score { get; set; }
            public Fields fields { get; set; }
        }

        public class RootObject
        {
            public int total_hits { get; set; }
            public double max_score { get; set; }
            public List<Hit> hits { get; set; }
        }
    }
}

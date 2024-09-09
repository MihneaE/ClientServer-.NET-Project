using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModule.Model
{
    public class Competition
    {
        public int id { get; set; }
        public string sample { get; set; }
        public string ageCategory { get; set; }
        public int count { get; set; }

        public Competition() { }

        public Competition(int id, string sample, string ageCategory, int count)
        {
            this.id = id;
            this.sample = sample;
            this.ageCategory = ageCategory;
            this.count = count;
        }

        public override string ToString()
        {
            return $"Competition{{id={id}, sample='{sample}', ageCategory='{ageCategory}', count={count}}}";
        }
    }
}

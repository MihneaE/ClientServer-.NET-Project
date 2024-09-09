using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModule.Model
{
    public class Man
    {
        public int id { get; set; }
        public int sample_id { get; set; }
        public string name { get; set; }
        public int age { get; set; }

        public Man() { }

        public Man(int id, int sample_id, string name, int age)
        {
            this.id = id;
            this.sample_id = sample_id;
            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            return $"Man{{id={id}, sample_id={sample_id}, name='{name}', age='{age}'}}";
        }
    }
}

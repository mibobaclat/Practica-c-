using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sasasa
{
    public class Task1 : purple_guy
    {
        private int _output;
        public int Output => _output;

        public Task1(string text) : base(text)
        {
            _output = 0;
            
        }
        public override void Review()
        {
            _output = 134;
        }
        public override string ToString()
        {
            return "Hello";
        }
    }
}

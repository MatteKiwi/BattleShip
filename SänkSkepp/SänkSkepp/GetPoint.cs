using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SänkSkepp
{
    class GetPoint<T>
    {
        private T data;
        // using properties 
        public T Value
        {

            // using accessors 
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }

        public T Value2
        {

            // using accessors 
            get
            {
                return this.data;
            }
            set
            {
                this.data = Value2;
            }
        }
        public T Value3
        {

            // using accessors 
            get
            {
                return this.data;
            }
            set
            {
                this.data = Value3;
            }
        }
    }
}

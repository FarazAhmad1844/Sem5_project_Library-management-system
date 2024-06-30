using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.classes
{
    abstract class person
    {
        int id;
        string name;


        public int Id
        {
            set
            {
                if (value > 0)
                {
                    value = id;
                }
                else
                {
                    throw new Exception("error");
                }
            }
            get
            {
                return id;
            }
        }
        public String Name
        {
            set
            {

                value = name;
            }


            get
            {
                return name;
            }
        }

        public abstract void insert();
        public abstract void Read();
        public abstract void Readbyid(int id);
        public abstract void Delete(int id);
        public abstract void updatebyid(int id);



    }

}

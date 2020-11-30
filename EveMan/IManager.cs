using System;
using System.Collections.Generic;
using System.Text;

namespace EveMan
{
    interface IManager<T>
    {
        int find(int id);
        bool exist(int id);
        T get(int id);
        bool delete(int id);
        string getInfo(int id);
        string getList();
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>//t değeri bir tür olacak type. bir entity'i karşılayacak
    {//sqlden hangi entity'i gönderiyorsak entity olur.
        List<T> List();
        void Insert(T p);//t'den parametre aldık.
        void Delete(T p);
        void Update(T p);

        List<T> List(Expression<Func<T,bool>>filter);//şartlı listeleme. ali olanları getir gibi.
    }
}

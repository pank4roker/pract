using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Domen.Entities
{
    /// <summary>
    ///  Базовый класс для всех сущностей
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// ID польщователся
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Метод Equals для сравнения ID 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            return obj is BaseEntity entity && Id == entity.Id;
        }
        /// <summary>
        /// Метод GHC, если Equals находит совпадение, то тут иет проверка
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}

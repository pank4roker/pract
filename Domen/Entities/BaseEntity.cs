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
        /// TODO: Описать все сущности
        /// </summary>
        public Guid Id { get; set; }

        public override bool Equals(object? obj)
        {
            // TODO: упростить код
            if (obj == null)
            {
                return false;
            }
            
            if(obj is not BaseEntity entity)
            {
                return false;
            }
            
            if(Id != entity.Id) 
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            // TODO: Проресёрчить, зачем переоределять при Equals
            throw new NotImplementedException();
        }
    }
}

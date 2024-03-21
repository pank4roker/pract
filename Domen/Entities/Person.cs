using Domen.Vlaueobj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Entities
{
    public class Person : BaseEntity
    {
        public Person(FullName fullName) 
        {
            FullName = ValidateFullName(fullName);
        }
        public FullName FullName { get; set; }
        public DateTime BirthDay { get; set; }
        /// <summary>
        /// Сделать проверку Age<150
        /// </summary>
        public int Age  => DateTime.Now.Year - BirthDay.Year;
        /// <summary>
        /// Чтобы начиналась с +37377 и 5 цифр (4-9)
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Проверка того чтобы начиналось с @
        /// </summary>
        public string Telegram { get; set; }
        /// <summary>
        /// CДЕАТЬ так со всеми полями
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private FullName ValidateFullName(FullName fullName)
        {
            if (string.IsNullOrEmpty(fullName.FirstName) ||
                string.IsNullOrEmpty(fullName.LastName))
            {
                throw new ArgumentException("");
            }
            
            if(fullName.MiddleName is not null)
            {
                if(fullName.MiddleName != string.Empty)
                {
                    throw new ArgumentException("");
                }
            }
            //TODO: Допустимы тольуо буквы только русского
            return fullName;
        }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Net.Http.Headers;
using Domen.Primitives;
using Domen.ValueObject;

namespace Domen.Entities
{
    /// <summary>
    /// Класс описывающий пользователся
    /// </summary>
    public class Person : BaseEntity
    {
        /// <summary>
        /// Контструк тор для ФИО
        /// </summary>
        /// <param name="fullName"></param>
        public Person(FullName fullName, DateTime birthDay, string phoneNumber, string telegram, Gender gender)
        {
            FullName = ValidateFullName(fullName);
            BirthDay = ValidateBirthDay(birthDay);
            PhoneNumber = ValidatePhoneNumber(phoneNumber);
            Telegram = ValidateTelegram(telegram);
            Gender = gender;
        }
        /// <summary>
        /// Св-во полного имени
        /// </summary>
        public FullName FullName { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime BirthDay { get; set; }
        /// <summary>
        /// Количество лет
        /// </summary>
        public int Age => DateTime.Now.Year - BirthDay.Year;
        /// <summary>
        /// Телефоный номер
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Ник в тг
        /// </summary>
        public string Telegram { get; set; }
        public Gender Gender { get; set; }
        /// <summary>
        /// Метод для проверки записи ФИО
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private FullName ValidateFullName(FullName fullName)
        {
            if (string.IsNullOrEmpty(fullName.FirstName) ||
                string.IsNullOrEmpty(fullName.LastName))
            {
                throw new ArgumentException("Имя и фамилия не могут быть пустыми.");
            }

            if (fullName.MiddleName is not null)
            {
                if (fullName.MiddleName == string.Empty)
                {
                    throw new ArgumentException(ValidationMessages.IsEmpty);
                }
            }
            //регулярное выражение
            string pattern = @"^[а-яА-ЯёЁ]+$";

            if (!Regex.IsMatch(fullName.FirstName, pattern) ||
                !Regex.IsMatch(fullName.LastName, pattern) ||
               (fullName.MiddleName is not null && !Regex.IsMatch(fullName.MiddleName, pattern)))
            {
                throw new ArgumentException("Имя, фамилия и отчество должны содержать только буквы русского алфавита.");
            }
            return fullName;
        }
        /// <summary>
        /// Метод проверки для записи тг
        /// </summary>
        /// <param name="telegram"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private string ValidateTelegram(string telegram)
        {
            if (string.IsNullOrEmpty(telegram))
            {
                throw new ArgumentException(ValidationMessages.IsEmpty);
            }
            string pattern = @"^@";
            if(!Regex.IsMatch(telegram, pattern)) 
            {
                throw new ArgumentException("Телеграм должен начинаться с символа '@'.");
            }
            return telegram;
        }
        /// <summary>
        /// Метод для проверки количество лет
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private DateTime ValidateBirthDay(DateTime birthDay)
        {
            if (birthDay.Year<DateTime.Today.Year - 150) throw new ArgumentException(ValidationMessages.IsRight);
            return birthDay;
        }
        /// <summary>
        /// Метод для проверки телефона
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private string ValidatePhoneNumber(string phoneNumber) 
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                throw new ArgumentException(ValidationMessages.IsRight);
            }
            string pattern = @"^\+37377[5-9]\d{5}$";
            if (!Regex.IsMatch(phoneNumber, pattern))
            {
                throw new ArgumentException("Телефон должен начинаться с +37377 и 5 цифр (4-9).");
            }
            return phoneNumber;
        }
    }
}
